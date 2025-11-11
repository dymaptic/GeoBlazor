namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public partial class SimpleMarkerSymbol : MarkerSymbol
{


    /// <summary>
    ///     The size of the marker in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }

    /// <inheritdoc />
    public override SymbolType Type => SymbolType.SimpleMarker;

    /// <summary>
    ///     The marker style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleMarkerSymbolStyle? Style { get; set; }

    /// <inheritdoc />
    public override SymbolSerializationRecord ToProtobuf()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), Color?.ToProtobuf())
        {
            Outline = Outline?.ToProtobuf(),
            Size = Size?.Points,
            Style = Style?.ToString().ToKebabCase(),
            Angle = Angle,
            Xoffset = Xoffset?.Points,
            Yoffset = Yoffset?.Points
        };
    }
}