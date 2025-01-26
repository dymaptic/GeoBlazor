namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     The result object returned from a search.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record SearchResult
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

