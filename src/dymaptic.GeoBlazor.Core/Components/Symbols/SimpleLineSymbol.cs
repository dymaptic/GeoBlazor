namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public partial class SimpleLineSymbol : LineSymbol
{

    
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

    /// <inheritdoc />
    public override SymbolSerializationRecord ToProtobuf()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), Color?.ToProtobuf())
        {
            Width = Width?.Points, 
            Style = Style?.ToString().ToKebabCase()
        };
    }
}