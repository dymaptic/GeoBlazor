using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components;

public class PortalItem : MapComponent
{
    [Parameter, EditorRequired]
    [RequiredProperty]
    public new string Id { get; set; } = default!;
}