using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Layers
{
    /// <summary>
    ///     The GeoRSSLayer class is used to create a layer based on GeoRSS. GeoRSS is a way to add geographic information to an RSS feed. The GeoRSSLayer supports both GeoRSS-Simple and GeoRSS GML encodings, and multiple geometry types.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoRSSLayer.html">ArcGIS JS API</a>
    /// </summary>
    public class GeoRSSLayer : Layer
    {
        /// <inheritdoc />
        [JsonPropertyName("type")]
        public override string LayerType => "geo-rss";

        /// <summary>
        ///     The url for the GeoRSS source data.
        /// </summary>
        [Parameter]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Url { get; set; }
    }
}
