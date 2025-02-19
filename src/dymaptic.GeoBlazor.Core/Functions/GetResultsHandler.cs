namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     A function that is passed as a parameter to get search results.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetResultsHandler">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="exactMatch">
///     The key field used to find the result.
/// </param>
/// <param name="location">
///     The location value used by the Search.
/// </param>
/// <param name="maxResults">
///     Indicates the maximum number of search results to return.
/// </param>
/// <param name="sourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="spatialReference">
///     Indicates the Spatial Reference defined by the source.
/// </param>
/// <param name="suggestResult">
///     Indicates the Suggest Result that triggered the search for a result.
/// </param>
/// <param name="viewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
/// <returns>
///     A list of search results.
/// </returns>
[CodeGenerationIgnore]
public delegate Task<IReadOnlyList<SearchResult>> GetResultsHandler(bool? exactMatch, Point? location, int? maxResults, 
    int? sourceIndex, SpatialReference? spatialReference, SuggestResult suggestResult, Guid? viewId);

