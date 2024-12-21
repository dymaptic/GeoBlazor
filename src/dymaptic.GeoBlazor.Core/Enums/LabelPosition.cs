namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Specifies the orientation of the label position of a polyline label.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LabelPosition>))]
public enum LabelPosition
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Curved,
    Parallel
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}