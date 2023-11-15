using Microsoft.JSInterop;
#if NET7_0_OR_GREATER
using System.Runtime.InteropServices.JavaScript;
#endif

namespace dymaptic.GeoBlazor.Core;

internal static class JsModuleManager
{
    public static async Task<IJSObjectReference> GetArcGisJsCore(IJSRuntime jsRuntime, IJSObjectReference? proModule, CancellationToken cancellationToken)
    {
        LicenseType licenseType = Licensing.GetLicenseType();

        if (proModule is null)
        {
#if NET7_0_OR_GREATER
            if (OperatingSystem.IsBrowser())
            {
#pragma warning disable CA1416
                await JSHost.ImportAsync("arcGisJsInterop", "../_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");
#pragma warning restore CA1416
            }
#endif
            return await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import", cancellationToken, "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");
        }

        return await proModule.InvokeAsync<IJSObjectReference>("getCore");
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
                
#if NET7_0_OR_GREATER
                if (OperatingSystem.IsBrowser())
                {
        #pragma warning disable CA1416
                    await JSHost.ImportAsync("arcGisPro", "../_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js");
        #pragma warning restore CA1416
                }
#endif
                return await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken,
                    "./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js");
            default:
                return null;
        }
    }
}