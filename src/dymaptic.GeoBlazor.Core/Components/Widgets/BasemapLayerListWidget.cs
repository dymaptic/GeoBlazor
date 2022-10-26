using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;
/// <summary>
///     The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS JS API</a>
/// </summary>
public class BasemapLayerListWidget : LayerListWidget
{    
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapLayerList";

    /// <summary>
    ///     A delegate to implement a custom handler for setting up each <see cref="ListItem"/>.
    ///     Function must take in a ListItem and return a Task with the same (updated) item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }
    
    /// <summary>
    ///     The .Net object reference to this class for calling from JavaScript.
    /// </summary>
    public DotNetObjectReference<BasemapLayerListWidget> BaseLayerListWidgetObjectReference => DotNetObjectReference.Create(this);
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnListItemCreatedHandler"/> was registered.
    /// </summary>
    public bool HasCustomBaseListHandler => OnBaseListItemCreatedHandler is not null;
    
    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a ListItem is created and a handler is attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem"/> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified <see cref="ListItem"/>
    /// </returns>
    [JSInvokable]
    public Task<ListItem>? OnBaseListItemCreated(ListItem item)
    {
        return OnBaseListItemCreatedHandler?.Invoke(item);
    }

    /// <summary>
    ///     A delegate to implement a custom handler for setting up each <see cref="ListItem"/>.
    ///     Function must take in a ListItem and return a Task with the same (updated) item.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnReferenceListItemCreatedHandler { get; set; }
    
    /// <summary>
    ///     The .Net object reference to this class for calling from JavaScript.
    /// </summary>
    public DotNetObjectReference<BasemapLayerListWidget> ReferenceLayerListWidgetObjectReference => DotNetObjectReference.Create(this);
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="OnListItemCreatedHandler"/> was registered.
    /// </summary>
    public bool HasCustomReferenceListHandler => OnReferenceListItemCreatedHandler is not null;
    
    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a ListItem is created and a handler is attached.
    /// </summary>
    /// <param name="item">
    ///     The <see cref="ListItem"/> from the original source.
    /// </param>
    /// <returns>
    ///     Returns the modified <see cref="ListItem"/>
    /// </returns>
    [JSInvokable]
    public Task<ListItem>? OnReferenceListItemCreated(ListItem item)
    {
        return OnReferenceListItemCreatedHandler?.Invoke(item);
    }
    
    
}