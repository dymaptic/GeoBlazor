using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers
{

    /// <summary>
    ///     This layer supports Microsoft's Bing tiled map content. Three map styles are supported - road, aerial and hybrid.
    ///     Please note that a valid Bing Maps key is required to use this layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BingMapsLayer.html">
    ///         ArcGIS
    ///         JS API
    ///     </a>
    /// </summary>
    ///

    public class BingMapsLayer : Layer
	{
        /// <summary>
        ///     Parameterless constructor for use as a razor component
        /// </summary>
        public BingMapsLayer()
		{
		}

        /// <summary>
        ///     Constructor for use in code
        /// </summary>
        /// <param name="key">
        ///     Bing Maps Key.
        /// </param>
        /// <param name="style">
        ///     For more information on Bing map styles please visit: <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata">https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata</a>
        /// </param>
        public BingMapsLayer(string key, string? style = null)
        {
            Key = key;
            Style = style;
        }

        /// <inheritdoc />
        [JsonPropertyName("type")]
        public override string LayerType => "bing";

        /// <summary>
        ///     Bing Maps Key.
        /// </summary>
        [Parameter]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Key { get; set; }

        /// <summary>
        ///     For more information on Bing map styles please visit: <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata">https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata</a>
        /// </summary>
        [Parameter]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Style { get; set; }
    }
}
