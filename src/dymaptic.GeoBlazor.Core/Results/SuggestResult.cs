using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Objects;


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

/// <summary>
///     When resolved, returns this response after calling suggest.
/// </summary>
/// <param name="ActiveSourceIndex">
///     The index of the source from which the suggest result was obtained.
/// </param>
/// <param name="Errors">
///     An array of error objects returned from the suggest results.
/// </param>
/// <param name="NumResults">
///     The number of suggest results.
/// </param>
/// <param name="SuggestTerm">
///     The suggested expression.
/// </param>
/// <param name="Results">
///     An array of objects representing the results of the suggest.
/// </param>
public record SuggestResponse(int ActiveSourceIndex, JavascriptError[] Errors, int NumResults, string SuggestTerm, 
    SuggestResultResponse[] Results);