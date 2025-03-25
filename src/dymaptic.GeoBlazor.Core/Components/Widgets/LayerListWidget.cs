namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class LayerListWidget : Widget
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="catalogOptions">
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CatalogLayer.html">CatalogLayer</a> specific properties.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#catalogOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="collapsed">
    ///     Indicates whether the widget is collapsed.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#collapsed">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="dragEnabled">
    ///     Indicates whether <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">list items</a> may be reordered within the list by dragging and dropping.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#dragEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterPlaceholder">
    ///     Placeholder text used in the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#filterPlaceholder">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterText">
    ///     The value of the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#filterText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="headingLevel">
    ///     Indicates the heading level to use for the heading of the widget.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#headingLevel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Icon which represents the widget.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="knowledgeGraphOptions">
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-KnowledgeGraphLayer.html">KnowledgeGraphLayer</a> specific properties.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#knowledgeGraphOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="label">
    ///     The widget's label.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#label">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listItemCreatedFunction">
    ///     A function that executes each time a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> is created.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#listItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minDragEnabledItems">
    ///     The minimum number of list items required to enable drag and drop reordering with <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#dragEnabled">dragEnabled</a>.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#minDragEnabledItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minFilterItems">
    ///     The minimum number of list items required to display the visibleElements.filter input box.
    ///     default 10
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#minFilterItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectedItems">
    ///     A collection of selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a>s representing operational layers selected by the user.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#selectedItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectionMode">
    ///     Specifies the selection mode.
    ///     default "none"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#selectionMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="viewModel">
    ///     The view model for this widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#viewModel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityAppearance">
    ///     Determines the icons used to indicate visibility.
    ///     default "default"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#visibilityAppearance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html#visibleElements">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetId">
    ///     The unique ID assigned to the widget when the widget is created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public LayerListWidget(
        LayerListCatalogOptions? catalogOptions = null,
        bool? collapsed = null,
        bool? dragEnabled = null,
        string? filterPlaceholder = null,
        string? filterText = null,
        double? headingLevel = null,
        string? icon = null,
        LayerListKnowledgeGraphOptions? knowledgeGraphOptions = null,
        string? label = null,
        Func<ListItem, Task<ListItem>>? listItemCreatedFunction = null,
        double? minDragEnabledItems = null,
        double? minFilterItems = null,
        IReadOnlyList<ListItem>? selectedItems = null,
        SelectionMode? selectionMode = null,
        LayerListViewModel? viewModel = null,
        VisibilityAppearance? visibilityAppearance = null,
        LayerListVisibleElements? visibleElements = null,
        string? widgetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CatalogOptions = catalogOptions;
        Collapsed = collapsed;
        DragEnabled = dragEnabled;
        FilterPlaceholder = filterPlaceholder;
        FilterText = filterText;
        HeadingLevel = headingLevel;
        Icon = icon;
        KnowledgeGraphOptions = knowledgeGraphOptions;
        Label = label;
        OnListItemCreatedHandler = listItemCreatedFunction;
        MinDragEnabledItems = minDragEnabledItems;
        MinFilterItems = minFilterItems;
        SelectedItems = selectedItems;
        SelectionMode = selectionMode;
        ViewModel = viewModel;
        VisibilityAppearance = visibilityAppearance;
        VisibleElements = visibleElements;
        WidgetId = widgetId;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.LayerList;

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
    [CodeGenerationIgnore]
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
        item.Parent = this;
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
    public async Task OnJsTriggerAction(IJSStreamReference jsStreamRef)
    {
        await using Stream stream = await jsStreamRef.OpenReadStreamAsync(1_000_000_000L);
        await using MemoryStream ms = new();
        await stream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);
        byte[] encodedJson = ms.ToArray();
        string json = Encoding.UTF8.GetString(encodedJson);
        LayerListTriggerActionEvent triggerActionEvent = JsonSerializer.Deserialize<LayerListTriggerActionEvent>(
            json, GeoBlazorSerialization.JsonSerializerOptions)!;
        if (OperationalItems is not null)
        {
            foreach (ListItem listItem in OperationalItems)
            {
                if (listItem.ActionsSections is not null)
                {
                    foreach (ActionBase action in listItem.ActionsSections.SelectMany(s => s))
                    {
                        if (action.ActionId == triggerActionEvent.Action?.ActionId && action.CallbackFunction is not null)
                        {
                            await action.CallbackFunction.Invoke();
                        }
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
    public EventCallback<LayerListTriggerActionEvent> OnTriggerAction { get; set; }
}