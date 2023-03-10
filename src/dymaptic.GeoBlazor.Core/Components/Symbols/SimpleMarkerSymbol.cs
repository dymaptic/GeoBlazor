using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleMarkerSymbol is used for rendering 2D Point geometries with a simple shape and color in either a MapView or a
///     SceneView. It may be filled with a solid color and have an optional outline, which is defined with a
///     SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class SimpleMarkerSymbol : MarkerSymbol, IEquatable<SimpleMarkerSymbol>
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public SimpleMarkerSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleMarkerSymbol in code with parameters
    /// </summary>
    /// <param name="outline">
    ///     The outline of the marker symbol.
    /// </param>
    /// <param name="color">
    ///     The color of the marker symbol.
    /// </param>
    /// <param name="size">
    ///     The size of the marker in points.
    /// </param>
    /// <param name="style">
    ///     The marker style.
    /// </param>
    /// <param name="angle">
    ///     The angle of the marker relative to the screen in degrees.
    /// </param>
    /// <param name="xOffset">
    ///     The offset on the x-axis in points.
    /// </param>
    /// <param name="yOffset">
    ///     The offset on the y-axis in points.
    /// </param>
    public SimpleMarkerSymbol(Outline? outline = null, MapColor? color = null, double? size = null,
        string? style = null, double? angle = null, double? xOffset = null, double? yOffset = null)
    {
        Outline = outline;
        Color = color;
        Size = size;
        Style = style;
        Angle = angle;
        XOffset = xOffset;
        YOffset = yOffset;
    }

    /// <summary>
    ///     Compares two SimpleMarkerSymbol objects for equality
    /// </summary>
    public static bool operator ==(SimpleMarkerSymbol? left, SimpleMarkerSymbol? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two SimpleMarkerSymbol objects for inequality
    /// </summary>
    public static bool operator !=(SimpleMarkerSymbol? left, SimpleMarkerSymbol? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    ///     The outline of the marker symbol.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }

    /// <summary>
    ///     The size of the marker in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <inheritdoc />
    public override string Type => "simple-marker";

    /// <summary>
    ///     The marker style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Style { get; set; }

    /// <inheritdoc />
    public bool Equals(SimpleMarkerSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;

        return Equals(Outline, other.Outline) &&
            Nullable.Equals(Size, other.Size) &&
            (Color == other.Color) &&
            StylesEqual(Style, other.Style);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != GetType()) return false;

        return Equals((SimpleMarkerSymbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Outline, Size, Style, Color);
    }

    private bool StylesEqual(string? style1, string? style2)
    {
        if (style1 is null)
        {
            if (style2 is null || (style2 == "circle"))
            {
                return true;
            }

            return false;
        }

        if (style2 is null)
        {
            if (style1 == "circle")
            {
                return true;
            }

            return false;
        }

        return style1 == style2;
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SimpleMarkerSymbolSerializationRecord(
            Outline?.ToSerializationRecord() as SimpleLineSymbolSerializationRecord,
            Color, Size, Style, Angle, XOffset, YOffset);
    }
}

internal record SimpleMarkerSymbolSerializationRecord(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]SimpleLineSymbolSerializationRecord? Outline = null, 
    MapColor? Color = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Size = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]string? Style = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Angle = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? XOffset = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? YOffset = null)
    : SymbolSerializationRecord("simple-marker", Color);