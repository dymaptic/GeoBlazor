namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     A collection of <see cref="SearchResult"/>s for each <see cref="SearchSource"/>
/// </summary>
/// <param name="Results">
///     The results of the search
/// </param>
/// <param name="Source">
///     The source of the search
/// </param>
/// <param name="SourceIndex">
///     The index of the source
/// </param>
public record SearchResultResponse(SearchResult[] Results, SearchSource Source, int SourceIndex);