using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Legend widget describes the symbols used to represent layers in a map. All symbols and text used in this widget are configured in the Renderer of the layer. The legend will only display layers and sublayers that are visible in the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">ArcGIS JS API</a>
/// </summary>
public class LegendWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "legend";

    /// <summary>
    ///     Specifies a subset of the layers to display in the legend. This includes any basemap layers you want to be visible in the legend. If this property is not set, all layers in the map will display in the legend, including basemap layers if basemapLegendVisible is true.
    /// </summary>
    public HashSet<LayerInfo> LayerInfos { get; set; } = new();

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerInfo layerInfo:
                LayerInfos.Add(layerInfo);
                await UpdateComponent();
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
                await UpdateComponent();
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        foreach (LayerInfo layerInfo in LayerInfos)

        {
            layerInfo.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Specifies a layer to display in the legend.
/// </summary>
public class LayerInfo : MapComponent
{
    /// <summary>
    ///     Specifies a title for the layer to display above its symbols and descriptions. If no title is specified the service name is used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     A layer to display in the legend.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public Layer Layer { get; set; } = default!;
    
    /// <summary>
    ///     Only applicable if the layer is a MapImageLayer. The IDs of the MapImageLayer sublayers for which to display legend information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[]? SublayerIds { get; set; }
}