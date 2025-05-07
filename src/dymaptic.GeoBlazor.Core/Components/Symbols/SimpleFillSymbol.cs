namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public partial class SimpleFillSymbol : FillSymbol
{


    /// <summary>
    ///     The fill style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleFillSymbolStyle? Style { get; set; }

    /// <inheritdoc />
    public override SymbolType Type => SymbolType.SimpleFill;

    /// <inheritdoc />
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
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), Color)
        {
            Outline = Outline?.ToSerializationRecord(), 
            Style = Style?.ToString().ToKebabCase()
        };
    }
}