namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Bookmarks widget allows end users to quickly navigate to a particular area of interest. It displays a list of bookmarks, which are typically defined inside the WebMap.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BookmarksWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "bookmarks";

    /// <summary>
    ///     When true, the widget is visually withdrawn and cannot be interacted with.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }

    /// <summary>
    ///    Indicates whether the bookmarks are able to be edited.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EditingEnabled { get; set; }

    /// <summary>
    /// Indicates the heading level to use for the message "No bookmarks" when no bookmarks are available in this widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HeadingLevel { get; set; }

    /// <summary>
    /// A collection of Bookmarks.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Bookmark>? Bookmarks { get; set; }

    /// <summary>
    ///     Handler delegate for click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<BookmarkSelectEvent> OnBookmarkSelect { get; set; }

    /// <summary>
    ///     JS-Invokable method to return a selected bookmark
    /// </summary>
    /// <param name="bookmarkSelectEvent">
    ///     The <see cref="BookmarkSelectEvent" /> return meta object.
    /// </param>
    /// <remarks>
    ///     Fires after a user clicks on a bookmark.
    /// </remarks>
    [JSInvokable]
    public async Task OnJavascriptBookmarkSelect(BookmarkSelectEvent bookmarkSelectEvent)
    {
        await OnBookmarkSelect.InvokeAsync(bookmarkSelectEvent);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Bookmark bookmark:
                if (!Bookmarks!.Contains(bookmark)) Bookmarks.Add(bookmark);
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
            case Bookmark bookmark:
                if (Bookmarks!.Contains(bookmark)) Bookmarks.Remove(bookmark);
                WidgetChanged = true;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}