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
    
    /// <summary>
    ///     Retrieves or creates a JavaScript wrapper for a logic component.
    /// </summary>
    /// <param name="jsRuntime">The JS runtime to use for module loading.</param>
    /// <param name="componentName">The name of the logic component (e.g., "geometryEngine").</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A JavaScript object reference to the component wrapper.</returns>
    public async ValueTask<IJSObjectReference> GetLogicComponent(IJSRuntime jsRuntime, string componentName,
        CancellationToken cancellationToken)
    {
        IJSObjectReference? proModule = await GetProJsModule(jsRuntime, cancellationToken);
        IJSObjectReference coreModule = await GetCoreJsModule(jsRuntime, proModule, cancellationToken);

        return await coreModule.InvokeAsync<IJSObjectReference>($"get{componentName.ToUpperFirstChar()}Wrapper",
            cancellationToken);
    }

    private IJSObjectReference? _proModule;
    private IJSObjectReference? _coreModule;
    private bool _proChecked;
    private readonly string _version = Assembly.GetAssembly(typeof(JsModuleManager))!
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
        .InformationalVersion;
}