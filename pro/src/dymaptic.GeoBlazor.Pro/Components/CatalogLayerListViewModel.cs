namespace dymaptic.GeoBlazor.Pro.Components;

public partial class CatalogLayerListViewModel : MapComponent,
    IViewModel
{
    // Add custom code to this file to override generated code
   
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore] 
    public CatalogLayerListViewModel()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="catalogLayer">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CatalogLayer.html">CatalogLayer</a> to display in the widget.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList-CatalogLayerListViewModel.html#catalogLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="checkPublishStatusEnabled">
    ///     Whether to provide an indication if a layer is being published in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html">CatalogLayerList</a>.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList-CatalogLayerListViewModel.html#checkPublishStatusEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listItemCreatedFunction">
    ///     A function that executes each time a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> is created.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList-CatalogLayerListViewModel.html#listItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public CatalogLayerListViewModel(
        CatalogLayer? catalogLayer = null,
        bool? checkPublishStatusEnabled = null,
        Func<ListItem, Task<ListItem>>? listItemCreatedFunction = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CatalogLayer = catalogLayer;
        CheckPublishStatusEnabled = checkPublishStatusEnabled;
        OnListItemCreatedHandler = listItemCreatedFunction;
#pragma warning restore BL0005    
    }
   
   /// <summary>
   ///     A delegate to implement a custom handler for setting up each <see cref="ListItem" />.
   ///     Function must take in a ListItem and return a Task with the same (updated) item.
   /// </summary>
   [Parameter]
   [JsonIgnore]
   [CodeGenerationIgnore]
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
   [CodeGenerationIgnore]
   public async Task<object?> OnListItemCreated(ListItem item)
   {
      if (OnListItemCreatedHandler is not null)
      {
         ListItem result = await OnListItemCreatedHandler!.Invoke(item);

         return (object)result;
      }

      return null;
   }
}