using dymaptic.GeoBlazor.Core.Objects;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleMarkerSymbol is used for rendering 2D Point geometries with a simple shape and color in either a MapView or a SceneView. It may be filled with a solid color and have an optional outline, which is defined with a SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">ArcGIS JS API</a>
/// </summary>
public class SimpleMarkerSymbol : MarkerSymbol, IEquatable<SimpleMarkerSymbol>
{
    /// <summary>
    ///    Parameterless constructor for using as a razor component
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
    public SimpleMarkerSymbol(Outline? outline = null, MapColor? color = null, double? size = null,
        string? style = null)
    {
        Outline = outline;
        Color = color;
        Size = size;
        Style = style;
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
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                    await UpdateComponent();
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
    public bool Equals(SimpleMarkerSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Equals(Outline, other.Outline) && Nullable.Equals(Size, other.Size) && Style == other.Style &&
            Color == other.Color;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((SimpleMarkerSymbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Outline, Size, Style, Color);
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
}