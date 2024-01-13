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
    ///     The widget's default CSS icon class.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClass { get; set; }

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Indicates whether to the status indicators will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowStatusIndicators { get; set; }
    
    /// <summary>
    ///     Indicates whether to the base layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowBaseLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether the reference layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowReferenceLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether layer load errors will be displayed. Default is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowErrors { get; set; }

    /// <summary>
    ///     A delegate to implement a custom handler for setting up a base type of<see cref="ListItem" />.
    ///     Function must take in a ListItem and return a Task with the designated base type of item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }

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
}