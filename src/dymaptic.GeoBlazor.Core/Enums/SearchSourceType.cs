namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of search source.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SearchSourceType>))]
public enum SearchSourceType
{
    Locator,
    Layer
}