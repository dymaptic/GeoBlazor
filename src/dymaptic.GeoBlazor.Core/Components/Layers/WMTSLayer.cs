using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Layers;


/// <summary>
/// The WMTSLayer is used to create layers based on OGC Web Map Tile Services (WMTS). 
/// The WMTSLayer initially executes a WMTS GetCapabilities request, which might require CORS or a proxy page.
/// <a target = "_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class WMTSLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "wmts";

    /// <summary>
    /// Constructor for use as a razor component
    /// </summary>
    public WMTSLayer()
    {
    }

    /// <summary>
    /// Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The url for the WMTS Layer source data.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item for the WCS Layer source data.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Indicates whether the layer should be persisted in the map. If set to true, the layer will be persisted in the map and will be available when the map is reloaded. If set to false, the layer will not be persisted in the map and will not be available when the map is reloaded.
    /// </param>
    /// <param name="serviceMode">
    ///     The service mode for the WMTS layer. If not specified, the API will first make a getCapabilities request using RESTful. If that fails, it will try using KVP.
    /// </param>
    /// /// <param name="activeLayer">
    ///     The active/displayed WMTS sublayer. 
    /// </param>
    /// <param name="sublayers">
    ///     The a collection of WMTS sublayers. Each sublayer represents a different layer within the WMTS service.
    /// </param>
    public WMTSLayer(string? url = null, PortalItem? portalItem = null, BlendMode? blendMode = null,
        Effect? effect = null, double? maxScale = null, double? minScale = null, bool? persistenceEnabled = null,
        string? serviceMode = null, WMTSSublayer? activeLayer = null, WMTSSublayer[]? sublayers = null)
    {
#pragma warning disable BL0005
        Url = url;
        PortalItem = portalItem;
        BlendMode = blendMode;
        Effect = effect;
        MaxScale = maxScale;
        MinScale = minScale;
        PersistenceEnabled = persistenceEnabled;
        ServiceMode = serviceMode;
        ActiveLayer = activeLayer;
        Sublayers = sublayers;
    }

    /// <summary>
    ///  The url for the particular WCS Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item for the WCS Layer source data.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     The active sublayer to display.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WMTSSublayer? ActiveLayer { get; set; }

    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }

    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///     The name of an oidfield containing a unique value or identifier for each feature in the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceMode { get; set; }


    /// <summary>
    ///     The name of an oidfield containing a unique value or identifier for each feature in the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WMTSSublayer[]? Sublayers { get; set; }
}
