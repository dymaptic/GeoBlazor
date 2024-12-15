using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Name of the default drawing tool defined for the template to create a feature.
/// </summary>
[JsonConverter(typeof(DrawingToolStringConverter))]
public enum DrawingTool
{
#pragma warning disable CS1591
    AutoCompletePolygon,
    Circle,
    Ellipse,
    Freehand,
    Line,
    None,
    Point,
    Polygon,
    Rectangle,
    Arrow,
    Triangle,
    LeftArrow,
    RightArrow,
    UpArrow,
    DownArrow
#pragma warning restore CS1591
}