using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components;

public class PortalItem : MapComponent
{
    [Parameter, EditorRequired]
    [RequiredProperty]
    public new string Id { get; set; } = default!;
}