using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     The font used to display 2D text symbols and 3D text symbols. This class allows the developer to set the font's family, decoration, size, style, and weight properties. Take note of the "Known Limitations" for each property to understand how they differ depending on the layer type, and if you working with a MapView or SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html">ArcGIS JS API</a>
/// </summary>
public class MapFont : MapComponent, IEquatable<MapFont>
{
    /// <summary>
    ///     The font size in points.
    /// </summary>
    [Parameter]
    public int? Size { get; set; }
    
    /// <summary>
    ///     The font family of the text.
    /// </summary>
    [Parameter]
    public string? Family { get; set; }
    
    /// <summary>
    ///     The text style.
    /// </summary>
    [Parameter]
    [JsonPropertyName("style")]
    public string? FontStyle { get; set; }
    
    /// <summary>
    ///     The text weight.
    /// </summary>
    [Parameter]
    public string? Weight { get; set; }

    /// <inheritdoc />
    public bool Equals(MapFont? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Size == other.Size && Family == other.Family && FontStyle == other.FontStyle && Weight == other.Weight;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((MapFont)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Size, Family, FontStyle, Weight);
    }

    /// <summary>
    ///     Compares two MapFont objects for equality
    /// </summary>
    public static bool operator ==(MapFont? left, MapFont? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two MapFont objects for inequality
    /// </summary>
    public static bool operator !=(MapFont? left, MapFont? right)
    {
        return !Equals(left, right);
    }
}