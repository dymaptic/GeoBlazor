using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     WCS presents raster data from a OGC Web Coverage Service. Raster data are projected and rendered on the client-side.
///     It supports versions 1.0.0, 1.1.0, 1.1.1, 1.1.2 and 2.0.1. For version 2.0.1, it supports servers that support 
///     GEOTIFF coverage and implements the following extensions: Scaling, Interpolation, Range Subsetting, CRS, and KVP/Get.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class WCSLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string? LayerType => "wcs";

    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public WCSLayer()
    {
    }
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The url for the WCS Layer source data.
    /// </param>

    public WCSLayer(string? url = null, PortalItem? portalItem = null)
    {
        if (url is null && portalItem is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(WCSLayer),
                new[] {nameof(Url), nameof(PortalItem)});
        }
        Url = url;
        PortalItem = portalItem;
    }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item for the KML Layer source data.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }

    public DimensionalDefinition? MultidimensionalDefinition { get; set; }
    public RasterStretchRenderer Renderers { get; set; }
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
            case DimensionalDefinition dimensionalDefinition:
                if (!dimensionalDefinition.Equals(MultidimensionalDefinition))
                {
                    MultidimensionalDefinition = dimensionalDefinition;
                    LayerChanged = true;
                }
                break;
            case RasterStretchRenderer rasterStretchRenderer:
                if (!rasterStretchRenderer.Equals(Renderers))
                {
                    Renderers = rasterStretchRenderer;
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
            case DimensionalDefinition _:
                MultidimensionalDefinition = null;
                LayerChanged = true;
                break;
            case RasterStretchRenderer _:
                Renderers = null;
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
        PortalItem?.ValidateRequiredChildren();
        MultidimensionalDefinition?.ValidateRequiredChildren();
        Renderers?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }


}
