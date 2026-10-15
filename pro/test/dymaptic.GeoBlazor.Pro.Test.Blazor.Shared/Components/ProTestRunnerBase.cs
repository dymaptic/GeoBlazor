using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

public class ProTestRunnerBase: TestRunnerBase
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        IJSObjectReference proJs = (await JsModuleManager.GetProJsModule(JsRuntime, default))!;
        if (_proJsObjectReference == null)
        {
            _proJsObjectReference = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/dymaptic.GeoBlazor.Pro.Test.Blazor.Shared/proTestRunner.js");
            await _proJsObjectReference.InvokeVoidAsync("initialize", proJs);
        }
    }
    
    protected async Task AssertProJavaScript(string jsAssertFunction, 
        [CallerMemberName] string methodName = "", params object[] args)
    {
        List<object> jsArgs = [methodName];

        jsArgs.AddRange(args);
        if (jsAssertFunction.Contains("."))
        {
            string[] parts = jsAssertFunction.Split('.');
            IJSObjectReference module = await JsRuntime.InvokeAsync<IJSObjectReference>("import", 
                $"./_content/dymaptic.GeoBlazor.Pro.Test.Blazor.Shared/{parts[0]}.js");
            await module.InvokeVoidAsync(parts[1], jsArgs.ToArray());
        }
        else
        {
            await _proJsObjectReference!.InvokeVoidAsync(jsAssertFunction, jsArgs.ToArray());    
        }
    }

    private IJSObjectReference? _proJsObjectReference;
}