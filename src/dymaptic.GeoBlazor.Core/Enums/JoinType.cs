namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Join types for creating an offset geometry in <see cref="GeometryEngine" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<JoinType>))]
public enum JoinType
{
#pragma warning disable CS1591
    Round,
    Bevel,
    Miter,
    Square
#pragma warning restore CS1591
}