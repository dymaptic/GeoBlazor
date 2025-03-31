namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     A collection of renderer types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RendererType>))]
public enum RendererType
{
#pragma warning disable CS1591
    Simple,
    UniqueValue,
    PieChart,
    ClassBreaks,
    Dictionary,
    DotDensity,
    Heatmap
#pragma warning restore CS1591
}