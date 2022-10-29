using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A base class for non-map components, such as GeometryEngine, Projection, etc.
/// </summary>
public abstract class LogicComponent
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
        _apiKey = configuration["ArcGISApiKey"];
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
    protected DotNetObjectReference<LogicComponent> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

    /// <summary>
    ///     The project library which houses this particular logic component.
    /// </summary>
    protected virtual string Library => "Core";

    /// <summary>
    ///     A JavaScript invokable method that returns a JS Error and converts it to an Exception.
    /// </summary>
    /// <param name="message">
    ///     The JavaScript error message.
    /// </param>
    /// <param name="name">
    ///     The name of the JavaScript error.
    /// </param>
    /// <param name="stack">
    ///     The JavaScript stack trace.
    /// </param>
    /// <exception cref="JavascriptException">
    ///     The converted error to exception.
    /// </exception>
    [JSInvokable]
    public void OnJavascriptError(string message, string name = "", string stack = "")
    {
        var exception = new JavascriptException(message, name, stack);

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
    ///     Implement this handler in your calling code to catch and handle Javascript errors.
    /// </summary>
    public Func<JavascriptException, Task>? OnJavascriptErrorHandler { get; set; }

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
            Component = await JsRuntime
                .InvokeAsync<IJSObjectReference>("import",
                    $"./_content/dymaptic.GeoBlazor.{Library}/js/{ComponentName}.js");
            await Component.InvokeVoidAsync("initialize", DotNetObjectReference, _apiKey);
        }

        await Component.InvokeVoidAsync(method, parameters);
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
            Component = await JsRuntime
                .InvokeAsync<IJSObjectReference>("import",
                    $"./_content/dymaptic.GeoBlazor.{Library}/js/{ComponentName}.js");
            await Component.InvokeVoidAsync("initialize", DotNetObjectReference, _apiKey);
        }

        return await Component.InvokeAsync<T>(method, parameters);
    }

    /// <summary>
    ///     The reference to the JS Runtime.
    /// </summary>
    protected readonly IJSRuntime JsRuntime;
    private readonly string? _apiKey;
}