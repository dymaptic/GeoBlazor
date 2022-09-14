using dymaptic.Blazor.GIS.API.Core.Components.Symbols;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public abstract class LayerObject : MapComponent
{
    [RequiredComponent]
    public Symbol? Symbol { get; set; }

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
}