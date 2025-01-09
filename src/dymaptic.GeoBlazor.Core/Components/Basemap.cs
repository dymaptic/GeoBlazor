namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Creates a new basemap object. Basemaps can be created from a PortalItem, from a well known basemap ID, or can be
///     used for creating custom basemaps. These basemaps may be created from tiled services you publish to your own
///     server, or from tiled services published by third parties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Basemap : MapComponent
{
    /// <summary>
    ///     The <see cref="PortalItem" />
    /// </summary>
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     A collection of tile layers that make of the basemap's features.
    /// </summary>
    public List<Layer> Layers { get; set; } = new();
    
    public IReadOnlyList<Layer>? BaseLayers { get; set; }
    public IReadOnlyList<Layer>? ReferenceLayers { get; set; }
    
    /// <summary>
    ///     The style of the basemap from the basemap styles service (v2). The basemap styles service is a ready-to-use location service that serves vector and image tiles representing geographic features around the world.
    ///     You can use the service to display:
    ///          - Streets and navigation styles
    ///          - Imagery, oceanic, and topographic styles
    ///          - OSM standard and streets styles
    ///          - Creative styles such as nova and blue print
    ///          - Localized place labels
    ///     Use of the basemap style service requires authentication via an API key or user authentication. To learn more about API keys, see the API keys section in the ArcGIS Developer documentation.
    /// </summary>
    public BasemapStyle? Style { get; set; }
    
    /// <summary>  
    ///     Asynchronously retrieve the current value of the BaseLayers property.  
    /// </summary>  
    public Task<IReadOnlyList<Layer>?> GetBaseLayers()  
    {  
        return Task.FromResult(BaseLayers);  
    }  
  
    /// <summary>  
    ///     Asynchronously retrieve the current value of the ReferenceLayers property.  
    /// </summary>  
    public Task<IReadOnlyList<Layer>?> GetReferenceLayers()  
    {  
        return Task.FromResult(ReferenceLayers);  
    }

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
            case Layer layer:
                await View!.AddLayer(layer, true);

                break;
            case BasemapStyle style:
                if (!style.Equals(Style))
                {
                    Style = style;
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
            case Layer layer:
                await View!.RemoveLayer(layer, true);

                break;
            case BasemapStyle:
                Style = null;

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
        Style?.ValidateRequiredChildren();

        foreach (Layer layer in Layers)
        {
            layer.ValidateRequiredChildren();
        }
    }
}