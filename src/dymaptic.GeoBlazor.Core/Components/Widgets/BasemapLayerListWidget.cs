namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BasemapLayerListWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.BasemapLayerList;


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
    /// <remarks>
    ///     For internal use only. This returns an object simply for JavaScript serialization purposes.
    /// </remarks>
    [JSInvokable]
    public async Task<object> OnBaseListItemCreated(ListItem item)
    {
        ListItem result = await OnBaseListItemCreatedHandler!.Invoke(item);

        return (object)result;
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
    public async Task<object> OnReferenceListItemCreated(ListItem item)
    {
        ListItem result = await OnReferenceListItemCreatedHandler!.Invoke(item);
        
        return (object)result;
    }

}