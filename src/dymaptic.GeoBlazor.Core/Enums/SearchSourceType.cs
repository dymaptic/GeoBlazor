namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of search source.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SearchSourceType>))]
public enum SearchSourceType
{
#pragma warning disable CS1591
    Locator,
    Layer
#pragma warning restore CS1591
}