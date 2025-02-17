namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BookmarksWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Bookmarks;

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
    ///     Handler delegate for click events on the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
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
    [CodeGenerationIgnore]
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
                Bookmarks ??= [];
                if (!Bookmarks!.Contains(bookmark))
                {
                    Bookmarks = [..Bookmarks, bookmark];
                    WidgetChanged = true;
                }
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
                Bookmarks = Bookmarks?.Except([bookmark]).ToList();
                WidgetChanged = true;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}