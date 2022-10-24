using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerList;

public class BaseListItem
{
    [Parameter]
    public string? BasemapTitle { get; set; }

    [Parameter]
    public List<ListItem>? BasemapItems { get; set; }

    [Parameter]
    public List<ListItem>? ReferenceItems { get; set; }

    [Parameter]
    public bool? Visible { get; set; }

    public ActionBase[][]? ActionSections { get; set; }
}