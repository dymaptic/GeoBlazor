namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     An object that is passed as a parameter to get search suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetSuggestionsParameters">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name = "MaxSuggestions">
///     Indicates the maximum number of suggestions to return for the widget's input.
/// </param>
/// <param name = "SourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name = "SpatialReference">
///     Indicates the Spatial Refeference defined by the source.
/// </param>
/// <param name = "SuggestTerm">
///     Indicates search term used to find a suggestion.
/// </param>
/// <param name = "ViewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
public record GetSuggestionsParameters(int? MaxSuggestions, int? SourceIndex, SpatialReference? SpatialReference, string? SuggestTerm, Guid? ViewId);
