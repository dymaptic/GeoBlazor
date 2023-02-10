using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Layers
{
    /// <summary>
    ///     The GeoRSSLayer class is used to create a layer based on GeoRSS. GeoRSS is a way to add geographic information to an RSS feed. The GeoRSSLayer supports both GeoRSS-Simple and GeoRSS GML encodings, and multiple geometry types.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoRSSLayer.html">ArcGIS JS API</a>
    /// </summary>
    public class GeoRSSLayer : Layer
    {
        /// <summary>
        ///     Parameterless constructor for use as a razor component
        /// </summary>
        public GeoRSSLayer()
        {
        }
        
        /// <summary>
        ///     Constructor for use in code
        /// </summary>
        /// <param name="url">
        ///     The url for the GeoRSS source data.
        /// </param>
        /// <param name="title">
        ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
        /// </param>
        /// <param name="opacity">
        ///     The opacity of the layer.
        /// </param>
        /// <param name="visible">
        ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is referenced in a view, but its features will not be visible in the view.
        /// </param>
        /// <param name="listMode">
        ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
        /// </param>
        public GeoRSSLayer(string url, string? title = null,
            double? opacity = null, bool? visible = null, ListMode? listMode = null)
        {
            Url = url;
            Title = title;
            Opacity = opacity;
            Visible = visible;
            ListMode = listMode;
        }
        
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
