namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     PictureFillSymbol uses an image in a repeating pattern to symbolize polygon features in a 2D MapView. A url must point to a valid image. In addition, the symbol can have an optional outline, which is defined by a SimpleLineSymbol. PictureFillSymbols may be applied to polygon features in a FeatureLayer or an individual Graphic.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-PictureFillSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class PictureFillSymbol : FillSymbol
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PictureFillSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The URL to an image or SVG document.
    /// </param>
    /// <param name="width">
    ///     The width of the image in points.
    /// </param>
    /// <param name="height">
    ///     The height of the image in points.
    /// </param>
    /// <param name="xOffset">
    ///     The offset on the x-axis in points.
    /// </param>
    /// <param name="yOffset">
    ///     The offset on the y-axis in points.
    /// </param>
    /// <param name="xScale">
    ///     The scale factor on the x axis of the symbol.
    ///     Default Value:1
    /// </param>
    /// <param name="yScale">
    ///     The scale factor on the y axis of the symbol.
    ///     Default Value:1
    /// </param>
    /// <param name="outline">
    ///     The outline of the polygon.
    /// </param>
    public PictureFillSymbol(string url, Dimension? width = null, Dimension? height = null,
        Dimension? xOffset = null, Dimension? yOffset = null, double? xScale = null, 
        double? yScale = null, Outline? outline = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Url = url;
        Width = width;
        Height = height;
        XOffset = xOffset;
        YOffset = yOffset;
        XScale = xScale;
        YScale = yScale;
        Outline = outline;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The height of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Height { get; set; }

    /// <summary>
    ///     The width of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Width { get; set; }

    /// <inheritdoc />
    public override SymbolType Type => SymbolType.PictureFill;

    /// <summary>
    ///     The URL to an image or SVG document.
    /// </summary>
    [Parameter]
    public string Url { get; set; } = default!;
    
    /// <summary>
    ///     The scale factor on the x axis of the symbol.
    ///     Default Value:1
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? XScale { get; set; }
    
    /// <summary>
    ///     The scale factor on the y axis of the symbol.
    ///     Default Value:1
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? YScale { get; set; }
    
    /// <summary>
    ///     The offset on the x-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? XOffset { get; set; }
    
    /// <summary>
    ///     The offset on the y-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? YOffset { get; set; }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type.ToString().ToKebabCase(), null)
        {
            Url = Url,
            Width = Width?.Points,
            Height = Height?.Points,
            XOffset = XOffset?.Points,
            YOffset = YOffset?.Points,
            XScale = XScale,
            YScale = YScale,
            Outline = Outline?.ToSerializationRecord()
        };
    }
}