namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class TableListWidget: ITableListWidget
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="collapsed">
    ///     Indicates whether the widget is collapsed.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#collapsed">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="dragEnabled">
    ///     Indicates whether <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList-ListItem.html">list items</a> may be reordered within the list by dragging and dropping.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#dragEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterPlaceholder">
    ///     Placeholder text used in the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#filterPlaceholder">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterText">
    ///     The value of the filter input text string if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#filterText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="headingLevel">
    ///     Indicates the heading level to use for the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#title">title</a> of the widget.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#headingLevel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Icon which represents the widget.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="label">
    ///     The widget's label.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#label">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList-ListItem.html">ListItem</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#listItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minDragEnabledItems">
    ///     The minimum number of list items required to enable drag and drop reordering with <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#dragEnabled">dragEnabled</a>.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#minDragEnabledItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minFilterItems">
    ///     The minimum number of list items required to display the visibleElements.filter input box.
    ///     default 10
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#minFilterItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectedItems">
    ///     A collection of selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList-ListItem.html">ListItem</a>s representing table list items selected by the user.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#selectedItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectionMode">
    ///     Specifies the selection mode.
    ///     default "none"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#selectionMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="viewModel">
    ///     The view model for this widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#viewModel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TableList.html#visibleElements">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetId">
    ///     The unique ID assigned to the widget when the widget is created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public TableListWidget(
        bool? collapsed = null,
        bool? dragEnabled = null,
        string? filterPlaceholder = null,
        string? filterText = null,
        double? headingLevel = null,
        string? icon = null,
        string? label = null,
        Func<ListItem, Task<ListItem>>? listItemCreatedFunction = null,
        double? minDragEnabledItems = null,
        double? minFilterItems = null,
        IReadOnlyList<TableListListItem>? selectedItems = null,
        SelectionMode? selectionMode = null,
        TableListViewModel? viewModel = null,
        TableListVisibleElements? visibleElements = null,
        string? widgetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Collapsed = collapsed;
        DragEnabled = dragEnabled;
        FilterPlaceholder = filterPlaceholder;
        FilterText = filterText;
        HeadingLevel = headingLevel;
        Icon = icon;
        Label = label;
        OnListItemCreatedHandler = listItemCreatedFunction;
        MinDragEnabledItems = minDragEnabledItems;
        MinFilterItems = minFilterItems;
        SelectedItems = selectedItems;
        SelectionMode = selectionMode;
        ViewModel = viewModel;
        VisibleElements = visibleElements;
        WidgetId = widgetId;
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
   
   /// <summary>
   ///     JavaScript-Invokable Method for internal use only.
   /// </summary>
   [JSInvokable]
   [CodeGenerationIgnore]
   public async Task OnJsTriggerAction(TableListTriggerActionEvent triggerActionEvent)
   {
       if (TableItems is not null)
       {
           foreach (TableListListItem listItem in TableItems)
           {
               if (listItem.ActionsSections is null) continue;

               foreach (ActionBase action in listItem.ActionsSections.SelectMany(s => s))
               {
                   if (action.ActionId == triggerActionEvent.Action?.ActionId && action.CallbackFunction is not null)
                   {
                       await action.CallbackFunction.Invoke();
                   }
               }
           }
       }
       await OnTriggerAction.InvokeAsync(triggerActionEvent);
   }
   
   /// <summary>
   ///     Event Listener for TriggerAction.
   /// </summary>
   [Parameter]
   [JsonIgnore]
   [CodeGenerationIgnore]
   public EventCallback<TableListTriggerActionEvent> OnTriggerAction { get; set; }
}