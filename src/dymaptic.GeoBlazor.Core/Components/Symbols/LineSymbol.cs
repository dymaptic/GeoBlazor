namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public abstract partial class LineSymbol : Symbol
{
    /// <summary>
    ///     The width of the symbol in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public Dimension? Width { get; set; }
}