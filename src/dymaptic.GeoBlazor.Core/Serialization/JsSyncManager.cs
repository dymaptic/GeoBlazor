using ProtoBuf.Meta;
using System.Runtime.CompilerServices;


namespace dymaptic.GeoBlazor.Core.Serialization;

public class JsSyncManager
{
    public JsSyncManager(ISerializationData serializationData)
    {
        _serializationData = serializationData;
        foreach (Type protoType in _serializationData.ProtoContractTypes.Values)
        {
            RuntimeTypeModel.Default.Add(protoType, true);
        }

        RuntimeTypeModel.Default.CompileInPlace();
        
        _serializableMethods = _serializationData.SerializableMethods
            .ToDictionary(g => g.Key, g => g.Value.ToList());
    }

    /// <summary>
    ///     Wrapper method to invoke a void JS function.
    /// </summary>
    /// <param name="js">
    ///     The <IJSObjectReference /> to invoke the method on.
    /// </param>
    /// <param name="isServer">
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </param>
    /// <param name="method">
    ///     The name of the JS function to call.
    /// </param>
    /// <param name="className">
    ///     The name of the calling class.
    /// </param>
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    public async Task InvokeVoidJsMethod(IJSObjectReference js, bool isServer, 
        [CallerMemberName]string method = "", string className = "",
        CancellationToken cancellationToken = default, params object?[] parameters)
    {
        SerializableMethodRecord methodRecord = GetMethodRecord<object?>(method, className, true, parameters);
        List<object?> parameterList = GenerateSerializedParameters(methodRecord, parameters, isServer);

        await js.InvokeVoidAsync("invokeVoidSerializedMethod", cancellationToken, 
            [methodRecord.MethodName, isServer, ..parameterList]);
    }

    /// <summary>
    ///     Wrapper method to invoke a JS function that returns a value.
    /// </summary>
    /// <param name="js">
    ///     The <IJSObjectReference /> to invoke the method on.
    /// </param>
    /// <param name="isServer">
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </param>
    /// <param name="method">
    ///     The name of the JS function to call.
    /// </param>
    /// <param name="className">
    ///     The name of the calling class.
    /// </param>
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    public async Task<T> InvokeJsMethod<T>(IJSObjectReference js, bool isServer, 
        [CallerMemberName]string method = "", string className = "",
        CancellationToken cancellationToken = default, 
        params object?[] parameters)
    {
        SerializableMethodRecord methodRecord = GetMethodRecord<T>(method, className, false, parameters);

        List<object?> parameterList = GenerateSerializedParameters(methodRecord, parameters, isServer);

        Type? returnType = methodRecord.ReturnValue?.Type;
        bool returnTypeIsProtobuf = returnType is not null && _serializationData.ProtoContractTypes.ContainsKey(returnType);

        if (isServer || returnTypeIsProtobuf)
        {
            string? protoReturnTypeName = null;
            if (returnTypeIsProtobuf)
            {
                Type? protoReturnType;
                if (methodRecord.ReturnValue!.SingleType is not null)
                {
                    _serializationData.ProtoCollectionTypes.TryGetValue(methodRecord.ReturnValue.SingleType,
                        out protoReturnType);
                }
                else
                {
                    _serializationData.ProtoContractTypes.TryGetValue(returnType!, out protoReturnType);
                }
                
                protoReturnTypeName = protoReturnType?.Name.Replace("SerializationRecord", "");
            }
            
            IJSStreamReference? streamRef = await js.InvokeAsync<IJSStreamReference?>(
                "invokeSerializedMethod", cancellationToken, 
                [methodRecord.MethodName, true, returnTypeIsProtobuf, protoReturnTypeName, ..parameterList]);

            if (streamRef is null)
            {
                return default!;
            }

            if (returnTypeIsProtobuf)
            {
                if (methodRecord.ReturnValue?.SingleType is not null)
                {
                    return await _serializationData.ReadJsProtobufCollectionStreamReference<T>(streamRef,
                        methodRecord.ReturnValue.SingleType) ?? default!;
                }
                return await _serializationData.ReadJsProtobufStreamReference<T>(streamRef, returnType!) ?? default!;
            }
            
            return (await streamRef.ReadJsStreamReference<T>())!;
        }

        return await js.InvokeAsync<T>(
            "invokeSerializedMethod", cancellationToken, [method, false, false, null, ..parameterList]);
    }

