namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     The result object returned from a suggest().
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SuggestResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Key">
///     The key related to the suggest result.
/// </param>
/// <param name="Text">
///     The key related to the suggest result.
/// </param>
/// <param name="SourceIndex">
///     The key related to the suggest result.
/// </param>
public record SuggestResult(string? Key, string? Text, int? SourceIndex);

/// <summary>
///     A collection of <see cref="SuggestResult"/>s
/// </summary>
/// <param name="Results">
///     The results of the suggest
/// </param>
/// <param name="Source">
///     The source of the suggest
/// </param>
/// <param name="SourceIndex">
///     The index of the source
/// </param>
public record SuggestResultResponse(SuggestResult[] Results, SearchSource Source, int SourceIndex);

