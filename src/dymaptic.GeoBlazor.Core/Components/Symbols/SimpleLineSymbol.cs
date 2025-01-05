namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleLineSymbol is used for rendering 2D polyline geometries in a 2D MapView. SimpleLineSymbol is also used for
///     rendering outlines for marker symbols and fill symbols.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleLineSymbol : LineSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleLineSymbol()
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
    public SimpleLineSymbol(
        MapColor? color = null,
        Dimension? width = null,
        SimpleLineSymbolStyle? style = null,
        Cap? cap = null,
        Join? join = null,
        LineSymbolMarker? marker = null,
        double? miterLimit = null)
    {
#pragma warning disable BL0005
        Color = color;
        Width = width;
        Style = style;
        Cap = cap;
        Join = join;
        Marker = marker;
        MiterLimit = miterLimit;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc />
    public override SymbolType Type => SymbolType.SimpleLine;

    /// <summary>
    ///     Specifies the cap style.
    ///     default round
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#cap">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Cap? Cap { get; set; }
    
    /// <summary>
    ///     Specifies the join style.
    ///     default round
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#join">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Join? Join { get; set; }
    
    /// <summary>
    ///     Specifies the color, style, and placement of a symbol marker on the line.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#marker">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LineSymbolMarker? Marker { get; set; }
    
    /// <summary>
    ///     Maximum allowed ratio of the width of a miter join to the line width.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#miterLimit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MiterLimit { get; set; }
    
    /// <summary>
    ///     Specifies the line style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleLineSymbolStyle? Style { get; set; }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type.ToString().ToKebabCase(), Color)
        {
            Width = Width?.Points, 
            Style = Style?.ToString().ToKebabCase()
        };
    }
}