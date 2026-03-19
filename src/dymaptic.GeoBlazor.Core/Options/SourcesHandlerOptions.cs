namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     The returned options of the <see cref="SearchViewModel.IncludeDefaultSourcesFunction" /> event.
/// </summary>
/// <param name="Sources">
///     The collection of sources currently configured in the Search widget.
/// </param>
/// <param name="DefaultSources">
///     The collection of default sources for the Search widget.
/// </param>
public record SourcesHandlerOptions(
    SearchSource[] Sources,
    SearchSource[] DefaultSources
);