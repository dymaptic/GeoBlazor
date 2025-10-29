namespace dymaptic.GeoBlazor.Core.Serialization;

public static class JsSyncManager
{
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
            IJSStreamReference streamRef = await js.InvokeAsync<IJSStreamReference>(
                "invokeSerializedMethod", cancellationToken, [method, true, ..parameterList]);
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
    /// <param name="nested">
    ///     True if the parameter is nested within a collection, false if it is a top-level parameter.
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
            return [paramType.Name, parameter];
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
            string key = $"Array_{genericType.Name}";
            if (list.Count > 0 && genericType.IsAssignableTo(typeof(IProtobufSerializable)))
            {
                object protobufParameter = GenerateProtobufCollectionParameter(list, isServer);
                return [key, protobufParameter];
            }
                
            return [key, GenerateJsonParameter(parameter, isServer)];
        }
        
        if (parameter is IProtobufSerializable protobufSerializable)
        {
            MapComponentSerializationRecord protoRecord = protobufSerializable.ToProtobuf();
            object protobufParameter = GenerateProtobufParameter(protoRecord, isServer);
            return [paramType.Name, protobufParameter];
        }
        if (parameter is AttributesDictionary attributesDictionary)
        {
            AttributeSerializationRecord[] serializedItems = attributesDictionary.ToSerializationRecord();
            object protobufParameter =
                GenerateTypedProtobufCollectionParameter<AttributeSerializationRecord, 
                    AttributeCollectionSerializationRecord>(serializedItems, isServer);
            return [nameof(AttributesDictionary), protobufParameter];
        }

        return [paramType.Name, GenerateJsonParameter(parameter, isServer)];
    }
    
    private static object GenerateProtobufParameter(object obj, bool isServer)
    {
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
    
    private static object GenerateProtobufCollectionParameter(IList items, 
        bool isServer)
    {
        object item1 = items[0]!;
        MapComponentSerializationRecord protoItem1 = ((IProtobufSerializable)item1).ToProtobuf();
        Type itemType = protoItem1.GetType();
        Type collectionType = protoItem1.CollectionType;
        var typedArray = Array.CreateInstance(itemType, items.Count);
        typedArray.SetValue(protoItem1, 0);
        for (int i = 1; i < items.Count; i++)
        {
            object item = items[i]!;
            MapComponentSerializationRecord protoItem = ((IProtobufSerializable)item).ToProtobuf();
            typedArray.SetValue(protoItem, i);
        }
        
        MethodInfo genericMethodInfo = typeof(JsSyncManager).GetMethod(
            nameof(GenerateTypedProtobufCollectionParameter),
            BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(itemType, collectionType);
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
}