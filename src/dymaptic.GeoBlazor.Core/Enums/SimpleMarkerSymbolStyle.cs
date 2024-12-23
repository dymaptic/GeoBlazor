namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The marker style.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SimpleMarkerSymbolStyle>))]
public enum SimpleMarkerSymbolStyle
{
#pragma warning disable CS1591
    Circle,
    Square,
    Cross,
    X,
    Diamond,
    Triangle,
    Path
#pragma warning restore CS1591
}