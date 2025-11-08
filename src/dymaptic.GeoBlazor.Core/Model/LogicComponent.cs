namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A base class for non-map components, such as GeometryEngine, Projection, etc.
/// </summary>
public abstract class LogicComponent(IAppValidator appValidator, IJSRuntime jsRuntime, 
    JsModuleManager jsModuleManager, AuthenticationManager authenticationManager)
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

        await authenticationManager.Initialize();

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
        
        await Component!.InvokeVoidJsMethod(IsServer, method, CancellationToken.None, parameters);
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
        
        return await Component!.InvokeJsMethod<T>(IsServer, method, cancellationToken, parameters);
    }
    
    private bool _validated;
    
    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </summary>
    protected bool IsServer => jsRuntime.GetType().Name.Contains("Remote");
}