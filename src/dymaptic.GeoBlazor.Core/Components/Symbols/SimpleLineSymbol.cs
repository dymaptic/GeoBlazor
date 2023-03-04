using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleLineSymbol is used for rendering 2D polyline geometries in a 2D MapView. SimpleLineSymbol is also used for
///     rendering outlines for marker symbols and fill symbols.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class SimpleLineSymbol : LineSymbol, IEquatable<SimpleLineSymbol>
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public SimpleLineSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleLineSymbol in code with parameters
    /// </summary>
    /// <param name="color">
    ///     The color of the line symbol.
    /// </param>
    /// <param name="width">
    ///     The width of the line symbol in points.
    /// </param>
    /// <param name="lineStyle">
    ///     The line style.
    /// </param>
    public SimpleLineSymbol(MapColor? color = null, double? width = null, LineStyle? lineStyle = null)
    {
        Color = color;
        Width = width;
        LineStyle = lineStyle;
    }

    /// <summary>
    ///     Compares two <see cref="SimpleLineSymbol" />s for equality
    /// </summary>
    public static bool operator ==(SimpleLineSymbol? left, SimpleLineSymbol? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two <see cref="SimpleLineSymbol" />s for inequality
    /// </summary>
    public static bool operator !=(SimpleLineSymbol? left, SimpleLineSymbol? right)
    {
        return !Equals(left, right);
    }

    /// <inheritdoc />
    public override string Type => "simple-line";

    /// <summary>
    ///     Specifies the line style.
    /// </summary>
    [JsonPropertyName("style")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public LineStyle? LineStyle { get; set; }

    /// <inheritdoc />
    public bool Equals(SimpleLineSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return (LineStyle == other.LineStyle) && (Color == other.Color);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((SimpleLineSymbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return LineStyle.GetHashCode();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SimpleLineSymbolSerializationRecord(Color, Width, LineStyle);
    }
}

internal record SimpleLineSymbolSerializationRecord(MapColor? Color = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Width = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]LineStyle? LineStyle = null)
    : SymbolSerializationRecord("simple-line", Color);

/// <summary>
///     Possible line style values for <see cref="SimpleLineSymbol" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LineStyle>))]
public enum LineStyle
{
#pragma warning disable CS1591
    Solid,
    ShortDot,
    Dash
#pragma warning restore CS1591
}