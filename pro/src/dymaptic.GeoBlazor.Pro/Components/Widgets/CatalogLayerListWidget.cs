namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class CatalogLayerListWidget : ICatalogLayerListWidget
{
    // Add custom code to this file to override generated code

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="catalogLayer">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CatalogLayer.html">CatalogLayer</a> to display in the widget.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#catalogLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="collapsed">
    ///     Indicates whether the widget is collapsed.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#collapsed">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterPlaceholder">
    ///     Placeholder text used in the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#filterPlaceholder">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterText">
    ///     The value of the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#filterText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="headingLevel">
    ///     Indicates the heading level to use for the heading of the widget.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#headingLevel">ArcGIS Maps SDK for JavaScript</a>
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
    ///     A function that executes each time a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> is created.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#listItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minFilterItems">
    ///     The minimum number of list items required to display the visibleElements.filter input box.
    ///     default 10
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#minFilterItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectedItems">
    ///     A collection of selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItems</a> representing <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#catalogItems">catalogItems</a> selected by the user.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#selectedItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectionMode">
    ///     Specifies the selection mode.
    ///     default "none"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#selectionMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="viewModel">
    ///     The view model for this widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#viewModel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityAppearance">
    ///     Determines the icons used to indicate visibility.
    ///     default "default"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#visibilityAppearance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CatalogLayerList.html#visibleElements">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetId">
    ///     The unique ID assigned to the widget when the widget is created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public CatalogLayerListWidget(CatalogLayer? catalogLayer = null,
        bool? collapsed = null,
        string? filterPlaceholder = null,
        string? filterText = null,
        double? headingLevel = null,
        string? icon = null,
        string? label = null,
        Func<ListItem, Task<ListItem>>? listItemCreatedFunction = null,
        double? minFilterItems = null,
        IReadOnlyList<ListItem>? selectedItems = null,
        SelectionMode? selectionMode = null,
        CatalogLayerListViewModel? viewModel = null,
        VisibilityAppearance? visibilityAppearance = null,
        CatalogLayerListVisibleElements? visibleElements = null,
        string? widgetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CatalogLayer = catalogLayer;
        Collapsed = collapsed;
        FilterPlaceholder = filterPlaceholder;
        FilterText = filterText;
        HeadingLevel = headingLevel;
        Icon = icon;
        Label = label;
        OnListItemCreatedHandler = listItemCreatedFunction;
        MinFilterItems = minFilterItems;
        SelectedItems = selectedItems;
        SelectionMode = selectionMode;
        ViewModel = viewModel;
        VisibilityAppearance = visibilityAppearance;
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

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTriggerAction(IJSStreamReference jsStreamRef)
    {
        CatalogLayerListTriggerActionEvent? triggerActionEvent =
            await jsStreamRef.ReadJsStreamReference<CatalogLayerListTriggerActionEvent>();

        if (CatalogItems is not null)
        {
            foreach (ListItem listItem in CatalogItems)
            {
                if (listItem.ActionsSections is not null)
                {
                    foreach (ActionBase action in listItem.ActionsSections.SelectMany(s => s))
                    {
                        if (action.ActionId == triggerActionEvent?.Action?.ActionId &&
                            action.CallbackFunction is not null)
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
    public EventCallback<CatalogLayerListTriggerActionEvent> OnTriggerAction { get; set; }
}