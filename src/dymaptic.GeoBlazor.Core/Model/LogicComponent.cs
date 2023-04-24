using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A base class for non-map components, such as GeometryEngine, Projection, etc.
/// </summary>
public abstract class LogicComponent : IDisposable
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="jsRuntime">
    ///     Injected JavaScript Runtime reference
    /// </param>
    /// <param name="configuration">
    ///     Injected configuration object
    /// </param>
    public LogicComponent(IJSRuntime jsRuntime, IConfiguration configuration)
    {
        JsRuntime = jsRuntime;
        ApiKey = configuration["ArcGISApiKey"];
    }

    /// <summary>
    ///     Implement this handler in your calling code to catch and handle Javascript errors.
    /// </summary>
    public Func<JavascriptException, Task>? OnJavascriptErrorHandler { get; set; }

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
    protected DotNetObjectReference<LogicComponent> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

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

        if (OnJavascriptErrorHandler is not null)
        {
            OnJavascriptErrorHandler?.Invoke(exception);
        }
        else
        {
            throw exception;
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
        if (Component is null)
        {
            IJSObjectReference module = await GetArcGisJsInterop();

            Component = await module.InvokeAsync<IJSObjectReference>($"get{ComponentName}Wrapper",
                CancellationTokenSource.Token, DotNetObjectReference, ApiKey);
        }

        await Component.InvokeVoidAsync(method, CancellationTokenSource.Token, parameters);
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
        if (Component is null)
        {
            IJSObjectReference module = await GetArcGisJsInterop();

            Component = await module.InvokeAsync<IJSObjectReference>($"get{ComponentName}Wrapper",
                CancellationTokenSource.Token, DotNetObjectReference, ApiKey);
        }

        return await Component.InvokeAsync<T>(method, CancellationTokenSource.Token, parameters);
    }

    private async Task<IJSObjectReference> GetArcGisJsInterop()
    {
        LicenseType licenseType = Licensing.GetLicenseType();

        switch ((int)licenseType)
        {
            case >= 100:
                // this is here to support the pro extension library
                IJSObjectReference proModule = await JsRuntime
                    .InvokeAsync<IJSObjectReference>("import", CancellationTokenSource.Token,
                        "./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js");

                return await proModule.InvokeAsync<IJSObjectReference>("getCore");
            default:
                return await JsRuntime
                    .InvokeAsync<IJSObjectReference>("import", CancellationTokenSource.Token,
                        "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");
        }
    }

    /// <summary>
    ///     The reference to the JS Runtime.
    /// </summary>
    protected readonly IJSRuntime JsRuntime;
    /// <summary>
    ///     The ArcGIS API Key.
    /// </summary>
    protected string? ApiKey { get; set; }

    /// <summary>
    ///     Creates a cancellation token to control external calls
    /// </summary>
    protected CancellationTokenSource CancellationTokenSource = new();
}