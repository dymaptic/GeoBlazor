namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Legend widget describes the symbols used to represent layers in a map. All symbols and text used in this widget are configured in the Renderer of the layer. The legend will only display layers and sublayers that are visible in the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">ArcGIS JS API</a>
/// </summary>
public class LegendWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "legend";
}