namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     LineSymbolMarkerStyle enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LineSymbolMarkerStyle>))]
public enum LineSymbolMarkerStyle
{
#pragma warning disable CS1591
    Arrow,
    Circle,
    Square,
    Diamond,
    Cross,
    X
#pragma warning restore CS1591
}