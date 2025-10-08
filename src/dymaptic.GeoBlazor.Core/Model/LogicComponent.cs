namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A base class for non-map components, such as GeometryEngine, Projection, etc.
/// </summary>
public abstract class LogicComponent(IAppValidator appValidator, IJSRuntime jsRuntime, 
    JsModuleManager jsModuleManager)
{
    /// <summary>
    ///     The name of the logic component.
    /// </summary>
    protected abstract string ComponentName { get; }

    /// <summary>
    ///     A JavaScript Module reference to the component's JS file.
    /// </summary>
    protected IJSObjectReference? Component { get; set; }

    /// <summary>
    ///     A .NET Object reference to this class for use in JavaScript.
    /// </summary>
    [JsonConverter(typeof(DotNetObjectReferenceJsonConverter))]
    protected DotNetObjectReference<LogicComponent> DotNetComponentReference =>
        DotNetObjectReference.Create(this);

    /// <summary>
    ///     The project library which houses this particular logic component.
    /// </summary>
    protected virtual string Library => "Core";

    /// <summary>
    ///     A JavaScript invokable method that returns a JS Error and converts it to an Exception.
    /// </summary>
    /// <param name="error">
    ///     The original JavaScript error.
    /// </param>
    /// <exception cref="JavascriptException">
    ///     The converted error to exception.
    /// </exception>
    [JSInvokable]
    public void OnJavascriptError(JavascriptError error)
    {
        var exception = new JavascriptException(error);
        throw exception;
    }

    /// <summary>
    ///     Initializes the JavaScript reference component, if not already initialized.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    public virtual async Task Initialize(CancellationToken cancellationToken = default)
    {
        if (!_validated)
        {
            await appValidator.ValidateLicense();
            _validated = true;
        }

        Component ??= await jsModuleManager.GetLogicComponent(jsRuntime, ComponentName, cancellationToken);
    }

    /// <summary>
    ///     Convenience method to invoke a JS function from the .NET logic component class.
    /// </summary>
    /// <param name="method">
    ///     The name of the JS function to call.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    internal virtual async Task InvokeVoidAsync(string method, params object?[] parameters)
    {
        await Initialize();
        
        object?[] parameterList = GenerateSerializedParameters(parameters);

        await Component!.InvokeVoidAsync(
            "invokeVoidSerializedMethod", [method, IsServer, ..parameterList]);
    }

    /// <summary>
    ///     Convenience method to invoke a JS function from the .NET logic component class.
    /// </summary>
    /// <param name="method">
    ///     The name of the JS function to call.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    internal virtual Task<T> InvokeAsync<T>(string method, params object?[] parameters)
    {
        return InvokeAsync<T>(method, CancellationToken.None, parameters);
    }
    
    /// <summary>
    ///     Convenience method to invoke a JS function from the .NET logic component class.
    /// </summary>
    /// <param name="method">
    ///     The name of the JS function to call.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    /// <param name="parameters">
    ///     The collection of parameters to pass to the JS call.
    /// </param>
    internal virtual async Task<T> InvokeAsync<T>(string method, CancellationToken cancellationToken, params object?[] parameters)
    {
        await Initialize(cancellationToken);
        
        object?[] parameterList = GenerateSerializedParameters(parameters);

        if (IsServer)
        {
            IJSStreamReference streamRef = await Component!.InvokeAsync<IJSStreamReference>(
                "invokeSerializedMethod", cancellationToken, [method, true, ..parameterList]);
            return (await streamRef.ReadJsStreamReference<T>())!;
        }

        return await Component!.InvokeAsync<T>(
            "invokeSerializedMethod", cancellationToken, [method, false, ..parameterList]);
    }
    
    private object?[] GenerateSerializedParameters(object?[] parameters)
    {
        return parameters.SelectMany(p => ProcessParameter(p)).ToArray();
    }
    
    /// <summary>
    ///     Returns the processed parameter Type and a Serialized or DotNetStreamReference of the serialized parameter value.
    /// </summary>
    /// <param name="parameter">
    ///     The original parameter to process.
    /// </param>
    /// <param name="nested">
    ///     True if the parameter is nested within a collection, false if it is a top-level parameter.
    /// </param>
    private object?[] ProcessParameter(object? parameter, bool nested = false)
    {
        if (parameter is null)
        {
            return ["null", null];
        }
        
        Type paramType = parameter.GetType();

        if (_simpleTypes.Contains(paramType))
        {
            return [paramType.Name, parameter];
        }
        
        if (parameter is ICollection collection)
        {
            List<object?> items = [];
            foreach (object? item in collection)
            {
                items.Add(ProcessParameter(item, true));
            }

            if (items.All(i => i is GraphicSerializationRecord))
            {
                ProtoGraphicCollection protoGraphicCollection = new(items.Cast<GraphicSerializationRecord>().ToArray());
                return [nameof(ProtoGraphicCollection), 
                    nested ? protoGraphicCollection : GenerateProtobufParameter(protoGraphicCollection)];
            }
            
            return ["Array", nested ? items : GenerateJsonParameter(items)];
        }
        if (parameter is IProtobufSerializable protobufSerializable)
        {
            MapComponentSerializationRecord protoRecord = protobufSerializable.ToProtobuf();
            return [GetProtoContractName(protoRecord), nested ? protoRecord : GenerateProtobufParameter(protoRecord)];
        }
        if (parameter is IProtobufArraySerializable protobufArraySerializable)
        {
            MapComponentSerializationRecord[] protoArray = protobufArraySerializable.ToProtobufArray();
            return [GetProtoContractName(protoArray), nested ? protoArray : GenerateProtobufParameter(protoArray)];
        }

        return [parameter.GetType().Name, nested ? parameter : GenerateJsonParameter(parameter)];
    }
    
    private object GenerateProtobufParameter(object obj)
    {
        MemoryStream memoryStream = new();
        Serializer.Serialize(memoryStream, obj);
        memoryStream.Seek(0, SeekOrigin.Begin);
        
        if (IsServer)
        {
            return new DotNetStreamReference(memoryStream);   
        }

        byte[] data = memoryStream.ToArray();
        memoryStream.Dispose();

        return data;
    }
    
    private object GenerateJsonParameter(object obj)
    {
        if (IsServer)
        {
            MemoryStream memoryStream = new();
            JsonSerializer.Serialize(memoryStream, obj, GeoBlazorSerialization.JsonSerializerOptions);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return new DotNetStreamReference(memoryStream);   
        }
        
        return JsonSerializer.Serialize(obj, GeoBlazorSerialization.JsonSerializerOptions);
    }
    
    private string GetProtoContractName(object obj)
    {
        Type type = obj.GetType();
        ProtoContractAttribute? protoContract = type.GetCustomAttribute<ProtoContractAttribute>();
        if (protoContract?.Name is not null)
        {
            return protoContract.Name;
        }

        return type.Name.Replace("SerializationRecord", string.Empty);
    }

    private bool _validated;
    private readonly Type[] _simpleTypes =
    [
        typeof(string), typeof(char), typeof(bool), typeof(byte), typeof(sbyte), typeof(short),
        typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float),
        typeof(double), typeof(decimal), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan),
        typeof(Guid), typeof(DateOnly), typeof(TimeOnly)
    ];
    
    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </summary>
    protected bool IsServer => jsRuntime.GetType().Name.Contains("Remote");
}