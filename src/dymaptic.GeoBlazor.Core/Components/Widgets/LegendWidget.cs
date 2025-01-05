namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Legend widget describes the symbols used to represent layers in a map. All symbols and text used in this widget
///     are configured in the Renderer of the layer. The legend will only display layers and sublayers that are visible in
///     the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LegendWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Legend;

    /// <summary>
    ///     Specifies a subset of the layers to display in the legend. This includes any basemap layers you want to be visible
    ///     in the legend. If this property is not set, all layers in the map will display in the legend, including basemap
    ///     layers if basemapLegendVisible is true.
    /// </summary>
    public List<LayerInfo> LayerInfos { get; set; } = new();

    /// <summary>
    /// Indicates the style of the legend. The style determines the legend's layout and behavior.
    /// You can either specify a string or an object to indicate the style.
    /// The known string values are the same values listed in the table within the type property.
    /// <a target="_blank" href=" https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public LegendStyle? Style { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerInfo layerInfo:
                LayerInfos.Add(layerInfo);

                break;
            case LegendStyle style:
                Style = style;

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerInfo layerInfo:
                LayerInfos.Remove(layerInfo);

                break;
            case LegendStyle:
                Style = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        foreach (LayerInfo layerInfo in LayerInfos)

        {
            layerInfo.ValidateRequiredChildren();
        }

        Style?.ValidateRequiredChildren();

        base.ValidateRequiredChildren();
    }
}

