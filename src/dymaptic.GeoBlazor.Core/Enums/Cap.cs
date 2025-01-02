namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Cap enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Cap>))]
public enum Cap
{
#pragma warning disable CS1591
    Butt,
    Round,
    Square
#pragma warning restore CS1591
}