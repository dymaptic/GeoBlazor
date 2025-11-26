namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Static class for managing the JavaScript modules used by GeoBlazor.
/// </summary>
public class JsModuleManager
{
    /// <summary>
    ///     Retrieves the main entry point for the GeoBlazor Core JavaScript module.
    /// </summary>
    public async ValueTask<IJSObjectReference> GetCoreJsModule(IJSRuntime jsRuntime, IJSObjectReference? proModule, CancellationToken cancellationToken)
    {
        if (_coreModule is null)
        {
            if (proModule is null)
            {
                _coreModule = await jsRuntime
                    .InvokeAsync<IJSObjectReference>("import", cancellationToken, 
                        $"./_content/dymaptic.GeoBlazor.Core/js/geoBlazorCore.js?v={_version}");
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
    public async ValueTask<IJSObjectReference?> GetProJsModule(IJSRuntime jsRuntime, CancellationToken cancellationToken)
    {
        if (_proModule is null && !_proChecked)
        {
            LicenseType licenseType = Licensing.GetLicenseType();

            switch ((int)licenseType)
            {
                case >= 100:
                
                    _proModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken,
                        $"./_content/dymaptic.GeoBlazor.Pro/js/geoBlazorPro.js?v={_version}");
                    break;
                default:
                    _proChecked = true;
                    return null;
            }
        }

        return _proModule;
    }

    public async Task<IJSObjectReference?> GetLogicComponent(IJSRuntime jsRuntime, string moduleName,
        CancellationToken cancellationToken)
    {
        if (!_proChecked)
        {
            await GetArcGisJsPro(jsRuntime, cancellationToken);
        }

        if (_coreModule is null)
        {
            await GetArcGisJsCore(jsRuntime, _proModule, cancellationToken);
        }

        string modulePath = $"./_content/dymaptic.GeoBlazor.{(_proModule is null ? "Core" : "Pro")}/js/{moduleName}.js?v={_version}";
        IJSObjectReference module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationToken, modulePath);
        // load the default export class from the module
        return await _coreModule!.InvokeAsync<IJSObjectReference>("getDefaultClassInstanceFromModule", cancellationToken, module);
    }
    
    private IJSObjectReference? _proModule;
    private IJSObjectReference? _coreModule;
    private bool _proChecked;
    private readonly string _version = Assembly.GetAssembly(typeof(JsModuleManager))!
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
        .InformationalVersion;
}