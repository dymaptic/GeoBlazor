namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The KMLLayer class is used to create a layer based on a KML file (.kml, .kmz). KML is an XML-based file format used
///     to represent geographic features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-KMLLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class KMLLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.KML;

    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public KMLLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The url for the KML Layer source data.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item for the KML Layer source data.
    /// </param>
    public KMLLayer(string? url = null, PortalItem? portalItem = null)
    {

        if (url is null && portalItem is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(KMLLayer),
                new[] { nameof(Url), nameof(PortalItem) });
        }
#pragma warning disable BL0005
        Url = url;
        PortalItem = portalItem;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The url for the KML Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item for the KML Layer source data.
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
