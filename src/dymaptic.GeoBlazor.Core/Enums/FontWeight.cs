namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Weight enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FontWeight>))]
public enum FontWeight
{
#pragma warning disable CS1591
    Normal,
    Bold,
    Bolder,
    Lighter
#pragma warning restore CS1591
}