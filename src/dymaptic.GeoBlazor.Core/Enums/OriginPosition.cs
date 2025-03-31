namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The integer's coordinates will be returned relative to the origin position defined by this property value.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<OriginPosition>))]
public enum OriginPosition
{
#pragma warning disable CS1591
    UpperLeft,
    LowerLeft
#pragma warning restore CS1591
}