namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A base class for non-map components, such as GeometryEngine, Projection, etc.
/// </summary>
public abstract class LogicComponent : IDisposable
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    protected LogicComponent(AuthenticationManager authenticationManager)
    {
        AuthenticationManager = authenticationManager;
    }

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
    ///     Disposes of the Logic Component and cancels all external calls
    /// </summary>
    public void Dispose()
    {
        CancellationTokenSource.Dispose();
    }

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
    public virtual async Task Initialize()
    {
        if (Component is null)
        {
            await AuthenticationManager.Initialize();
            IJSObjectReference module = await AuthenticationManager.GetArcGisJsInterop();

            Component = await module.InvokeAsync<IJSObjectReference>($"get{ComponentName}Wrapper",
                CancellationTokenSource.Token, DotNetComponentReference);
        }
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
    protected virtual async Task InvokeVoidAsync(string method, params object?[] parameters)
    {
        await Initialize();

        await Component!.InvokeVoidAsync(method, CancellationTokenSource.Token, parameters);
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
    protected virtual async Task<T> InvokeAsync<T>(string method, params object?[] parameters)
    {
        await Initialize();

        return await Component!.InvokeAsync<T>(method, CancellationTokenSource.Token, parameters);
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
    protected virtual async Task<T> InvokeAsync<T>(string method, CancellationToken cancellationToken, params object?[] parameters)
    {
        await Initialize();

        return await Component!.InvokeAsync<T>(method, cancellationToken, parameters);
    }
    
    /// <summary>
    ///    The reference to the Authentication Manager.
    /// </summary>
    protected readonly AuthenticationManager AuthenticationManager;

    /// <summary>
    ///     Creates a cancellation token to control external calls
    /// </summary>
    protected readonly CancellationTokenSource CancellationTokenSource = new();
}