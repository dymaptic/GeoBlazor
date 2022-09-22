using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components;

public class PortalItem : MapComponent
{
    [Parameter]
    public new string? Id { get; set; }
}