using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     A collection of possible positions for setting a <see cref="Widget" /> or <see cref="CustomOverlay" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<OverlayPosition>))]
public enum OverlayPosition
{
#pragma warning disable CS1591
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Manual
#pragma warning restore CS1591
}