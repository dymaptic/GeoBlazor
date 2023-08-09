using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Specifies the current measurement tool to display.
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