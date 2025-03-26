namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     An object that is passed as a parameter to get search suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetSuggestionsParameters">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="maxSuggestions">
///     Indicates the maximum number of suggestions to return for the widget's input.
/// </param>
/// <param name="sourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="spatialReference">
///     Indicates the Spatial Refeference defined by the source.
/// </param>
/// <param name="suggestTerm">
///     Indicates search term used to find a suggestion.
/// </param>
/// <param name="viewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
/// <returns>
///     An array of suggestions.
/// </returns>
[CodeGenerationIgnore]
public delegate Task<IReadOnlyList<SuggestResult>> GetSuggestionsHandler(int? maxSuggestions, int? sourceIndex, 
    SpatialReference? spatialReference, string? suggestTerm, Guid? viewId);

