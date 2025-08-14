namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Base interface of common search result properties returned from the <see cref="SearchResults"/> and <see cref="SuggestResults"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-types.html#SearchResults">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Error">
///     The search error.
/// </param>
/// <param name="Source">
///     The search source.
/// </param>
/// <param name="SourceIndex">
///     The index.
/// </param>
public partial record BaseSearchResults(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Error? Error = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    SearchSource? Source = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? SourceIndex = null);