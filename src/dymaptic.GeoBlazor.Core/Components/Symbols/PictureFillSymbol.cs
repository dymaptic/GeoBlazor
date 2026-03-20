namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[ProtobufSerializable]
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
            Xscale = Xscale,
            Yscale = Yscale,
            Outline = Outline?.ToProtobuf()
        };
    }
}