
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The KMLLayer class is used to create a layer based on a KML file (.kml, .kmz). KML is an XML-based file format used
///     to represent geographic features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-KMLLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class KMLLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "kml";

    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    //public KMLLayer()
    //{
    //}
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The url for the KML Layer source data.
    /// </param>
    public KMLLayer (string? url = null, PortalItem? portalItem = null)
    {
        if (url is null && portalItem is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(KMLLayer),
                new[] { nameof(Url), nameof(PortalItem) });
        }
        Url = url;
        PortalItem = portalItem;
    }

    /// <summary>
    ///     The url for the KML Layer source data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item for the KML Layer source data.
    /// </summary>
    [RequiredProperty(nameof(PortalItem))]
    public PortalItem? PortalItem { get; set; }

    /// <inheritdoc />
    protected override async Task RegisterChildComponent(MapComponent child)
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
    protected override async Task UnRegisterChildComponent(MapComponent child)
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
    internal void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
    }   

}
