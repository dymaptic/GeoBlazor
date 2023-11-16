using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core;

internal static class JsModuleManager
{
    public static async Task<IJSObjectReference> GetArcGisJsCore(IJSRuntime jsRuntime, IJSObjectReference? proModule, CancellationToken cancellationToken)
    {
        if (proModule is null)
        {
            return await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import", cancellationToken, 
                        "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");
        }

        return await proModule.InvokeAsync<IJSObjectReference>("getCore", cancellationToken);
    }

    /// <summary>
    ///     Retrieves the main entry point for the optional GeoBlazor Pro JavaScript module.
    /// </summary>
    public static async Task<IJSObjectReference?> GetArcGisJsPro(IJSRuntime jsRuntime, CancellationToken cancellationToken)
    {
        LicenseType licenseType = Licensing.GetLicenseType();

        switch ((int)licenseType)
        {
            case >= 100:
                
                return await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken,
                    "./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js");
            default:
                return null;
        }
    }
}