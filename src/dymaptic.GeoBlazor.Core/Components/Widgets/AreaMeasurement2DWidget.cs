namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class AreaMeasurement2DWidget : Widget, IMeasurementWidgetActiveWidget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override WidgetType Type => WidgetType.AreaMeasurement2D;
    
    /// <summary>
    ///      Parameter changed event callback for the ViewModel property.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<AreaMeasurement2DViewModel> ViewModelChanged { get; set; }
}
