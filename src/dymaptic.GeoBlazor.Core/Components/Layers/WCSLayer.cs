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
public class WCSLayer
{
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
    ///     The url for the KML Layer source data.
    /// </param>
    public WCSLayer(string? url = null, PortalItem? portalItem = null)
    {
        if (url is null && portalItem is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(WCSLayer),
                new[] { nameof(Url), nameof(PortalItem) });
        }
#pragma warning disable BL0005
        Url = url;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public string? LayerType => "wcs";

    /// <summary>
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }


}
