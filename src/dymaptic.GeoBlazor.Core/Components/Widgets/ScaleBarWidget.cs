namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class ScaleBarWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.ScaleBar;

    /// <summary>
    ///     Units to use for the scale bar
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public ScaleUnit? Unit { get; set; }
}