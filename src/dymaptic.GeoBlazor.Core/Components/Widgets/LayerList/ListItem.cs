using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;

/// <summary>
///     The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI,
///     the list item represents a layer displayed in the view. It provides access to the associated layer's properties,
///     allows the developer to configure actions related to the layer, and allows the developer to add content to the item
///     related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsSections">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ListItem
{
    /// <summary>
    ///     The displayed title of the layer in the LayerList Widget.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Sets the relevant layer values for this item.
    /// </summary>
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     Determines whether the layer is visible on load.
    /// </summary>
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
    ///     The Actions Sections property and corresponding functionality will be fully implemented
    ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
    ///     and toggle the selected layer's visibility. More capabilities will be available after full
    ///     implementation of ActionSection.
    /// </remarks>
    public ActionBase[][]? ActionsSections { get; set; }
    
    /// <summary>
    ///     Indicates if the children of a list item (or sublayers in a GroupLayer) can be sorted or moved/reordered.
    ///     Default Value:true
    /// </summary>
    public bool ChildrenSortable { get; set; }
    
    /// <summary>
    ///     When true, hides the layer from the LayerList instance. This is an alternative to Layer.listMode, which hides a layer from all instances of LayerList that include the layer.
    ///     Default Value:false
    /// </summary>
    public bool Hidden { get; set; }
    
    /// <summary>
    ///     Whether the layer is open in the LayerList.
    ///     Default Value:false
    /// </summary>
    public bool Open { get; set; }
    
    /// <summary>
    ///     Indicates if the list item (or layer in the map) can be sorted or moved/reordered.
    ///     Default Value:true
    /// </summary>
    public bool Sortable { get; set; }
}