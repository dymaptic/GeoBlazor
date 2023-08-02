using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
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
    public override string LayerType => "wcs";

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

    /// <summary>
    ///     The multidimensional definitions associated with the layer.
    /// </summary>
    public List<DimensionalDefinition>? MultidimensionalDefinition { get; set; }

    public string? Title { get; set; }

    /// <summary>
    ///     The renderer assigned to the layer. The renderer defines how to visualize pixels in the WCSLayer. 
    ///     Depending on the renderer type, the pixels may be stretched across the color ramp or classified.
    ///     Currently, only the RasterStretchRenderer has been implemented, ClassBreaksRenderer will be implemented
    ///     in the future.
    /// </summary>
    // Class Breaks renderer still needs to be added to this layer for a classified pixel render.
    public RasterStretchRenderer Renderer { get; set; }

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
                MultidimensionalDefinition ??= new List<DimensionalDefinition>();
                if (!MultidimensionalDefinition.Contains(dimensionalDefinition))
                {
                    MultidimensionalDefinition.Add(dimensionalDefinition);
                    LayerChanged = true;
                }
                break;
            case RasterStretchRenderer rasterStretchRenderer:
                if (!rasterStretchRenderer.Equals(Renderer))
                {
                    Renderer = rasterStretchRenderer;
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
                Renderer = null;
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
        if (MultidimensionalDefinition != null)
        {
            foreach (var definition in MultidimensionalDefinition)
            {
                definition.ValidateRequiredChildren();
            }
        }
        
        Renderer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }


}
