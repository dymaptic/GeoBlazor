namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     When resolved, returns this response after calling search.
/// </summary>
/// <param name = "ActiveSourceIndex">
///     The index of the source from which the search result was obtained.
/// </param>
/// <param name = "Errors">
///     An array of error objects returned from the search results.
/// </param>
/// <param name = "NumResults">
///     The number of search results.
/// </param>
/// <param name = "SearchTerm">
///     The searched expression.
/// </param>
/// <param name = "Results">
///     An array of objects representing the results of the search.
/// </param>
public record SearchResponse(int ActiveSourceIndex, JavascriptError[] Errors, int NumResults, string SearchTerm, SearchResultResponse[] Results);