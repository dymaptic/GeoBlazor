using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Static class for managing the JavaScript modules used by GeoBlazor.
/// </summary>
public static class JsModuleManager
{
    /// <summary>
    ///     Retrieves the main entry point for the GeoBlazor Core JavaScript module.
    /// </summary>
    public static async Task<IJSObjectReference> GetArcGisJsCore(IJSRuntime jsRuntime, IJSObjectReference? proModule, CancellationToken cancellationToken)
    {
        Version? version = System.Reflection.Assembly.GetAssembly(typeof(JsModuleManager))!.GetName().Version;

        IJSObjectReference core;

        if (proModule is null)
        {
            core = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import", cancellationToken, 
                        $"./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js?v={version}");
        }
        else
        {
            core = await proModule.InvokeAsync<IJSObjectReference>("getCore", cancellationToken);    
        }

        return core;
    }

    /// <summary>
    ///     Retrieves the main entry point for the optional GeoBlazor Pro JavaScript module.
    /// </summary>
    public static async Task<IJSObjectReference?> GetArcGisJsPro(IJSRuntime jsRuntime, CancellationToken cancellationToken)
    {
        Version? version = System.Reflection.Assembly.GetAssembly(typeof(JsModuleManager))!.GetName().Version;

        LicenseType licenseType = Licensing.GetLicenseType();

        switch ((int)licenseType)
        {
            case >= 100:
                
                return await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken,
                    $"./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js?v={version}");
            default:
                return null;
        }
    }
}