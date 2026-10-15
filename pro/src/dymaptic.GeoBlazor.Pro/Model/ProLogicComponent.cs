namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Abstract base class for Logic Components in GeoBlazor Pro
/// </summary>
[CodeGenerationIgnore]
public abstract class ProLogicComponent: LogicComponent
{
    /// <summary>
    ///     Constructor for use by Dependency Injection. Use <see cref="DependencyExtension.AddGeoBlazorPro"/> in your startup code.
    /// </summary>
    protected ProLogicComponent(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, 
        IAppValidator appValidator, IJSRuntime jsRuntime) : base(authenticationManager)
    {
        JsModuleManager = jsModuleManager;
        _appValidator = appValidator;
        JsRuntime = jsRuntime;
    }
    
    /// <inheritdoc />
    protected override async Task<T> InvokeAsync<T>(string method, params object?[] parameters)
    {
        if (!_isLicensed)
        {
            await _appValidator.ValidateLicense();
            _isLicensed = true;
        }
        await Initialize();

        return await Component!.InvokeAsync<T>(method, parameters);
    }
    
    /// <inheritdoc />
    protected override async Task<T> InvokeAsync<T>(string method, CancellationToken cancellationToken, params object?[] parameters)
    {
        if (!_isLicensed)
        {
            await _appValidator.ValidateLicense();
            _isLicensed = true;
        }
        await Initialize();

        return await Component!.InvokeAsync<T>(method, cancellationToken, parameters);
    }

    /// <inheritdoc />
    public override async Task Initialize()
    {
        if (Component is null)
        {
            await AuthenticationManager.Initialize();
            IJSObjectReference proModule = (await JsModuleManager.GetProJsModule(JsRuntime, CancellationToken.None))!;
            Component = await proModule.InvokeAsync<IJSObjectReference>($"get{ComponentName}Wrapper",
                DotNetComponentReference);
        }
    }

    /// <summary>
    ///     The JSModuleManager instance
    /// </summary>
    protected readonly JsModuleManager JsModuleManager;
    private readonly IAppValidator _appValidator;
    
    /// <summary>
    ///     The IJSRuntime instance
    /// </summary>
    protected readonly IJSRuntime JsRuntime;
    private bool _isLicensed;
}