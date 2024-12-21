namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The horizontal alignment for a text symbol's text.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<HorizontalAlignment>))]
public enum HorizontalAlignment
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Left,
    Right,
    Center
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}