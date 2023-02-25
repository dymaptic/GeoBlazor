using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     VectorTileLayer accesses cached tiles of data and renders it in vector format. It is similar to a WebTileLayer in
///     the context of caching; however, a WebTileLayer renders as a series of images, not vector data. Unlike raster
///     tiles, vector tiles can adapt to the resolution of their display device and can be restyled for multiple uses.
///     VectorTileLayer delivers styled maps while taking advantage of cached raster map tiles with vector map data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class VectorTileLayer : TileLayer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "vector-tile";
}