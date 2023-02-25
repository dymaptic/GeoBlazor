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
                // this is here to support the pro extension library
                IJSObjectReference proModule = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import",
                        "./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js");
                jsModule = await proModule.InvokeAsync<IJSObjectReference>("getCore");

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