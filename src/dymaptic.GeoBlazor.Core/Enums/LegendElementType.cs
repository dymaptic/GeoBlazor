namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.LegendElementType.html">GeoBlazor Docs</a>
///     The type of legend element.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LegendElementType>))]
public enum LegendElementType
{
#pragma warning disable CS1591
    SymbolTable,
    ColorRamp,
    HeatmapRamp,
    OpacityRamp,
    SizeRamp
#pragma warning restore CS1591
}