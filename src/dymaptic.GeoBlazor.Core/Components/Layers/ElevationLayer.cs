namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     ElevationLayer is a tile layer used for rendering elevations in SceneViews. A default world elevation layer can be
///     added to the map by setting the map's ground property to world-elevation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ElevationLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.Elevation;

    /// <summary>
    ///     URL pointing to the Elevation layer resource on an ArcGIS Image Server.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item from which the layer is loaded. If the portal item references a Feature Service or Scene Service,
    ///     then you can specify a single layer to load with the layerId property.
    /// </summary>
    [RequiredProperty(nameof(Url))]
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
                    LayerChanged = true;
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
                LayerChanged = true;

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
}