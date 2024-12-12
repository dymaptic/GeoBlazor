using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The active menu of the search widget.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SearchMenu>))]
public enum SearchMenu
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    None,
    Suggestion,
    Source,
    Warning
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}