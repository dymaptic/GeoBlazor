using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The result object returned from a search.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResult">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class SearchResult
{
    /// <summary>
    ///     The extent, or bounding box, of the returned feature. The value depends on the data source, with higher quality
    ///     data sources returning extents closer to the feature obtained from the search.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }

    /// <summary>
    ///     The resulting feature or location obtained from the search.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Graphic? Feature { get; set; }

    /// <summary>
    ///     The name of the result.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}