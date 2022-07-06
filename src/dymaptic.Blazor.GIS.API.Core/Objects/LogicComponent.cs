using dymaptic.Blazor.GIS.API.Core.Exceptions;
using Microsoft.JSInterop;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

public abstract class LogicComponent
{
    public LogicComponent(IJSRuntime jsRuntime)
    {
        JsRuntime = jsRuntime;
    }

    protected abstract string ComponentName { get; }

    protected IJSObjectReference? Component { get; set; }

    protected DotNetObjectReference<LogicComponent> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

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
                    $"./_content/dymaptic.Blazor.GIS.API.Core/{ComponentName}.js");
            await Component.InvokeVoidAsync("initialize", DotNetObjectReference);
        }

        await Component.InvokeVoidAsync(method, parameters);
    }

    protected virtual async Task<T> InvokeAsync<T>(string method, params object?[] parameters)
    {
        if (Component is null)
        {
            Component = await JsRuntime
                .InvokeAsync<IJSObjectReference>("import",
                    $"./_content/dymaptic.Blazor.GIS.API.Core/{ComponentName}.js");
            await Component.InvokeVoidAsync("initialize", DotNetObjectReference);
        }

        return await Component.InvokeAsync<T>(method, parameters);
    }

    protected readonly IJSRuntime JsRuntime;
}