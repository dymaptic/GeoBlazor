using dymaptic.Blazor.GIS.API.Core.Components.Layers;

namespace dymaptic.Blazor.GIS.API.Core.Components;

public class Basemap : MapComponent
{
    public PortalItem? PortalItem { get; set; }

    public HashSet<Layer> Layers { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    await UpdateComponent();
                }

                break;
            case Layer layer:
                if (!Layers.Contains(layer))
                {
                    Layers.Add(layer);
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
            case PortalItem _:
                PortalItem = null;
                await UpdateComponent();

                break;
            case Layer layer:
                Layers.Remove(layer);
                await UpdateComponent();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}