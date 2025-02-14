namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class AreaMeasurement2DWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override WidgetType Type => WidgetType.AreaMeasurement2D;

    /// <summary>
    ///     A .NET object reference for calling this class from JavaScript.
    /// </summary>
    public DotNetObjectReference<AreaMeasurement2DWidget> AreaMeasurement2DWidgetObjectReference => DotNetObjectReference.Create(this);


}
