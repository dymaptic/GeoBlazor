namespace dymaptic.GeoBlazor.Core.Results;

public partial record SuggestResult;

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

