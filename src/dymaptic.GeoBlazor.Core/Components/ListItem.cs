namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI,
///     the list item represents a layer displayed in the view. It provides access to the associated layer's properties,
///     allows the developer to configure actions related to the layer, and allows the developer to add content to the item
///     related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsSections">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ListItem: MapComponent
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

    /// <summary>
    ///     Allows you to display custom content for each ListItem in the LayerList widget.
    ///     A common scenario for using ListItemPanel is to display a Legend widget within each list item. The legend keyword can be used in the content property of the panel to display a legend for each layer in the LayerList.
    /// </summary>
    public ListItemPanel? Panel { get; set; }
}

/// <summary>
///     This class allows you to display custom content for each ListItem in the LayerList widget. ListItemPanel objects typically aren't constructed. Rather, they are modified using the listItemCreatedFunction property in the LayerList widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record ListItemPanel
{
    /// <summary>
    ///     Adds a CSS class used to style a node that represents the panel. Clicking the node will open and close the panel. Typically, an icon font is used for this property. Esri Icon Fonts are automatically made available and can be used to represent this content. To use one of these provided icon fonts, you must prefix the class name with esri-. For example, the default icon font is esri-icon-layer-list.
    ///     Default Value:esri-icon-layer-list
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }
    
    /// <summary>
    ///     The HTML Element Id for content displayed in the ListItem panel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContentDivId { get; set; }
    
    /// <summary>
    ///     The GeoBlazor Id for a Widget to display in the ListItem panel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? ContentWidgetId { get; set; }
    
    /// <summary>
    ///     Raw text to display in the ListItem panel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StringContent { get; set; }
    
    /// <summary>
    ///     Defaults the panel to display a LegendWidget as content.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowLegendContent { get; set; }
    
    /// <summary>
    ///     If true, disables the ListItem's panel so the user cannot open or interact with it. The panel will be disabled by default if it does not have content or if it contains a legend with no active content in it.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }

    /// <summary>
    ///     Indicates whether the panel's content should be rendered as a Calcite Flow Item. By default, the panel's content is rendered in the content-bottom slot. Flow is a calcite component that allows for drilling in and out of panels.
    ///     Default Value:false
    /// </summary>
    public bool FlowEnabled { get; set; } = false;
    
    /// <summary>
    ///     Icon which represents the widget. It is typically used when the widget is controlled by another one (e.g. in the Expand widget).
    ///     Default Value:null
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Icon { get; set; }
    
    /// <summary>
    ///     The URL or data URI of an image used to represent the panel. This property will be used as a background image for the node. If neither image nor className are specified, a default icon default icon will display.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }
    
    /// <summary>
    ///     The widget's label.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    ///     Indicates if the panel's content is open and visible to the user. This is different from the visible property, which is used for toggling the visibility of the icon used to control whether the content is expanded or collapsed.
    ///     Default Value:false
    /// </summary>
    public bool Open { get; set; } = false;
    
    /// <summary>
    ///     The title of the panel. By default, this title matches the ListItem's title. Changing this value will not change the title of the ListItem in the LayerList.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Indicates if the node containing the image or className is visible to the user. Setting this value to false will prevent the user from toggling the visibility of the panel's content. Use open to programmatically set the visibility of the panel's content.
    ///     Default Value:true
    /// </summary>
    public bool Visible { get; set; } = true;
}