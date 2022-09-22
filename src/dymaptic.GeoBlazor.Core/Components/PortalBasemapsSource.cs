using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components;

public class PortalBasemapsSource: MapComponent
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Portal? Portal { get; set; }
    
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? QueryString { get; set; }
    
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? QueryParams { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Portal portal:
                if (!((Object)portal).Equals(Portal))
                {
                    Portal = portal;
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
            case Portal _:
                Portal = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}

public class Portal : MapComponent
{
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}