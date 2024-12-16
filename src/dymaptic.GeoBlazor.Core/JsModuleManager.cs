namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Static class for managing the JavaScript modules used by GeoBlazor.
/// </summary>
public class JsModuleManager
{
    /// <summary>
    ///     Retrieves the main entry point for the GeoBlazor Core JavaScript module.
    /// </summary>
    public async ValueTask<IJSObjectReference> GetArcGisJsCore(IJSRuntime jsRuntime, IJSObjectReference? proModule, CancellationToken cancellationToken)
    {
        if (_coreModule is null)
        {
            if (proModule is null)
            {
                Version? version = System.Reflection.Assembly.GetAssembly(typeof(JsModuleManager))!.GetName().Version;
                _coreModule = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import", cancellationToken, 
                        $"./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js?v={version}");
            }
            else
            {
                _coreModule = await proModule.InvokeAsync<IJSObjectReference>("getCore", cancellationToken);    
            }
        }

        return _coreModule;
    }

    /// <summary>
    ///     Retrieves the main entry point for the optional GeoBlazor Pro JavaScript module.
    /// </summary>
    public async ValueTask<IJSObjectReference?> GetArcGisJsPro(IJSRuntime jsRuntime, CancellationToken cancellationToken)
    {
        if (_proModule is null && !_proChecked)
        {
            Version? version = System.Reflection.Assembly.GetAssembly(typeof(JsModuleManager))!.GetName().Version;

            LicenseType licenseType = Licensing.GetLicenseType();

            switch ((int)licenseType)
            {
                case >= 100:
                
                    _proModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken,
                        $"./_content/dymaptic.GeoBlazor.Pro/js/arcGisPro.js?v={version}");
                    break;
                default:
                    _proChecked = true;
                    return null;
            }
        }

        return _proModule;
    }
    
    private IJSObjectReference? _proModule;
    private IJSObjectReference? _coreModule;
    private bool _proChecked;
}