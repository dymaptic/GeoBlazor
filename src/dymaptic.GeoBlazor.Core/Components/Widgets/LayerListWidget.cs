namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The LayerList widget provides a way to display a list of layers, and switch on/off their visibility. The ListItem
///     API provides access to each layer's properties, allows the developer to configure actions related to the layer, and
///     allows the developer to add content to the item related to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LayerListWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "layerList";

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

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
        if (OnListItemCreatedHandler is not null)
        {
            ListItem result = await OnListItemCreatedHandler!.Invoke(item);

            return (object)result;
        }

        return null;
    }
}