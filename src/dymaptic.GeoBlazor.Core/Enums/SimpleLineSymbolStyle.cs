namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible line style values for <see cref="SimpleLineSymbol" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SimpleLineSymbolStyle>))]
public enum SimpleLineSymbolStyle
{
#pragma warning disable CS1591
    Solid,
    Dash,
    DashDot,
    Dot,
    LongDash,
    LongDashDot,
    LongDashDotDot,
    ShortDash,
    ShortDashDot,
    ShortDashDotDot,
    ShortDot,
    None
#pragma warning restore CS1591
}