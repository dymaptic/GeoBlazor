using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core;

internal static class JsModuleManager
{
    public static async Task<IJSObjectReference> GetJsModule(IJSRuntime jsRuntime)
    {
        LicenseType licenseType = Licensing.GetLicenseType();
        IJSObjectReference jsModule;
        switch ((int)licenseType)
        {
            case >= 100:
                // this is here to support the interactive extension library
                IJSObjectReference interactiveModule = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import",
                        "./_content/dymaptic.GeoBlazor.Interactive/js/arcGisInteractive.js");
                jsModule = await interactiveModule.InvokeAsync<IJSObjectReference>("getCore");

                break;
            default:
                jsModule = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import",
                        "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");

                break;
        }

        return jsModule;
    }
}