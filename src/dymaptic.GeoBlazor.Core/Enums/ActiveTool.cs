namespace dymaptic.GeoBlazor.Core.Enums;

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