namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The current tool in the <see cref="SketchEvent"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchEventTool>))]
public enum SketchEventTool
{
#pragma warning disable CS1591
    Point,
    Polyline,
    Polygon,
    Rectangle,
    Circle,
    Move,
    Reshape,
    Transform
#pragma warning restore CS1591
}