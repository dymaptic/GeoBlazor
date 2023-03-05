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
    public async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;

        if (JsObjectReference is not null)
        {
            await JsObjectReference.InvokeVoidAsync("setSymbol", 
                Symbol.ToSerializationRecord());
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:
                if (View?.ExtentChangedInJs == true)
                {
                    return;
                }
                
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
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
    }
    
    protected IJSObjectReference? JsObjectReference = null!;
}