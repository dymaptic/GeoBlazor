namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Decoration enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TextDecoration>))]
public enum TextDecoration
{
#pragma warning disable CS1591
    Underline,
    LineThrough,
    None
#pragma warning restore CS1591
}