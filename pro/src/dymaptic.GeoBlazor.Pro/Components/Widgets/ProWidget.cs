namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

/// <summary>
///     Abstract base class for Widgets in the GeoBlazor Pro library
/// </summary>
[CodeGenerationIgnore]
public abstract class ProWidget: Widget
{
    [Inject]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public IAppValidator? LicenseValidator { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (LicenseValidator is null)
            {
                throw new InvalidOperationException("LicenseValidator is not set.");
            }
            await LicenseValidator.ValidateLicense();
            _isLicensed = true;
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    /// <inheritdoc />
    protected override bool ShouldRender()
    {
        return _isLicensed;
    }

    private bool _isLicensed;
}