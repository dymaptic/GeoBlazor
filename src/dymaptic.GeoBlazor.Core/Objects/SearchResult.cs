using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Exceptions;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The result object returned from a search.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResult">ArcGIS Maps SDK for JavaScript</a>
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
    
    /// <summary>
    ///     The target of the result, which is a Graphic used for either MapView goTo() or SceneView goTo() navigation.
    /// </summary>
    public Graphic? Target { get; set; }
}

/// <summary>
///     A collection of <see cref="SearchResult"/>s for each <see cref="SearchSource"/>
/// </summary>
/// <param name="Results">
///     The results of the search
/// </param>
/// <param name="Source">
///     The source of the search
/// </param>
/// <param name="SourceIndex">
///     The index of the source
/// </param>
public record SearchResultResponse(SearchResult[] Results, SearchSource Source, int SourceIndex);

/// <summary>
///     When resolved, returns this response after calling search.
/// </summary>
/// <param name="ActiveSourceIndex">
///     The index of the source from which the search result was obtained.
/// </param>
/// <param name="Errors">
///     An array of error objects returned from the search results.
/// </param>
/// <param name="NumResults">
///     The number of search results.
/// </param>
/// <param name="SearchTerm">
///     The searched expression.
/// </param>
/// <param name="Results">
///     An array of objects representing the results of the search.
/// </param>
public record SearchResponse(int ActiveSourceIndex, JavascriptError[] Errors, int NumResults, string SearchTerm, 
    SearchResultResponse[] Results);