namespace dymaptic.GeoBlazor.Core.Components;

public partial class UniqueValueInfo : MapComponent
{
    /// <summary>
    ///     Features with this value will be rendered with the given symbol.
    /// </summary>
    [Parameter]
    public string? Value { get; set; }

    /// <summary>
    ///     Describes the value represented by the symbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }


    /// <summary>
    ///     Gets the current <see cref = "Symbol"/> for the object.
    /// </summary>
    public virtual async Task<Symbol?> GetSymbol()
    {
        return await Task.Run(() => Symbol);
    }

    /// <summary>
    ///     Sets the <see cref = "Symbol"/> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref = "Symbol"/> for the object.
    /// </param>
    public virtual async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;
        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol", Id, Symbol.ToSerializationRecord());
        }
    }

}