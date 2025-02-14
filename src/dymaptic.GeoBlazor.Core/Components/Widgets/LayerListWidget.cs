namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class LayerListWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.LayerList;

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