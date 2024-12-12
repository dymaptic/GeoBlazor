using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The marker style.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SimpleMarkerStyle>))]
public enum SimpleMarkerStyle
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