namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     When resolved, returns this response after calling suggest.
/// </summary>
/// <param name = "ActiveSourceIndex">
///     The index of the source from which the suggest result was obtained.
/// </param>
/// <param name = "Errors">
///     An array of error objects returned from the suggest results.
/// </param>
/// <param name = "NumResults">
///     The number of suggest results.
/// </param>
/// <param name = "SuggestTerm">
///     The suggested expression.
/// </param>
/// <param name = "Results">
///     An array of objects representing the results of the suggest.
/// </param>
public record SuggestResponse(int ActiveSourceIndex, JavascriptError[] Errors, int NumResults, string SuggestTerm, SuggestResultResponse[] Results);