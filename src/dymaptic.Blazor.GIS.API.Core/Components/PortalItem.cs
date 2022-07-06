using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components;

public class PortalItem : MapComponent
{
    [Parameter]
    public string? Id { get; set; }
}