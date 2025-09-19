namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A container for placing custom html or Razor Components on top of the Map View.
/// </summary>
[CodeGenerationIgnore]
public class CustomOverlay: Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.CustomOverlay;

    /// <inheritdoc />
    protected override bool Hidden => true;
}