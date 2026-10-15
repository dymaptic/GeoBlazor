namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Available Shapes for the PieChart Renderer
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PieChartShape>))]
public enum PieChartShape
{
#pragma warning disable CS1591
    Pie,
    Donut
#pragma warning restore CS1591
}