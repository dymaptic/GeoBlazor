using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;

/// <summary>
///     The description of a layer for display in a <see cref="LayerListWidget" />.
/// </summary>
public class ListItem 
{
    /// <summary>
    ///     The displayed title of the layer in the LayerList Widget.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }
    
    /// <summary>
    ///     Sets the layer values for this item.
    /// </summary>
    /// <remarks>
    ///      Editing not currently supported.
    /// </remarks>
    [Parameter]
    public Layer? Layer { get; set; }
    
    /// <summary>
    ///     Determines whether the layer is visible on load.
    /// </summary>
    [Parameter]
    public bool? Visible { get; set; }
    
    /// <summary>
    ///     The children items in a layer.
    /// </summary>
    /// <remarks>
    ///     Editing not currently supported.
    /// </remarks>
    public List<ListItem>? Children { get; set; }

    /// <summary>
    ///     Sets the actions on click for the list item.
    /// </summary>
    /// <remarks>
    ///     The Action Sections property and corresponding functionality will be fully implemented
    ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
    ///     and toggle the selected layer's visibility. More capabilities will be available after full
    ///     implementation of ActionSection.
    /// </remarks>
    public ActionSection[][]? ActionSections { get; set; }
    
}
