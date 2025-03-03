namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The tools included in the <see cref="SketchWidget"/> and <see cref="EditorWidget"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchTool>))]
public enum SketchTool
{
#pragma warning disable CS1591
    Point,
    Polyline,
    Polygon,
    Rectangle,
    Circle,
    Multipoint,
    Mesh,
    Move,
    Transform,
    Reshape,
    RectangleSelection,
    LassoSelection
#pragma warning restore CS1591
}