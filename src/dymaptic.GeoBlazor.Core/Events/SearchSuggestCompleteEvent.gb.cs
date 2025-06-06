// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Events.SearchSuggestCompleteEvent.html">GeoBlazor Docs</a>
///     Event result type for the SearchWidget.OnSuggestComplete event.
/// </summary>
/// <param name="ActiveSourceIndex">
/// </param>
/// <param name="Errors">
/// </param>
/// <param name="NumResults">
/// </param>
/// <param name="Results">
/// </param>
/// <param name="SearchTerm">
/// </param>
public partial record SearchSuggestCompleteEvent(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? ActiveSourceIndex = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<Error>? Errors = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? NumResults = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<SearchSuggestCompleteEventResults>? Results = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? SearchTerm = null);
