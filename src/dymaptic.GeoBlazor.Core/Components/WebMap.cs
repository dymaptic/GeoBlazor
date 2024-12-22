namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Loads a WebMap from ArcGIS Online or ArcGIS Enterprise portal into a MapView. It defines the content, style, and
///     bookmarks of your webmap, and it can be shared across multiple ArcGIS web and desktop applications.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class WebMap : Map
{
    /// <summary>
    ///     The portal item from which the WebMap is loaded.
    /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(Basemap), nameof(ArcGISDefaultBasemap))]
#pragma warning restore CS0618 // Type or member is obsolete
    [RequiredProperty] // the extra required here is for WebMap only, whereas the previous allows a check against the Map base type
    public PortalItem? PortalItem { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
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
            case PortalItem _:
                PortalItem = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
    }

    /// <summary>
    /// Gets the bookmarks defined in the WebMap from layers
    /// </summary>
    /// <returns>A list of bookmarks or null</returns>
    public async Task<List<Bookmark>> GetBookmarks()
    {
        var bookmarks = new List<Bookmark>();

        if (CoreJsModule != null)
        {
            bookmarks =
                await CoreJsModule!.InvokeAsync<List<Bookmark>>("getWebMapBookmarks", CancellationTokenSource.Token, this.View?.Id);
        }
        return bookmarks;
    }
}