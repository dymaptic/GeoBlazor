using dymaptic.GeoBlazor.Core.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


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
    /// Deprecated. Use VisibleElements.editBookmarkButton, VisibleElements.AddBookmarkButton, and DragEnabled instead.
    /// </summary>
    [Obsolete]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EditingEnabled { get; set; }

    /// <summary>
    ///    Indicates if a Bookmark is able to be dragged in order to update its position in the list.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DragEnabled { get; set; }

    /// <summary>
    /// Indicates the heading level to use for the message "No bookmarks" when no bookmarks are available in this widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HeadingLevel { get; set; }

    /// <summary>
    /// A collection of Bookmarks.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Bookmark>? Bookmarks { get; set; }

    /// <summary>
    /// The visible elements that are displayed within the widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BookmarkVisibleElements? VisibleElements { get; set; }

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
            case BookmarkVisibleElements visibleElements:
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
            case Bookmark bookmark:
                if (Bookmarks!.Contains(bookmark)) Bookmarks.Remove(bookmark);
                WidgetChanged = true;
                break;
            case BookmarkVisibleElements visibleElements:
                VisibleElements = null;
                WidgetChanged = true;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}

/// <summary>
/// The visible elements that are displayed within the widget. This provides the ability to turn individual elements of the widget's display on/off.
/// </summary>
public class BookmarkVisibleElements : MapComponent
{
    /// <summary>
    /// Indicates whether the button to add a new bookmark displays.
    ///  Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AddBookmarkButton { get; set; }

    /// <summary>
    /// Indicates whether to display a close button at the top of the widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseButton { get; set; }

    /// <summary>
    /// Indicates whether to display a collapse button at the top of the widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CollapseButton { get; set; }

    /// <summary>
    /// Indicates whether the button to edit a bookmark displays.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EditBookmarkButton { get; set; }

    /// <summary>
    /// Indicates whether the bookmarks filter displays.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Filter { get; set; }

    /// <summary>
    /// Determines whether the widget should be shown within its built-in flow component or if the flow component should be excluded. The widget will be displayed within its original flow component if set to true. The flow component will be omitted from the widget if set to false.
    /// To place the widget into an existing Calcite flow component, set this property to false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Flow { get; set; }

    /// <summary>
    /// Indicates whether to display the widget heading.The heading text is "Bookmarks".
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Heading { get; set; }

    /// <summary>
    /// Indicates whether the thumbnail associated with the bookmark displays.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Thumbnail { get; set; }

    /// <summary>
    /// Indicates whether the time (h:m:s) is displayed alongside the date if the bookmark has a time extent defined.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Time { get; set; }
}