    private SerializableMethodRecord GetMethodRecord<T>(string method, string className, bool returnsVoid, 
        object?[] providedParameters)
    {
        if (!_serializableMethods.TryGetValue(className, out List<SerializableMethodRecord>? classMethods))
        {
            classMethods = new List<SerializableMethodRecord>();
            _serializableMethods[className] = classMethods;
        }

        if (classMethods.Where(m => 
                // same method name
                string.Equals(m.MethodName, method, StringComparison.OrdinalIgnoreCase)
                // same number of parameters
                && m.Parameters.Length == providedParameters.Length
                // either both void or both non-void
                && ((m.ReturnValue is null && returnsVoid)
                     || (m.ReturnValue is not null && !returnsVoid))).ToList() 
            is not { } matchedMethods)
        {
            // use reflection since we don't have a stored method record
            var classType = GeoBlazorMetaData.GeoblazorTypes.First(t => t.Name == className);
            var methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => string.Equals(m.Name, method, StringComparison.OrdinalIgnoreCase)
                    && m.GetParameters().Length == providedParameters.Length)
                .ToArray();

            matchedMethods = [];
            
            foreach (MethodInfo methodInfo in methodInfos)
            {
                List<SerializableParameterRecord> methodParams = [];
                var paramInfos = methodInfo.GetParameters();
                
                foreach (ParameterInfo paramInfo in paramInfos)
                {
                    NullabilityInfo nullabilityInfo = nullabilityContext.Create(paramInfo);
                    bool isNullable = nullabilityInfo.ReadState == NullabilityState.Nullable;
                    Type paramType = paramInfo.ParameterType.IsGenericType &&
                        paramInfo.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>)
                            ? Nullable.GetUnderlyingType(paramInfo.ParameterType)!
                            : paramInfo.ParameterType;
                    Type? collectionType = paramType.IsArray
                        ? paramType.GetElementType()
                        : paramType is { IsGenericType: true, GenericTypeArguments.Length: 1 }
                            ? paramType.GenericTypeArguments[0]
                            : null;
                    methodParams.Add(new SerializableParameterRecord(paramType, isNullable, collectionType));
                }
                
                SerializableParameterRecord? returnRecord = null;

                if (!returnsVoid && methodInfo.ReturnType != typeof(void))
                {
                    ParameterInfo returnParamInfo = methodInfo.ReturnParameter;
                    Type returnType = returnParamInfo.ParameterType;

                    if (returnType.Name.StartsWith("Task") || returnType.Name.StartsWith("ValueTask"))
                    {
                        returnType = returnType.IsGenericType
                            ? returnType.GenericTypeArguments[0]
                            : typeof(void);
                    }

                    bool isNullable = false;

                    if (returnType.IsGenericType &&
                        methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        isNullable = true;
                        returnType = Nullable.GetUnderlyingType(returnType)!;
                    }

                    bool returnIsCollection = returnType.IsArray ||
                        returnType is { IsGenericType: true, GenericTypeArguments.Length: 1 };

                    Type? singleType = null;

                    if (returnIsCollection)
                    {
                        singleType = returnType.IsArray
                            ? returnType.GetElementType()
                            : returnType.GenericTypeArguments[0];
                    }
                    
                    bool isGenericParameter = returnType.IsGenericParameter;

                    if (isGenericParameter)
                    {
                        returnType = returnType.GenericTypeArguments[0];
                    }

                    returnRecord = new SerializableParameterRecord(returnType, isNullable, singleType);
                }

                SerializableMethodRecord methodRecord = new(method, methodParams.ToArray(), returnRecord);
                matchedMethods.Add(methodRecord);

