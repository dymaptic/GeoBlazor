using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerList;
/// <summary>
///     The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS JS API</a>
/// </summary>
public class BaseListItem : ListItem
{
    /// <summary>
    ///     The children basemap items in a layer.
    /// </summary>
    [Parameter]
    public List<ListItem>? BaseItems { get; set; }
    /// <summary>
    ///     The children reference items in a layer.
    /// </summary>
    [Parameter]
    public List<ListItem>? ReferenceItems { get; set; }

    /// <summary>
    ///     Sets the actions on click for the list item.
    /// </summary>
    /// <remarks>
    ///     The Action Sections property and corresponding functionality will be fully implemented
    ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
    ///     and toggle the selected layer's visibility. More capabilities will be available after full
    ///     implementation of ActionSection.
    /// </remarks>
    public ActionBase[][]? ActionSections { get; set; }
}