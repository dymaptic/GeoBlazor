namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class AreaMeasurement2DWidget : Widget, IMeasurementWidgetActiveWidget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override WidgetType Type => WidgetType.AreaMeasurement2D;
}
