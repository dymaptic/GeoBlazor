namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The web scene is the core element of 3D mapping across ArcGIS. It defines the content, style, environment, and
///     slides of your scene and it can be shared across multiple ArcGIS web and desktop applications
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class WebScene : Map
{
    /// <summary>
    ///     The portal item from which the WebScene is loaded.
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