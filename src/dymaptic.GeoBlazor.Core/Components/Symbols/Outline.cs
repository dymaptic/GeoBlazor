namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     A convenience subclass of <see cref="SimpleLineSymbol" /> for defining outlines of other symbols.
/// </summary>
public class Outline : SimpleLineSymbol
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Outline()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="color">
    ///     The color of the symbol.
    ///     default black
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="width">
    ///     The width of the symbol in points.
    ///     default 0.75
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbol.html#width">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     Specifies the line style.
    ///     default solid
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="cap">
    ///     Specifies the cap style.
    ///     default round
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#cap">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="join">
    ///     Specifies the join style.
    ///     default round
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#join">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="marker">
    ///     Specifies the color, style, and placement of a symbol marker on the line.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#marker">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="miterLimit">
    ///     Maximum allowed ratio of the width of a miter join to the line width.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#miterLimit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Outline(MapColor? color = null,
        Dimension? width = null,
        SimpleLineSymbolStyle? style = null,
        Cap? cap = null,
        Join? join = null,
        LineSymbolMarker? marker = null,
        double? miterLimit = null) : base(color, width, style, cap, join, marker, miterLimit)
    {
        AllowRender = false;
    }

    /// <summary>
    ///     Convenience constructor for creating an outline from a <see cref="SimpleLineSymbol" />.
    /// </summary>
    public Outline(SimpleLineSymbol symbol): base(symbol.Color, symbol.Width, symbol.Style, symbol.Cap, symbol.Join, 
        symbol.Marker, symbol.MiterLimit)
    {
        AllowRender = false;
    }
}

internal class OutlineConverter : JsonConverter<Outline>
{
    public override Outline? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<Outline>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, Outline value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}