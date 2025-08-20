namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BasemapLayerListWidget : Widget
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="baseFilterText">
    ///     The value of the filter input text string if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#baseFilterText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="baseListItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> representing a base layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#baseListItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="basemapTitle">
    ///     The current basemap's title.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#basemapTitle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="catalogOptions">
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CatalogLayer.html">CatalogLayer</a> specific properties.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#catalogOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="collapsed">
    ///     Indicates whether the widget is collapsed.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#collapsed">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="dragEnabled">
    ///     Indicates whether <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">list items</a> may be reordered within the list by dragging and dropping.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#dragEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="editingTitle">
    ///     Indicates whether the form to edit the basemap's title is currently visible.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#editingTitle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filterPlaceholder">
    ///     Placeholder text used in the filter input if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#filterPlaceholder">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="headingLevel">
    ///     Indicates the heading level to use for the widget title (i.e.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#headingLevel">ArcGIS Maps SDK for JavaScript</a>
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
    /// <param name="minFilterItems">
    ///     The minimum number of list items required to display the visibleElements.filter input box.
    ///     default 10
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#minFilterItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="referenceFilterText">
    ///     The value of the filter input text string if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#visibleElements">visibleElements.filter</a> is true.
    ///     default ""
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#referenceFilterText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="referenceListItemCreatedFunction">
    ///     Specifies a function that accesses each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a> representing a reference layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#referenceListItemCreatedFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectedItems">
    ///     A collection of selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a>s representing basemap layers selected by the user.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#selectedItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectionMode">
    ///     Specifies the selection mode.
    ///     default "none"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#selectionMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="viewModel">
    ///     The view model for this widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#viewModel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityAppearance">
    ///     Determines the icons used to indicate visibility.
    ///     default "default"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#visibilityAppearance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#visibleElements">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetId">
    ///     The unique ID assigned to the widget when the widget is created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public BasemapLayerListWidget(
        string? baseFilterText = null,
        Func<ListItem, Task<ListItem>>? baseListItemCreatedFunction = null,
        string? basemapTitle = null,
        BasemapLayerListCatalogOptions? catalogOptions = null,
        bool? collapsed = null,
        bool? dragEnabled = null,
        bool? editingTitle = null,
        string? filterPlaceholder = null,
        int? headingLevel = null,
        string? icon = null,
        string? label = null,
        double? minFilterItems = null,
        string? referenceFilterText = null,
        Func<ListItem, Task<ListItem>>? referenceListItemCreatedFunction = null,
        IReadOnlyList<ListItem>? selectedItems = null,
        SelectionMode? selectionMode = null,
        BasemapLayerListViewModel? viewModel = null,
        VisibilityAppearance? visibilityAppearance = null,
        BasemapLayerListWidgetVisibleElements? visibleElements = null,
        string? widgetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        BaseFilterText = baseFilterText;
        OnBaseListItemCreatedHandler = baseListItemCreatedFunction;
        BasemapTitle = basemapTitle;
        CatalogOptions = catalogOptions;
        Collapsed = collapsed;
        DragEnabled = dragEnabled;
        EditingTitle = editingTitle;
        FilterPlaceholder = filterPlaceholder;
        HeadingLevel = headingLevel;
        Icon = icon;
        Label = label;
        MinFilterItems = minFilterItems;
        ReferenceFilterText = referenceFilterText;
        OnReferenceListItemCreatedHandler = referenceListItemCreatedFunction;
        SelectedItems = selectedItems;
        SelectionMode = selectionMode;
        ViewModel = viewModel;
        VisibilityAppearance = visibilityAppearance;
        VisibleElements = visibleElements;
        WidgetId = widgetId;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.BasemapLayerList;
    
    /// <summary>
    ///     A delegate to implement a custom handler for setting up a base type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated base type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }
    
    /// <summary>
    ///     The current basemap's title.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public string? BasemapTitle { get; set; }
    
    /// <summary>
    ///     Indicates whether the basemap’s title, layer order and layer grouping can be edited by the user. Any edits made will only be shown locally and will not be saved.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Obsolete("Deprecated since GeoBlazor V4. Use SelectionMode, VisibleElements.EditTitleButton, and DragEnabled instead.")]
    [CodeGenerationIgnore]
    public bool? EditingEnabled { get; set; }
    
    /// <summary>
    ///     Indicates the heading level to use for the widget title (i.e. "Basemap"). By default, this is rendered as a level 2 heading (e.g. <h2>Basemap</h2>). Depending on the widget's placement in your app, you may need to adjust this heading for proper semantics. This is important for meeting accessibility standards.
    ///     Default Value:2
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public int? HeadingLevel { get; set; }
    
    /// <summary>
    ///     Indicates whether more than one list item may be selected by the user at a single time. Selected items are available in the selectedItems property.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Obsolete("Deprecated since GeoBlazor v4. Use SelectionMode instead.")]
    [CodeGenerationIgnore]
    public bool? MultipleSelectionEnabled { get; set; }


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
    public async Task<object?> OnBaseListItemCreated(ListItem item)
    {
        item.Parent = this;
        item.Layer = View!.Map!.Layers.FirstOrDefault(l => l.Id == item.LayerId);

        if (OnBaseListItemCreatedHandler is not null)
        {
            ListItem result = await OnBaseListItemCreatedHandler!.Invoke(item);

            return (object)result;
        }

        return null;
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
    public async Task<object?> OnReferenceListItemCreated(ListItem item)
    {
        item.Parent = this;
        item.Layer = View!.Map!.Layers.FirstOrDefault(l => l.Id == item.LayerId);

        if (OnReferenceListItemCreatedHandler is not null)
        {
            ListItem result = await OnReferenceListItemCreatedHandler!.Invoke(item);

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
        BasemapLayerListTriggerActionEvent? triggerActionEvent =
            await jsStreamRef.ReadJsStreamReference<BasemapLayerListTriggerActionEvent>();

        if (triggerActionEvent is null)
        {
            return;
        }
        
        if (BaseItems is not null)
        {
            foreach (ListItem listItem in BaseItems)
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
    public EventCallback<BasemapLayerListTriggerActionEvent> OnTriggerAction { get; set; }

}