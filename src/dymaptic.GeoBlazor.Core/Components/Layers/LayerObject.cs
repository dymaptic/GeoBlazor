using dymaptic.GeoBlazor.Core.Components.Symbols;
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
    public async Task SetSymbol(Symbol symbol)
    {
        await RegisterChildComponent(symbol);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:
                if (!symbol.Equals(Symbol))
                {
                    Symbol = symbol;
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
            case Symbol _:
                Symbol = null;

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
        Symbol?.ValidateRequiredChildren();
    }
}