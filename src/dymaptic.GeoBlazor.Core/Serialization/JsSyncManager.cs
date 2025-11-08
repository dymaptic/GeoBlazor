using ProtoBuf.Meta;


namespace dymaptic.GeoBlazor.Core.Serialization;

public static class JsSyncManager
{
    static JsSyncManager()
    {
        LoadProtoTypes();
        foreach (Type protoType in _protoContractTypes.Values)
        {
            RuntimeTypeModel.Default.Add(protoType, true);
        }
        RuntimeTypeModel.Default.CompileInPlace();
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
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    public static async Task InvokeVoidJsMethod(this IJSObjectReference js, bool isServer, string method, 
        CancellationToken cancellationToken, params object?[] parameters)
    {
        object?[] parameterList = GenerateSerializedParameters(parameters, isServer);

        await js.InvokeVoidAsync(
            "invokeVoidSerializedMethod", cancellationToken, [method, isServer, ..parameterList]);
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
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    public static async Task<T> InvokeJsMethod<T>(this IJSObjectReference js, bool isServer, string method,
        CancellationToken cancellationToken, params object?[] parameters)
    {
        object?[] parameterList = GenerateSerializedParameters(parameters, isServer);

        if (isServer)
        {
            IJSStreamReference? streamRef = await js.InvokeAsync<IJSStreamReference?>(
                "invokeSerializedMethod", cancellationToken, [method, true, ..parameterList]);

            if (streamRef is null)
            {
                return default!;
            }
            return (await streamRef.ReadJsStreamReference<T>())!;
        }

        return await js.InvokeAsync<T>(
            "invokeSerializedMethod", cancellationToken, [method, false, ..parameterList]);
    }
    
    private static object?[] GenerateSerializedParameters(object?[] parameters, bool isServer)
    {
        return parameters.SelectMany(p => ProcessParameter(p, isServer)).ToArray();
    }

    /// <summary>
    ///     Returns the processed parameter Type and a Serialized or DotNetStreamReference of the serialized parameter value.
    /// </summary>
    /// <param name="parameter">
    ///     The original parameter to process.
    /// </param>
    /// <param name="isServer">
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </param>
    private static object?[] ProcessParameter(object? parameter, bool isServer)
    {
        if (parameter is null)
        {
            return ["null", null];
        }
        
        Type paramType = parameter.GetType();
        
        if (simpleTypes.Contains(paramType) || paramType.IsPrimitive)
        {
            return [GetKey(paramType), parameter];
        }

        if (paramType.IsEnum)
        {
            // use the JsonConverter defined EnumToKebabCaseConverters to serialize enums as strings
            string stringValue = JsonSerializer.Serialize(parameter, GeoBlazorSerialization.JsonSerializerOptions);
            // pass as type string so JS can parse correctly
            return [nameof(String), stringValue];
        }
        
        if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            Type underlyingType = Nullable.GetUnderlyingType(paramType)!;
            object underlyingValue = Convert.ChangeType(parameter, underlyingType);
            return ProcessParameter(underlyingValue, isServer);
        }

        if (parameter is IList list)
        {
            Type genericType = paramType.IsArray 
                ? paramType.GetElementType()! 
                : paramType.GenericTypeArguments[0];
            string key = $"Array_{GetKey(genericType)}";
            
            if (list.Count > 0 && _protoContractTypes!.ContainsKey(genericType))
            {
                object protobufParameter = GenerateProtobufCollectionParameter(list, genericType, isServer);
                return [key, protobufParameter];
            }
                
            return [key, GenerateJsonParameter(parameter, isServer)];
        }
        
        if (_protoContractTypes.ContainsKey(paramType))
        {
            MethodInfo toProtobufMethodInfo = paramType.GetMethod(
                nameof(IProtobufSerializable<>.ToProtobuf), 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)!;
            object protoRecord = toProtobufMethodInfo.Invoke(parameter, null)!;
            object protobufParameter = GenerateProtobufParameter(protoRecord, isServer);
            return [GetKey(paramType), protobufParameter];
        }
        
        if (parameter is AttributesDictionary attributesDictionary)
        {
            AttributeSerializationRecord[] serializedItems = attributesDictionary.ToProtobufArray();
            object protobufParameter =
                GenerateTypedProtobufCollectionParameter<AttributeSerializationRecord, 
                    AttributeCollectionSerializationRecord>(serializedItems, isServer);
            return [nameof(AttributesDictionary), protobufParameter];
        }

        return [GetKey(paramType), GenerateJsonParameter(parameter, isServer)];
    }
    
    private static object GenerateProtobufParameter(object obj, bool isServer)
    {
        // this creates and invokes the generic method GenerateTypedProtobufParameter<T> below
        Type protoType = obj.GetType();
        MethodInfo genericMethodInfo = typeProtobufMethodInfo.MakeGenericMethod(protoType);
        return genericMethodInfo.Invoke(null, [obj, isServer])!;
    }
    
    private static object GenerateTypedProtobufParameter<T>(T obj, bool isServer)
    {
        MemoryStream memoryStream = new();
        Serializer.Serialize(memoryStream, obj);
        memoryStream.Seek(0, SeekOrigin.Begin);
        
        if (isServer)
        {
            return new DotNetStreamReference(memoryStream);
        }

        byte[] data = memoryStream.ToArray();
        memoryStream.Dispose();

        return data;
    }
    
    private static object GenerateProtobufCollectionParameter(IList items, Type serializableType, bool isServer)
    {
        Type protoType = _protoContractTypes[serializableType];
        MethodInfo toProtobufMethodInfo = serializableType.GetMethod(
            nameof(IProtobufSerializable<>.ToProtobuf), 
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)!;
        var typedArray = Array.CreateInstance(protoType, items.Count);
        Type? collectionType = null;
        for (int i = 0; i < items.Count; i++)
        {
            object item = items[i]!;
            MapComponentSerializationRecord protoItem = 
                (MapComponentSerializationRecord)toProtobufMethodInfo.Invoke(item, null)!;
            collectionType ??= protoItem.CollectionType;
            typedArray.SetValue(protoItem, i);
        }
        
        // this creates and invokes the generic method GenerateTypedProtobufCollectionParameter<TItem, TCollection> below
        // which wraps the typedArray in the appropriate collection type and serializes it
        MethodInfo genericMethodInfo = typeof(JsSyncManager).GetMethod(
            nameof(GenerateTypedProtobufCollectionParameter),
            BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(protoType, collectionType!);
        return genericMethodInfo.Invoke(null, [typedArray, isServer])!;
    }
    
    private static object GenerateTypedProtobufCollectionParameter<TItem, TCollection>(TItem[] items, bool isServer)
        where TItem : MapComponentSerializationRecord
        where TCollection : MapComponentCollectionSerializationRecord<TItem>
    {
        var collection = (MapComponentCollectionSerializationRecord<TItem>)Activator.CreateInstance(typeof(TCollection))!;
        collection.Items = items;
        MemoryStream memoryStream = new();
        Serializer.Serialize(memoryStream, collection);
        memoryStream.Seek(0, SeekOrigin.Begin);
        
        if (isServer)
        {
            return new DotNetStreamReference(memoryStream);
        }

        byte[] data = memoryStream.ToArray();
        memoryStream.Dispose();

        return data;
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

    private static string GetKey(Type type)
    {
        Type? matchedType = _protoContractTypes.Keys.FirstOrDefault(t => t == type);

        if (matchedType is not null)
        {
            return _protoContractTypes[type].GetCustomAttribute<ProtoContractAttribute>()!.Name;
        }

        return type.Name;
    }

    private static void LoadProtoTypes()
    {
        Type[] allTypes = Assembly.Load("dymaptic.GeoBlazor.Core").GetTypes();

        try
        {
            allTypes = allTypes
                .Concat(Assembly.Load("dymaptic.GeoBlazor.Pro").GetTypes())
                .ToArray();
        }
        catch (Exception)
        {
            // ignored, Pro is not available
        }
            
        string interfaceName = $"{nameof(IProtobufSerializable<>)}`1";

        _protoContractTypes = allTypes
            .Where(t => t.GetInterface(interfaceName) is not null)
            .ToDictionary(t => t,
                t => t.GetInterface(interfaceName)!.GenericTypeArguments[0]);
    }

    private static readonly Type[] simpleTypes =
    [
        typeof(string), typeof(char), typeof(bool), typeof(byte), typeof(sbyte), typeof(short),
        typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float),
        typeof(double), typeof(decimal), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan),
        typeof(Guid), typeof(DateOnly), typeof(TimeOnly)
    ];
    
    private static readonly Type syncManagerType = typeof(JsSyncManager);
    private static readonly MethodInfo typeProtobufMethodInfo = syncManagerType.GetMethod(
        nameof(GenerateTypedProtobufParameter),
        BindingFlags.NonPublic | BindingFlags.Static)!;
    private static Dictionary<Type, Type> _protoContractTypes = [];
}