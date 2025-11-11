namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public partial class PictureFillSymbol : FillSymbol
{

    
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
    ///     The scale factor on the x axis of the symbol.
    ///     Default Value: 1
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? XScale { get; set; }
    
    /// <summary>
    ///     The scale factor on the y axis of the symbol.
    ///     Default Value: 1
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? YScale { get; set; }
    
    /// <summary>
    ///     The offset on the x-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Xoffset { get; set; }
    
    /// <summary>
    ///     The offset on the y-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Yoffset { get; set; }

    /// <inheritdoc />
    public override SymbolSerializationRecord ToProtobuf()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), null)
        {
            Url = Url,
            Width = Width?.Points,
            Height = Height?.Points,
            Xoffset = Xoffset?.Points,
            Yoffset = Yoffset?.Points,
            XScale = XScale,
            YScale = YScale,
            Outline = Outline?.ToProtobuf()
        };
    }
}