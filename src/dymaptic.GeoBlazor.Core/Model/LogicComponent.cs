using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

public abstract class LogicComponent
{
    public LogicComponent(IJSRuntime jsRuntime, IConfiguration configuration)
    {
        JsRuntime = jsRuntime;
        _apiKey = configuration["ArcGISApiKey"];
    }

    protected abstract string ComponentName { get; }

    protected IJSObjectReference? Component { get; set; }

    protected DotNetObjectReference<LogicComponent> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

    protected virtual string Library => "Core";

    [JSInvokable]
    public void OnJavascriptError(string error)
    {
        throw new JavascriptException(error);
    }

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

    protected readonly IJSRuntime JsRuntime;
    private readonly string? _apiKey;
}