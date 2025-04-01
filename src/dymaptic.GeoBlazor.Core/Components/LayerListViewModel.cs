namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerListViewModel: IViewModel
{
   // Add custom code to this file to override generated code
   
   /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="checkPublishStatusEnabled">
    ///     Whether to provide an indication if a layer is being published in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a>.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-LayerListViewModel.html#checkPublishStatusEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a>.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-LayerListViewModel.html#listItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listModeDisabled">
    ///     Specifies whether to ignore the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">listMode</a> property of the layers to display all layers.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-LayerListViewModel.html#listModeDisabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
   [CodeGenerationIgnore] 
   public LayerListViewModel(
        bool? checkPublishStatusEnabled = null,
        Func<ListItem, Task<ListItem>>? listItemCreatedFunction = null,
        bool? listModeDisabled = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CheckPublishStatusEnabled = checkPublishStatusEnabled;
        OnListItemCreatedHandler = listItemCreatedFunction;
        ListModeDisabled = listModeDisabled;
#pragma warning restore BL0005    
    }
   
    /// <summary>
    ///     A delegate to implement a custom handler for setting up each <see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the same (updated) item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnListItemCreatedHandler { get; set; }

    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnListItemCreatedHandler" /> was registered.
    /// </summary>
    public bool HasCustomHandler => OnListItemCreatedHandler is not null;

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a ListItem is created and a handler is attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem" /> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified <see cref="ListItem" />
    /// </returns>
    [JSInvokable]
    public async Task<object?> OnListItemCreated(ListItem item)
    {
        item.Parent = this;
        if (OnListItemCreatedHandler is not null)
        {
            ListItem result = await OnListItemCreatedHandler!.Invoke(item);

            return (object)result;
        }

        return null;
    }
}