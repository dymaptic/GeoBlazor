using dymaptic.GeoBlazor.Core.Components.Symbols;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Abstract base class for objects that are a child of a <see cref="Layer"/> and have a <see cref="Symbol"/> property.
/// </summary>
public abstract class LayerObject : MapComponent
{
    /// <summary>
    ///     The <see cref="Symbol"/> for the object.
    /// </summary>
    [RequiredProperty]
    public Symbol? Symbol { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:
                if (!symbol.Equals(Symbol))
                {
                    Symbol = symbol;
                    await UpdateComponent();
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