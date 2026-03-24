using ProtoBuf.Meta;
using System.Runtime.CompilerServices;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Manages JavaScript synchronization for protobuf serialization of map components.
/// </summary>
public static class JsSyncManager
{
    /// <summary>
    ///     Dictionary of serializable methods keyed by type name.
    /// </summary>
    public static Dictionary<string, SerializableMethodRecord[]> SerializableMethods { get; set; } = [];

    /// <summary>
    ///     Dictionary mapping component types to their protobuf serialization record types.
    /// </summary>
    public static Dictionary<Type, Type> ProtoContractTypes { get; set; } = [];

    /// <summary>
    ///     Dictionary mapping component types to their protobuf collection serialization record types.
    /// </summary>
    public static Dictionary<Type, Type> ProtoCollectionTypes { get; set; } = [];

    /// <summary>
    ///     Collection of Reusable <see cref="AbortManager" /> instances for components.
    /// </summary>
    public static Dictionary<IJSObjectReference, AbortManager> AbortManagers { get; set; } = [];

    /// <summary>
    ///     Initializes the JsSyncManager by registering protobuf types and compiling the runtime model.
    /// </summary>
    public static void Initialize()
    {
        foreach (var protoType in ProtoContractTypes.Values)
        {
            RuntimeTypeModel.Default.Add(protoType, true);
        }

        RuntimeTypeModel.Default.CompileInPlace();

        _serializableMethods = SerializableMethods
            .ToDictionary(g => g.Key,
                g => g.Value.ToList());
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
    public static async Task InvokeVoidJsMethod(this IJSObjectReference js, bool isServer,
        [CallerMemberName] string method = "", string className = "",
        CancellationToken cancellationToken = default, params object?[] parameters)
    {
        var methodRecord = GetMethodRecord<object?>(method, className, true, parameters);
        var parameterList = await GenerateSerializedParameters(methodRecord, parameters, isServer, js);

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
    /// <param name="maxAllowedSize">
    ///     The maximum size of the returned data.
    /// </param>
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    public static async Task<T> InvokeJsMethod<T>(this IJSObjectReference js, bool isServer, 
        [CallerMemberName] string method = "", string className = "", long? maxAllowedSize = null,
        CancellationToken cancellationToken = default,
        params object?[] parameters)
    {
        maxAllowedSize ??= 1_000_000_000L;
        var methodRecord = GetMethodRecord<T>(method, className, false, parameters);

        var parameterList = await GenerateSerializedParameters(methodRecord, parameters, isServer, js);
        var returnType = methodRecord.ReturnValue?.Type;
        bool returnTypeIsProtobuf = returnType is not null && ProtoContractTypes.ContainsKey(returnType);

        bool returnIsNullableValueType = returnType?.IsValueType == true 
            && methodRecord.ReturnValue!.IsNullable;

        if (isServer 
            || returnIsNullableValueType
            || returnTypeIsProtobuf 
            || (returnType?.IsAssignableTo(typeof(Stream)) == true))
        {
            string? protoReturnTypeName = null;

            if (returnTypeIsProtobuf)
            {
                Type? protoReturnType;

                if (methodRecord.ReturnValue!.SingleType is not null)
                {
                    ProtoCollectionTypes.TryGetValue(methodRecord.ReturnValue.SingleType,
                        out protoReturnType);
                }
                else
                {
                    ProtoContractTypes.TryGetValue(returnType!, out protoReturnType);
                }

                protoReturnTypeName = protoReturnType?.Name.Replace("SerializationRecord", "");
            }

            var streamRef = await js.InvokeAsync<IJSStreamReference?>("invokeSerializedMethod",
                cancellationToken,
                [methodRecord.MethodName, true, returnTypeIsProtobuf, protoReturnTypeName, ..parameterList]);

            if (streamRef is null)
            {
                return default(T)!;
            }

            if (returnTypeIsProtobuf)
            {
                if (methodRecord.ReturnValue?.SingleType is not null)
                {
                    IProtobufSerializable[]? collectionResult = await streamRef
                        .ReadJsStreamReferenceAsProtobufCollection(methodRecord.ReturnValue.SingleType,
                            maxAllowedSize, cancellationToken);

                    if (collectionResult is null)
                    {
                        return default(T)!;
                    }

                    var typedArray = Array.CreateInstance(methodRecord.ReturnValue.SingleType, collectionResult.Length);

                    Array.Copy(collectionResult, typedArray, collectionResult.Length);

                    return (T)(object)typedArray;
                }

                var result = await streamRef.ReadJsStreamReferenceAsProtobuf(returnType!,
                    maxAllowedSize, cancellationToken);

                return result is null ? default(T)! : (T)result;
            }

            if (returnType?.IsAssignableTo(typeof(Stream)) == true)
            {
                // the calling code actually wants to handle the stream, so we will just unwrap and pass it back
                var result = await streamRef.ReadJsStreamReferenceAsStream(maxAllowedSize, cancellationToken);

                if (result is null)
                {
                    return default(T)!;
                }

                // double-cast to force to generic
                return (T)(object)result;
            }

            // read and deserialize the stream
            return (await streamRef.ReadJsStreamReferenceAsJSON<T>(maxAllowedSize, cancellationToken))!;
        }

        return await js.InvokeAsync<T>("invokeSerializedMethod", cancellationToken,
            [methodRecord.MethodName, false, false, null, ..parameterList]);
    }

    private static SerializableMethodRecord GetMethodRecord<T>(string method, string className, bool returnsVoid,
        object?[] providedParameters)
    {
        if (!_serializableMethods.TryGetValue(className, out var classMethods))
        {
            classMethods = new List<SerializableMethodRecord>();
            _serializableMethods[className] = classMethods;
        }

        if (classMethods.Where(m =>

                    // same method name
                    string.Equals(m.MethodName, method, StringComparison.OrdinalIgnoreCase)

                    // same number of parameters
                    && (m.Parameters.Length == providedParameters.Length)

                    // either both void or both non-void
                    && ((m.ReturnValue is null && returnsVoid)
                        || (m.ReturnValue is not null && !returnsVoid)))
                .ToList()
            is not { } matchedMethods)
        {
            if (method == GeoBlazorSerialization.GET_PROPERTY)
            {
                SerializableMethodRecord getPropertyRecord = GenerateGetPropertyRecord<T>();
                classMethods.Add(getPropertyRecord);
                matchedMethods = [getPropertyRecord];
            }
            else if (method == GeoBlazorSerialization.SET_PROPERTY)
            {
                SerializableMethodRecord setPropertyRecord = GenerateSetPropertyRecord<T>();
                classMethods.Add(setPropertyRecord);
                matchedMethods = [setPropertyRecord];
            }
            else
            {
                // use reflection since we don't have a stored method record
                var classType = GeoBlazorMetaData.GeoblazorTypes.First(t => t.Name == className);

                var methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => string.Equals(m.Name, method, StringComparison.OrdinalIgnoreCase)
                        && (m.GetParameters().Length == providedParameters.Length))
                    .ToArray();

                matchedMethods = [];

                foreach (var methodInfo in methodInfos.Where(m => m.ReturnType.IsGenericType))
                {
                    List<SerializableParameterRecord> methodParams = [];
                    var paramInfos = methodInfo.GetParameters();

                    foreach (var paramInfo in paramInfos)
                    {
                        methodParams.Add(CreateParameterRecord(paramInfo.ParameterType, paramInfo));
                    }

                    SerializableParameterRecord? returnRecord = null;

                    if (!returnsVoid && (methodInfo.ReturnType != typeof(void)))
                    {
                        var returnParamInfo = methodInfo.ReturnParameter;
                        var returnType = returnParamInfo.ParameterType;

                        returnRecord = CreateParameterRecord(returnType, returnParamInfo);

                        if (returnRecord.Type.IsGenericType)
                        {
                            // skip methods that return generic types, they cannot be handled
                            continue;
                        }
                    }

                    SerializableMethodRecord methodRecord =
                        new(method.ToLowerFirstChar(), methodParams.ToArray(), returnRecord);
                    matchedMethods.Add(methodRecord);
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

        var requestedReturnType = typeof(T);

        // find record with potentially matching parameter types including nulls
        return matchedMethods.First(m =>
        {
            for (int i = 0; i < m.Parameters.Length; i++)
            {
                var providedParameterType = providedParameters[i]?.GetType();

                if (providedParameterType is not null &&
                    providedParameterType.IsGenericType &&
                    (providedParameterType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    providedParameterType = Nullable.GetUnderlyingType(providedParameterType)!;
                }

                var methodParam = m.Parameters[i];

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

            if (!returnsVoid && (requestedReturnType != m.ReturnValue?.Type))
            {
                return false;
            }

            return true;
        });
    }

    private static SerializableMethodRecord GenerateGetPropertyRecord<T>()
    {
        return new SerializableMethodRecord(GeoBlazorSerialization.GET_PROPERTY,
            [CreateParameterRecord(typeof(string), null)], GetSerializableReturnRecord<T>(false));
    }

    private static SerializableMethodRecord GenerateSetPropertyRecord<T>()
    {
        return new SerializableMethodRecord(GeoBlazorSerialization.SET_PROPERTY,
            [CreateParameterRecord(typeof(string), null), CreateParameterRecord(typeof(T), null)], GetSerializableReturnRecord<T>(false));
    }

    private static async Task<List<object?>> GenerateSerializedParameters(SerializableMethodRecord methodRecord,
        object?[] parameters, bool isServer, IJSObjectReference js)
    {
        List<object?> serializedParameters = [];

        for (int i = 0; i < parameters.Length; i++)
        {
            object? parameterValue = parameters[i];
            var parameterRecord = methodRecord.Parameters[i];
            serializedParameters.AddRange(await ProcessParameter(parameterValue, parameterRecord, isServer, js));
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
    /// <param name="js">
    ///     The current class instance JS object reference
    /// </param>
    private static async Task<object?[]> ProcessParameter(object? parameterValue,
        SerializableParameterRecord parameterRecord,
        bool isServer, IJSObjectReference js)
    {
        if (parameterValue is null)
        {
            return ["null", null];
        }

        var paramType = parameterRecord.Type;

        if (paramType == typeof(CancellationToken))
        {
            if (!AbortManagers.TryGetValue(js, out var abortManager))
            {
                abortManager = new AbortManager(js);
                AbortManagers[js] = abortManager;
            }

            object? value = parameterValue is CancellationToken token
                ? await abortManager.CreateAbortSignal(token)
                : null;

            return ["abortSignal", value];
        }

        if (simpleTypes.Contains(paramType) || paramType.IsPrimitive)
        {
            return [GetKey(paramType), parameterValue];
        }

        if (paramType.IsAssignableTo(typeof(IJSObjectReference)))
        {
            return ["JsObject", parameterValue];
        }

        if (parameterValue is Stream streamVal)
        {
            DotNetStreamReference streamRef = new(streamVal);
            return ["StreamReference", streamRef];
        }

        if (paramType.IsEnum)
        {
            // use the JsonConverter defined EnumToKebabCaseConverters to serialize enums as strings
            var stringValue = JsonSerializer.Serialize(parameterValue, GeoBlazorSerialization.JsonSerializerOptions);

            // pass as type string so JS can parse correctly
            return [nameof(String), stringValue];
        }

        if (paramType.IsGenericType && (paramType.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            var underlyingType = Nullable.GetUnderlyingType(paramType)!;
            object underlyingValue = Convert.ChangeType(parameterValue, underlyingType);

            return await ProcessParameter(underlyingValue,
                parameterRecord with { Type = underlyingType, IsNullable = true }, isServer, js);
        }

        if (parameterValue is IList list && !geoblazorEnumerableTypes.Contains(paramType))
        {
            var genericType = parameterRecord.SingleType ?? (paramType.IsArray
                ? paramType.GetElementType()!
                : paramType.GenericTypeArguments[0]);
            string key = $"{GetKey(genericType)}Collection";

            if (ProtoContractTypes.ContainsKey(genericType))
            {
                var protobufParameter = list.ToProtobufCollectionParameter(genericType, isServer);

                return [key, protobufParameter];
            }

            return [key, parameterValue.ToJsonParameter(isServer)];
        }

        if (ProtoContractTypes.ContainsKey(paramType))
        {
            var protobufParameter = parameterValue.ToProtobufParameter(paramType, isServer);

            return [GetKey(paramType), protobufParameter];
        }

        if (parameterValue is AttributesDictionary attributesDictionary)
        {
            var serializedItems = attributesDictionary.ToProtobufArray();
            AttributeCollectionSerializationRecord collection = new(serializedItems);
            MemoryStream memoryStream = new();
            Serializer.Serialize(memoryStream, collection);
            memoryStream.Seek(0, SeekOrigin.Begin);

            if (isServer)
            {
                return [nameof(AttributesDictionary), new DotNetStreamReference(memoryStream)];
            }

            byte[] data = memoryStream.ToArray();
            await memoryStream.DisposeAsync();

            return [nameof(AttributesDictionary), data];
        }

        return [GetKey(paramType), parameterValue.ToJsonParameter(isServer)];
    }

    private static object ToJsonParameter<T>(this T obj, bool isServer)
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

    private static string GetKey(Type type)
    {
        var matchedType = ProtoContractTypes.Keys.FirstOrDefault(t => t == type);

        if (matchedType is not null)
        {
            return ProtoContractTypes[type].GetCustomAttribute<ProtoContractAttribute>()!.Name;
        }

        return type.Name;
    }

    private static SerializableParameterRecord GetSerializableParameterRecord(object? parameter)
    {
        if (parameter is null)
        {
            return new SerializableParameterRecord(typeof(object), true,
                null, false);
        }

        var paramType = parameter.GetType();

        return CreateParameterRecord(paramType, null);
    }

    private static SerializableParameterRecord GetSerializableReturnRecord<T>(bool returnsVoid)
    {
        if (returnsVoid)
        {
            return new SerializableParameterRecord(typeof(void), false,
                null, false);
        }

        var returnType = typeof(T);

        return CreateParameterRecord(returnType, null);
    }

    private static SerializableParameterRecord CreateParameterRecord(Type paramType, ParameterInfo? parameterInfo)
    {
        if (paramType.Name.StartsWith("Task") || paramType.Name.StartsWith("ValueTask"))
        {
            paramType = paramType.IsGenericType
                ? paramType.GenericTypeArguments[0]
                : typeof(void);
        }

        if (simpleTypes.Contains(paramType)

            // these types will trigger the "isCollection" check below, but should be treated as single types
            || geoblazorEnumerableTypes.Contains(paramType))
        {
            return new SerializableParameterRecord(paramType, true,
                null, false);
        }

        if (paramType.Name.Contains("AnonymousType"))
        {
            // anonymous object
            return new SerializableParameterRecord(typeof(object), true,
                null, false);
        }

        if (paramType == typeof(AttributesDictionary))
        {
            return new SerializableParameterRecord(typeof(AttributesDictionary), true,
                typeof(AttributeSerializationRecord), false);
        }

        bool typeIsNullable = IsTypeNullable(paramType)
            || (parameterInfo is not null && IsParameterNullable(parameterInfo));

        // unwrap nullable types
        if (typeIsNullable && paramType.IsGenericType && (paramType.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            paramType = Nullable.GetUnderlyingType(paramType)!;
        }

        bool isCollection = paramType.IsAssignableTo(typeof(IEnumerable))
            && !paramType.IsAssignableTo(typeof(IDictionary));

        var collectionType = isCollection
            ? paramType.IsArray
                ? paramType.GetElementType()
                : paramType.GenericTypeArguments[0]
            : null;

        bool collectionTypeIsNullable = IsTypeNullable(collectionType);

        return new SerializableParameterRecord(paramType, typeIsNullable,
            collectionType, collectionTypeIsNullable);
    }

    private static bool IsParameterNullable(ParameterInfo paramInfo)
    {
        var nullabilityInfo = nullabilityContext.Create(paramInfo);

        return nullabilityInfo.ReadState == NullabilityState.Nullable;
    }

    private static bool IsTypeNullable(Type? type)
    {
        return type is { IsGenericType: true }
            && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
    }

    private static readonly NullabilityInfoContext nullabilityContext = new();

    private static readonly Type[] simpleTypes =
    [
        typeof(string), typeof(char), typeof(bool), typeof(byte), typeof(sbyte), typeof(short),
        typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float),
        typeof(double), typeof(decimal), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan),
        typeof(Guid), typeof(DateOnly), typeof(TimeOnly)
    ];

    private static readonly Type[] geoblazorEnumerableTypes =
    [
        typeof(MapPath), typeof(MapPoint)
    ];

    private static Dictionary<string, List<SerializableMethodRecord>> _serializableMethods = [];
}

/// <summary>
///     Represents metadata about a serializable method including its name, parameters, and return type.
/// </summary>
/// <param name="MethodName">The name of the method.</param>
/// <param name="Parameters">The parameters of the method.</param>
/// <param name="ReturnValue">The return value information, if any.</param>
public record SerializableMethodRecord(
    string MethodName,
    SerializableParameterRecord[] Parameters,
    SerializableParameterRecord? ReturnValue);

/// <summary>
///     Represents metadata about a serializable parameter including its type and nullability.
/// </summary>
/// <param name="Type">The type of the parameter.</param>
/// <param name="IsNullable">Whether the parameter is nullable.</param>
/// <param name="SingleType">The single generic type argument, if applicable.</param>
/// <param name="SingleTypeIsNullable">Whether the single generic type argument is nullable, if applicable.</param>
public record SerializableParameterRecord(Type Type, bool IsNullable, Type? SingleType, bool SingleTypeIsNullable);