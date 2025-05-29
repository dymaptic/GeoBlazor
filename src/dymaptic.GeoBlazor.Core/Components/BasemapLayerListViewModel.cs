namespace dymaptic.GeoBlazor.Core.Components;

public partial class BasemapLayerListViewModel: MapComponent, IViewModel
{
   // Add custom code to this file to override generated code
   
   /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="baseListItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList-BasemapLayerListViewModel.html#baseListItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="basemapTitle">
    ///     The current basemap's title.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList-BasemapLayerListViewModel.html#basemapTitle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="checkPublishStatusEnabled">
    ///     Whether to provide an indication if a layer is being published in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">BasemapLayerList</a>.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList-BasemapLayerListViewModel.html#checkPublishStatusEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listModeDisabled">
    ///     Specifies whether to ignore the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">listMode</a> property of the layers to display all layers.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList-BasemapLayerListViewModel.html#listModeDisabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="referenceListItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> representing reference layers.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList-BasemapLayerListViewModel.html#referenceListItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
   [CodeGenerationIgnore] 
   public BasemapLayerListViewModel(
       Func<ListItem, Task<ListItem>>? baseListItemCreatedFunction = null,
        string? basemapTitle = null,
        bool? checkPublishStatusEnabled = null,
        bool? listModeDisabled = null,
        Func<ListItem, Task<ListItem>>? referenceListItemCreatedFunction = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        OnBaseListItemCreatedHandler = baseListItemCreatedFunction;
        BasemapTitle = basemapTitle;
        CheckPublishStatusEnabled = checkPublishStatusEnabled;
        ListModeDisabled = listModeDisabled;
        OnReferenceListItemCreatedHandler = referenceListItemCreatedFunction;
#pragma warning restore BL0005    
    }
   
    /// <summary>
    ///     A delegate to implement a custom handler for setting up a base type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated base type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }
   
   
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnBaseListItemCreatedHandler" /> was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasCustomBaseListHandler => OnBaseListItemCreatedHandler is not null;

    /// <summary>
    ///     A delegate to implement a custom handler for setting up a reference type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated reference type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public Func<ListItem, Task<ListItem>>? OnReferenceListItemCreatedHandler { get; set; }

    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnReferenceListItemCreatedHandler" /> was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasCustomReferenceListHandler => OnReferenceListItemCreatedHandler is not null;

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a base type ListItem is created and a handler is attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem" /> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified base <see cref="ListItem" />
    /// </returns>
    /// <remarks>
    ///     For internal use only. This returns an object simply for JavaScript serialization purposes.
    /// </remarks>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task<object> OnBaseListItemCreated(ListItem item)
    {
        item.Parent = this;
        ListItem result = await OnBaseListItemCreatedHandler!.Invoke(item);

        return (object)result;
    }

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a reference type ListItem is created and a handler is attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem" /> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified reference <see cref="ListItem" />
    /// </returns>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task<object> OnReferenceListItemCreated(ListItem item)
    {
        item.Parent = this;
        ListItem result = await OnReferenceListItemCreatedHandler!.Invoke(item);
        
        return (object)result;
    }
}