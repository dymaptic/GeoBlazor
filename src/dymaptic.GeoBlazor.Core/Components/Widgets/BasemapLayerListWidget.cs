using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Basemap ListItem class represents two of the operational Items in the LayerList ViewModel. In the Basemap
///     LayerList widget UI, the list items represent any base or reference layers displayed in the view. To display the
///     ListItems as separate types, a developer will need to specify a base or reference. It provides access to the
///     associated layer's properties, allows the developer to configure actions related to the layer, and allows the
///     developer to add content to the item related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapLayerListWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapLayerList";

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    ///     A delegate to implement a custom handler for setting up a base type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated base type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }
    
    /// <summary>
    ///     The current basemap's title.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BasemapTitle { get; set; }
    
    /// <summary>
    ///     Indicates whether the basemap’s title, layer order and layer grouping can be edited by the user. Any edits made will only be shown locally and will not be saved.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EditingEnabled { get; set; }
    
    /// <summary>
    ///     Indicates the heading level to use for the widget title (i.e. "Basemap"). By default, this is rendered as a level 2 heading (e.g. <h2>Basemap</h2>). Depending on the widget's placement in your app, you may need to adjust this heading for proper semantics. This is important for meeting accessibility standards.
    ///     Default Value:2
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HeadingLevel { get; set; }
    
    /// <summary>
    ///     Indicates whether more than one list item may be selected by the user at a single time. Selected items are available in the selectedItems property.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MultipleSelectionEnabled { get; set; }

    /// <summary>
    ///     The visible elements that are displayed within the widget. This property provides the ability to turn individual elements of the widget's display on/off.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BasemapLayerListWidgetVisibleElements? VisibleElements { get; set; }

    /// <summary>
    ///     The .Net object reference to this class for calling from JavaScript.
    /// </summary>
    public DotNetObjectReference<BasemapLayerListWidget> BaseLayerListWidgetObjectReference =>
        DotNetObjectReference.Create(this);

    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnBaseListItemCreatedHandler" /> was registered.
    /// </summary>
    public bool HasCustomBaseListHandler => OnBaseListItemCreatedHandler is not null;

    /// <summary>
    ///     A delegate to implement a custom handler for setting up a reference type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated reference type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnReferenceListItemCreatedHandler { get; set; }

    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnReferenceListItemCreatedHandler" /> was
    ///     registered.
    /// </summary>
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
    [JSInvokable]
    public Task<ListItem>? OnBaseListItemCreated(ListItem item)
    {
        return OnBaseListItemCreatedHandler?.Invoke(item);
    }

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a reference type ListItem is created and a handler is
    ///     attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem" /> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified reference <see cref="ListItem" />
    /// </returns>
    [JSInvokable]
    public Task<ListItem>? OnReferenceListItemCreated(ListItem item)
    {
        return OnReferenceListItemCreatedHandler?.Invoke(item);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case BasemapLayerListWidgetVisibleElements visibleElements:
                VisibleElements = visibleElements;
                WidgetChanged = true;
                
                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case BasemapLayerListWidgetVisibleElements _:
                VisibleElements = null;
                WidgetChanged = true;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        VisibleElements?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     The visible elements that are displayed within the widget. This property provides the ability to turn individual elements of the widget's display on/off.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#VisibleElements">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapLayerListWidgetVisibleElements: MapComponent
{
    /// <summary>
    ///     Indicates whether to the status indicators will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? StatusIndicators { get; set; }
    
    /// <summary>
    ///     Indicates whether to the base layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BaseLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether the reference layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReferenceLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether layer load errors will be displayed. Default is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Errors { get; set; }
}