using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Text symbols are used to define the graphic for displaying labels on a FeatureLayer, CSVLayer, Sublayer, and StreamLayer in a 2D MapView. Text symbols can also be used to define the symbol property of Graphic if the geometry type is Point or Multipoint. With this class, you may alter the color, font, halo, and other properties of the label graphic.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-TextSymbol.html">ArcGIS JS API</a>
/// </summary>
public class TextSymbol : Symbol, IEquatable<TextSymbol>
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public TextSymbol()
    {
    }

    /// <summary>
    ///    Constructor for use in code
    /// </summary>
    /// <param name="text">
    ///     The text string to display in the view.
    /// </param>
    /// <param name="color">
    ///     The color of the symbol.
    /// </param>
    /// <param name="haloColor">
    ///     The color of the text symbol's halo.
    /// </param>
    /// <param name="haloSize">
    ///     The size in points of the text symbol's halo.
    /// </param>
    /// <param name="font">
    ///     The <see cref="MapFont"/> used to style the text.
    /// </param>
    public TextSymbol(string text, MapColor? color = null, MapColor? haloColor = null, int? haloSize = null,
        MapFont? font = null)
    {
        Text = text;
        Color = color;
        HaloColor = haloColor;
        HaloSize = haloSize;
        Font = font;
    }
    
    /// <inheritdoc />
    public override string Type => "text";

    /// <summary>
    ///     The color of the text symbol's halo.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? HaloColor { get; set; }

    /// <summary>
    ///     The size in points of the text symbol's halo.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HaloSize { get; set; }
    
    /// <summary>
    ///     The text string to display in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>
    ///     The <see cref="MapFont"/> used to style the text.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapFont? Font { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MapFont mapFont:
                if (!mapFont.Equals(Font))
                {
                    Font = mapFont;
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
            case MapFont _:
                Font = null;

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
        Font?.ValidateRequiredChildren();
    }

    /// <inheritdoc />
    public bool Equals(TextSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Equals(HaloColor, other.HaloColor) && HaloSize == other.HaloSize && Text == other.Text &&
            Equals(Font, other.Font) && Equals(Color, other.Color);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((TextSymbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(HaloColor, HaloSize, Text, Font, Color);
    }

    /// <summary>
    ///     Compares two <see cref="TextSymbol"/> objects for equality.
    /// </summary>
    public static bool operator ==(TextSymbol? left, TextSymbol? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two <see cref="TextSymbol"/> objects for inequality.
    /// </summary>
    public static bool operator !=(TextSymbol? left, TextSymbol? right)
    {
        return !Equals(left, right);
    }
}