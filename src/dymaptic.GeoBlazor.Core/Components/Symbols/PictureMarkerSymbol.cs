namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public partial class PictureMarkerSymbol : MarkerSymbol
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
    public override SymbolType Type => SymbolType.PictureMarker;


    /// <inheritdoc />
    public override SymbolSerializationRecord ToProtobuf()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), null)
        {
            Url = Url,
            Width = Width?.Points,
            Height = Height?.Points,
            Angle = Angle,
            Xoffset = Xoffset?.Points,
            Yoffset = Yoffset?.Points
        };
    }
}