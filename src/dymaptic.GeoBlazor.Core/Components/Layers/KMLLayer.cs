using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public KMLLayer()
    {
    }
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
#pragma warning disable BL0005
        Url = url;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "kml";

    /// <summary>
    ///     The url for the KML Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

}
