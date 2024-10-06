using dymaptic.GeoBlazor.Core.Components.Symbols;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Abstract base class for objects that are a child of a <see cref="Layer" /> and have a <see cref="Symbol" />
///     property.
/// </summary>
public abstract class LayerObject : MapComponent
{
    /// <summary>
    ///     The <see cref="Symbol" /> for the object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public Symbol? Symbol { get; protected set; }

    /// <summary>
    ///     Gets the current <see cref="Symbol" /> for the object.
    /// </summary>
    public virtual async Task<Symbol?> GetSymbol()
    {
        return await Task.Run(() => Symbol);
    }

    /// <summary>
    ///     Sets the <see cref="Symbol" /> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref="Symbol" /> for the object.
    /// </param>
    public virtual async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol",
                Id, Symbol.ToSerializationRecord());
        }
        else
        {
            UpdateSymbol = true;
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:

                await SetSymbol(symbol);

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
            case Symbol _:
                Symbol = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
    }

    /// <summary>
    ///     Indicates whether the symbol should be updated on the next render cycle.
    /// </summary>
    protected bool UpdateSymbol;
}