namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     An enum converter containing the string values representing the color ramp type.  Possible Values:"algorithmic"|"multipart"
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ColorRampType>))]
public enum ColorRampType
{
#pragma warning disable CS1591
    Algorithmic,
    Multipart
#pragma warning restore CS1591
}