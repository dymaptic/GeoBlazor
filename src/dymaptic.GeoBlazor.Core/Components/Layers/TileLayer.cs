using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class TileLayer : Layer
{
    [JsonPropertyName("type")]
    public override string LayerType => "tile";

    [Parameter]
    public string? Url { get; set; }

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

public class VectorTileLayer : TileLayer
{
    [JsonPropertyName("type")]
    public override string LayerType => "vectorTile";
}