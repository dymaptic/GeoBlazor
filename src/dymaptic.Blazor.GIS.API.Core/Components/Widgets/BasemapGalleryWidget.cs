using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

public class BasemapGalleryWidget : Widget
{
    public override string WidgetType => "basemapGallery";
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; } = "\"World Basemaps for Developers\" AND owner:esri";
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalBasemapsSource? PortalBasemapsSource { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalBasemapsSource pbms:
                if (!pbms.Equals(PortalBasemapsSource))
                {
                    PortalBasemapsSource = pbms;
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
            case PortalBasemapsSource _:
                PortalBasemapsSource = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}