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
    [CodeGenerationIgnore]
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type.ToString().ToKebabCase(), Color)
        {
            Outline = Outline?.ToSerializationRecord(),
            Size = Size?.Points,
            Style = Style?.ToString().ToKebabCase(),
            Angle = Angle,
            Xoffset = Xoffset?.Points,
            Yoffset = Yoffset?.Points
        };
    }
}