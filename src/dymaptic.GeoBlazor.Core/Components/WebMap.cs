namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Loads a WebMap from ArcGIS Online or ArcGIS Enterprise portal into a MapView. It defines the content, style, and bookmarks of your webmap, and it can be shared across multiple ArcGIS web and desktop applications.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html">ArcGIS JS API</a>
/// </summary>
public class WebMap : Map
{
    /// <summary>
    ///    The portal item from which the WebMap is loaded.
    /// </summary>
    [RequiredProperty]
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
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
    }
}