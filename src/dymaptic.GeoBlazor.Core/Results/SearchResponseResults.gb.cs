// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Results.SearchResponseResults.html">GeoBlazor Docs</a>
///     An array of objects representing the results of search.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResponse">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Results">
///     An array of search results.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResponse">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Source">
///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#sources">source</a> of the selected result.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResponse">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SourceIndex">
///     The index of the currently selected source.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResponse">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record SearchResponseResults(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<SearchResult>? Results = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    SearchSource? Source = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? SourceIndex = null);
