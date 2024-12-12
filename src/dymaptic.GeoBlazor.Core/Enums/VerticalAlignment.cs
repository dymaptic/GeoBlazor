using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The vertical alignment for a text symbol's text.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VerticalAlignment>))]
public enum VerticalAlignment
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Baseline,
    Top,
    Middle,
    Bottom
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}