namespace dymaptic.GeoBlazor.Core.Objects;


/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LayerSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The where clause specified for filtering suggests or search results.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
    
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}

/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LocatorSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}

/// <summary>
///     An object that is passed as a parameter to get search results.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetResultsHandler">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ExactMatch">
///     The key field used to find the result.
/// </param>
/// <param name="Location">
///     The location value used by the Search.
/// </param>
/// <param name="MaxResults">
///     Indicates the maximum number of search results to return.
/// </param>
/// <param name="SourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="SpatialReference">
///     Indicates the Spatial Reference defined by the source.
/// </param>
/// <param name="SuggestResult">
///     Indicates the Suggest Result that triggered the search for a result.
/// </param>
/// <param name="ViewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
public record GetResultsParameters(bool? ExactMatch, Point? Location, int? MaxResults, int? SourceIndex, 
    SpatialReference? SpatialReference, SuggestResult SuggestResult, Guid? ViewId);

/// <summary>
///     An object that is passed as a parameter to get search suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetSuggestionsParameters">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MaxSuggestions">
///     Indicates the maximum number of suggestions to return for the widget's input.
/// </param>
/// <param name="SourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="SpatialReference">
///     Indicates the Spatial Refeference defined by the source.
/// </param>
/// <param name="SuggestTerm">
///     Indicates search term used to find a suggestion.
/// </param>
/// <param name="ViewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
public record GetSuggestionsParameters(int? MaxSuggestions, int? SourceIndex, 
    SpatialReference? SpatialReference, string? SuggestTerm, Guid? ViewId);

