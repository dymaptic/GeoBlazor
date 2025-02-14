namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class MeasurementWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Measurement;

    /// <summary>
    /// Specifies the current measurement tool to display.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActiveTool? ActiveTool { get; set; }


}