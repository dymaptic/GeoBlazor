namespace dymaptic.GeoBlazor.Core.Components;

public class WebMap : MapComponent
{
    public PortalItem? PortalItem { get; set; }

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

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}