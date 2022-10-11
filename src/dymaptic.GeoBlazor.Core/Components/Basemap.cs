using dymaptic.GeoBlazor.Core.Components.Layers;

namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Creates a new basemap object. Basemaps can be created from a PortalItem, from a well known basemap ID, or can be used for creating custom basemaps. These basemaps may be created from tiled services you publish to your own server, or from tiled services published by third parties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">ArcGIS JS API</a>
/// </summary>
public class Basemap : MapComponent
{
    /// <summary>
    ///     The <see cref="PortalItem"/>
    /// </summary>
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     A collection of tile layers that make of the basemap's features.
    /// </summary>
    public HashSet<Layer> Layers { get; set; } = new();

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    await UpdateComponent();
                }

                break;
            case Layer layer:
                if (!Layers.Contains(layer))
                {
                    Layers.Add(layer);
                    await UpdateComponent();
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
                await UpdateComponent();

                break;
            case Layer layer:
                Layers.Remove(layer);
                await UpdateComponent();

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

        foreach (Layer layer in Layers)
        {
            layer.ValidateRequiredChildren();
        }
    }
}