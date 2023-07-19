using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A collection of possible positions for setting a <see cref="Widget" /> or <see cref="CustomOverlay" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ActiveTool>))]
public enum ActiveTool
{
#pragma warning disable CS1591
    Area,
    Distance,
    DirectLine
#pragma warning restore CS1591
}