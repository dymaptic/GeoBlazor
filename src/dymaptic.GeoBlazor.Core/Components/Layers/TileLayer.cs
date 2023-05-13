using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The TileLayer allows you work with a cached map service exposed by the ArcGIS Server REST API and add it to a Map
///     as a tile layer. A cached service accesses tiles from a cache instead of dynamically rendering images. Because they
///     are cached, tiled layers render faster than MapImageLayers. To create an instance of TileLayer, you must reference
///     the URL of the cached map service.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class TileLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "tile";

    /// <summary>
    ///     The URL of the REST endpoint of the layer.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }
    
    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and lesser than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    LayerChanged = true;
                }

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
            case PortalItem _:
                PortalItem = null;
                LayerChanged = true;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
    }
}