                if (methodRecord.ReturnValue?.Type.IsGenericType != true)
                {
                    // only add non-generic return typed methods to the dictionary
                    classMethods.Add(methodRecord);
                }
            }
        }

        if (matchedMethods.Count == 0)
        {
            // no matching methods, build the record manually
            return new SerializableMethodRecord(method.ToLowerFirstChar(),
                providedParameters.Select(GetSerializableParameterRecord).ToArray(),
                GetSerializableReturnRecord<T>(returnsVoid));
        }

        if (matchedMethods.Count == 1)
        {
            return matchedMethods[0];
        }

        Type requestedReturnType = typeof(T);
        
        // find record with potentially matching parameter types including nulls
        return matchedMethods.First(m =>
        {
            for (int i = 0; i < m.Parameters.Length; i++)
            {
                Type? providedParameterType = providedParameters[i]?.GetType();
                if (providedParameterType is not null &&
                    providedParameterType.IsGenericType &&
                    providedParameterType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    providedParameterType = Nullable.GetUnderlyingType(providedParameterType)!;
                }
                
                SerializableParameterRecord methodParam = m.Parameters[i];

                if (providedParameterType is null)
                {
                    if (!methodParam.IsNullable)
                    {
                        return false;
                    }
                }
                else if (!providedParameterType.IsAssignableTo(methodParam.Type))
                {
                    return false;
                }
            }

            if (!returnsVoid && requestedReturnType != m.ReturnValue?.Type)
            {
                return false;
            }

            return true;
        });
    }
    
    private List<object?> GenerateSerializedParameters(SerializableMethodRecord methodRecord,
        object?[] parameters, bool isServer)
    {
        List<object?> serializedParameters = [];
        for (int i = 0; i < parameters.Length; i++)
        {
            object? parameterValue = parameters[i];
            SerializableParameterRecord parameterRecord = methodRecord.Parameters[i];
            serializedParameters.AddRange(ProcessParameter(parameterValue, parameterRecord, isServer));
        }
        return serializedParameters;
    }

    /// <summary>
    ///     Returns the processed parameter Type and a Serialized or DotNetStreamReference of the serialized parameter value.
    /// </summary>
    /// <param name="parameterValue">
    ///     The original parameter to process.
    /// </param>
    /// <param name="parameterRecord">
    ///     The SerializableParameterRecord for the parameter.
    /// </param>
    /// <param name="isServer">
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </param>
    private object?[] ProcessParameter(object? parameterValue, SerializableParameterRecord parameterRecord, 
        bool isServer)
    {
        if (parameterValue is null)
        {
            return ["null", null];
        }
        
        Type paramType = parameterRecord.Type;
        
        if (simpleTypes.Contains(paramType) || paramType.IsPrimitive)
        {
            return [GetKey(paramType), parameterValue];
        }

        if (paramType.IsEnum)
        {
            // use the JsonConverter defined EnumToKebabCaseConverters to serialize enums as strings
            string stringValue = JsonSerializer.Serialize(parameterValue, GeoBlazorSerialization.JsonSerializerOptions);
            // pass as type string so JS can parse correctly
            return [nameof(String), stringValue];
        }
        
        if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            Type underlyingType = Nullable.GetUnderlyingType(paramType)!;
            object underlyingValue = Convert.ChangeType(parameterValue, underlyingType);
            return ProcessParameter(underlyingValue, parameterRecord with { Type = underlyingType, IsNullable = true }, isServer);
        }

        if (parameterValue is IList list && paramType != typeof(MapPath) && paramType != typeof(MapPoint))
        {
            Type genericType = parameterRecord.SingleType ?? (paramType.IsArray
                ? paramType.GetElementType()!
                : paramType.GenericTypeArguments[0]);
            string key = $"{GetKey(genericType)}Collection";
            
            if (_serializationData.ProtoContractTypes.ContainsKey(genericType))
            {
                object protobufParameter = _serializationData.GenerateProtobufCollectionParameter(list, genericType, isServer);
                return [key, protobufParameter];
            }
                
            return [key, GenerateJsonParameter(parameterValue, isServer)];
        }
        
        if (_serializationData.ProtoContractTypes.ContainsKey(paramType))
        {
            object protobufParameter = _serializationData.GenerateProtobufParameter(parameterValue, paramType, isServer);
            return [GetKey(paramType), protobufParameter];
        }
        
        if (parameterValue is AttributesDictionary attributesDictionary)
        {
            AttributeSerializationRecord[] serializedItems = attributesDictionary.ToProtobufArray();
            AttributeCollectionSerializationRecord collection = new(serializedItems);
            MemoryStream memoryStream = new();
            Serializer.Serialize(memoryStream, collection);
            memoryStream.Seek(0, SeekOrigin.Begin);
        
            if (isServer)
            {
                return [nameof(AttributesDictionary), new DotNetStreamReference(memoryStream)];
            }

            byte[] data = memoryStream.ToArray();
            memoryStream.Dispose();
            return [nameof(AttributesDictionary), data];
        }

        return [GetKey(paramType), GenerateJsonParameter(parameterValue, isServer)];
    }
    
    private static object GenerateJsonParameter<T>(T obj, bool isServer)
    {
        if (isServer)
        {
            MemoryStream memoryStream = new();
            JsonSerializer.Serialize(memoryStream, obj, GeoBlazorSerialization.JsonSerializerOptions);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return new DotNetStreamReference(memoryStream);
        }
        
        return JsonSerializer.Serialize(obj, GeoBlazorSerialization.JsonSerializerOptions);
    }

    private string GetKey(Type type)
    {
        Type? matchedType = _serializationData.ProtoContractTypes.Keys.FirstOrDefault(t => t == type);

        if (matchedType is not null)
        {
            return _serializationData.ProtoContractTypes[type].GetCustomAttribute<ProtoContractAttribute>()!.Name;
        }

        return type.Name;
    }

    private SerializableParameterRecord GetSerializableParameterRecord(object? parameter)
    {
        if (parameter is null)
        {
            return new SerializableParameterRecord(typeof(object), true, null);
        }
        
        Type paramType = parameter.GetType();

        if (simpleTypes.Contains(paramType))
        {
            return new SerializableParameterRecord(paramType, true, null);
        }
        bool isCollection = paramType.IsAssignableTo(typeof(IEnumerable));
        Type? collectionType = isCollection 
            ? paramType.IsArray 
                ? paramType.GetElementType() 
                : paramType.GetGenericArguments()[0] 
            : null;
        return new SerializableParameterRecord(paramType, true, collectionType);
    }

    private SerializableParameterRecord GetSerializableReturnRecord<T>(bool returnsVoid)
    {
        if (returnsVoid)
        {
            return new SerializableParameterRecord(typeof(void), false, null);
        }
        Type returnType = typeof(T);
        
        if (simpleTypes.Contains(returnType))
        {
            return new SerializableParameterRecord(returnType, true, null);
        }
        bool isCollection = returnType.IsAssignableTo(typeof(IEnumerable));
        Type? collectionType = isCollection 
            ? returnType.IsArray 
                ? returnType.GetElementType() 
                : returnType.GetGenericArguments()[0] 
            : null;
        return new SerializableParameterRecord(returnType, true, collectionType);
    }
    
    private readonly ISerializationData _serializationData;
    private readonly Dictionary<string, List<SerializableMethodRecord>> _serializableMethods;
    private static readonly NullabilityInfoContext nullabilityContext = new();
    
    private static readonly Type[] simpleTypes =
    [
        typeof(string), typeof(char), typeof(bool), typeof(byte), typeof(sbyte), typeof(short),
        typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float),
        typeof(double), typeof(decimal), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan),
        typeof(Guid), typeof(DateOnly), typeof(TimeOnly)
    ];
}

public record SerializableMethodRecord(string MethodName, SerializableParameterRecord[] Parameters, 
    SerializableParameterRecord? ReturnValue);
public record SerializableParameterRecord(Type Type, bool IsNullable, Type? SingleType);