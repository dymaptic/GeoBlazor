namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     MapFontStyle enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<MapFontStyle>))]
public enum MapFontStyle
{
#pragma warning disable CS1591
    Normal,
    Italic,
    Oblique
#pragma warning restore CS1591
}