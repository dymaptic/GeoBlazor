namespace dymaptic.GeoBlazor.Core.Components;

public partial class ListItem: MapComponent
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="layerId">
    ///     The id for the layer associated with the triggered action.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#layer">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="actionsOpen">
    ///     Whether the actions panel is open in the LayerList.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsOpen">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="actionsSections">
    ///     A nested 2-dimensional collection of actions that could be triggered on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsSections">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="childrenSortable">
    ///     Indicates if the children of a list item (or sublayers in a GroupLayer) can be sorted or moved/reordered.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#childrenSortable">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hidden">
    ///     When `true`, hides the layer from the LayerList instance.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#hidden">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listModeDisabled">
    ///     Specifies whether to ignore the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">listMode</a> property of the child layers in the list item.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#listModeDisabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="open">
    ///     Whether the layer is open in the LayerList.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#open">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sortable">
    ///     Indicates if the list item (or layer in the map) can be sorted or moved/reordered.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#sortable">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public ListItem(
        Guid? layerId,
        bool? actionsOpen = null,
        ActionBase[][]? actionsSections = null,
        bool? childrenSortable = null,
        bool? hidden = null,
        bool? listModeDisabled = null,
        bool? open = null,
        bool? sortable = null,
        string? title = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        ActionsOpen = actionsOpen;
        ActionsSections = actionsSections;
        ChildrenSortable = childrenSortable;
        Hidden = hidden;
        LayerId = layerId;
        ListModeDisabled = listModeDisabled;
        Open = open;
        Sortable = sortable;
        Title = title;
#pragma warning restore BL0005    
    }
    
#region Set Properties
    
    /// <summary>
    ///    Asynchronously set the value of the Panel property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPanel(ListItemPanelWidget? value)
    {
#pragma warning disable BL0005
        Panel = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Panel)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference.InvokeVoidAsync("setPanel", CancellationTokenSource.Token,
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ActionsSections property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetActionsSections(ActionBase[][]? value)
    {
        if (ActionsSections is not null)
        {
            foreach (ActionBase item in ActionsSections.SelectMany(s => s))
            {
                await item.DisposeAsync();
            }
        }
        
#pragma warning disable BL0005
        ActionsSections = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ActionsSections)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference.InvokeVoidAsync("setActionsSections", 
            CancellationTokenSource.Token, value);
    }
    
#endregion
    
#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the ActionsSections property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    [CodeGenerationIgnore]
    public async Task AddToActionsSections(params ActionBase[] values)
    {
        ActionBase[][] join = ActionsSections is null
            ? [values]
            : ActionsSections.Concat([values]).ToArray();
        await SetActionsSections(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the ActionsSections property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    [CodeGenerationIgnore]
    public async Task RemoveFromActionsSections(params ActionBase[] values)
    {
        if (ActionsSections is null)
        {
            return;
        }
        await SetActionsSections(ActionsSections.Except([values]).ToArray());
    }
    
#endregion
}