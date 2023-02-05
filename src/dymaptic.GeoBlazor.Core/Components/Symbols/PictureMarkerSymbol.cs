using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     PictureMarkerSymbol renders Point graphics in either a 2D MapView or 3D SceneView using an image. A url must point to a valid image. PictureMarkerSymbols may be applied to point features in a FeatureLayer or individual graphics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-PictureMarkerSymbol.html">ArcGIS JS API</a>
/// </summary>
public class PictureMarkerSymbol : MarkerSymbol, IEquatable<PictureMarkerSymbol>
{
    /// <summary>
    ///     The height of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Height { get; set; }

    /// <summary>
    ///     The width of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    /// <inheritdoc />
    public override string Type => "picture-marker";

    /// <summary>
    ///     The URL to an image or SVG document.
    /// </summary>
    [Parameter]
    public string Url { get; set; } = default!;

    /// <inheritdoc />
    public bool Equals(PictureMarkerSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Nullable.Equals(Height, other.Height) && Nullable.Equals(Width, other.Width) && Url == other.Url &&
            Color == other.Color;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((PictureMarkerSymbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Height, Width, Url, Color);
    }

    /// <summary>
    ///     Compares two PictureMarkerSymbols for equality
    /// </summary>
    public static bool operator ==(PictureMarkerSymbol? left, PictureMarkerSymbol? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two PictureMarkerSymbols for inequality
    /// </summary>
    public static bool operator !=(PictureMarkerSymbol? left, PictureMarkerSymbol? right)
    {
        return !Equals(left, right);
    }
}