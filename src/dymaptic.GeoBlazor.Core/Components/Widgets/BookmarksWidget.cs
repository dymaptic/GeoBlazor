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
    public async Task OnJsBookmarkSelect(BookmarkSelectEvent bookmarkSelectEvent)
    {
        await OnBookmarkSelect.InvokeAsync(bookmarkSelectEvent);
    }
    
    /// <summary>
    ///     This function provides the ability to override either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#goTo">MapView goTo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#goTo">SceneView goTo()</a> methods.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GoTo.html#goToOverride">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public GoToOverride? GoToOverride { get; set; }
    
    /// <summary>
    ///    JS-invokable method that triggers the <see cref="GoToOverride"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsGoToOverride(GoToOverrideParameters goToParameters)
    {
        if (GoToOverride is not null)
        {
            await GoToOverride.Invoke(goToParameters);
        }
    }
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="GoToOverride" /> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;

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