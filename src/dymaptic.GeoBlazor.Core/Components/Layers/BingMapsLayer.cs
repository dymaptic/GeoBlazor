using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     This layer supports Microsoft's Bing tiled map content. Three map styles are supported - road, aerial and hybrid.
///     Please note that a valid Bing Maps key is required to use this layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BingMapsLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class BingMapsLayer : BaseTileLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public BingMapsLayer()
    {
    }
    
    public BingMapsLayer(string key, BingImageryStyle? style = null, BlendMode? blendMode = null, Effect? effect = null, 
        double? maxScale = null, double? minScale = null, double? refreshInterval = null, 
        SpatialReference? spatialReference = null)
        : base(blendMode, effect, maxScale, minScale, refreshInterval, spatialReference)
    {
#pragma warning disable BL0005
        Key = key;
        Style = style;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "bing-maps";

    /// <summary>
    ///     Bing Maps Key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Key { get; set; }

    /// <summary>
    ///     For more information on Bing map styles please visit: <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata">https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata</a>
    ///     Default Value: "Road"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BingImageryStyle? Style { get; set; }

    /// <summary>
    ///     Provides culture specific map labels. For more information visit: https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/culture-parameter
    ///     For a list of supported culture codes please visit: https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes
    ///     Default Value: "en-US"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CultureInfo? Culture { get; set; }
    
    /// <summary>
    ///     This will alter Geopolitical disputed borders and labels to align with the specified user region.
    ///     For more information on Bing's region setting please visit: https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/user-context-parameters
    ///     For a list of supported country codes please visit: see https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Region { get; set; }

    /// <summary>
    ///     Exposes Bing logo url.
    /// </summary>
    public async Task<string> GetBingLogo()
    {
        return await JsLayerReference!.InvokeAsync<string>("getBingLogo");
    }

    /// <summary>
    ///     Copyright information.
    /// </summary>
    public async Task<string> GetCopyright()
    {
        return await JsLayerReference!.InvokeAsync<string>("getCopyright");
    }

    /// <summary>
    ///     Indicates if the layer has attribution data.
    /// </summary>
    public async Task<bool> HasAttributionData()
    {
        return await JsLayerReference!.InvokeAsync<bool>("hasAttributionData");
    }
}

/// <summary>
///     The Bing Maps Imagery Set Styles. ArcGIS currently only supports 3 options.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BingMapsLayer.html#style">ArcGIS JS API</a>
///     <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata#template-parameters">Bing Maps Imagery Set Styles</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<BingImageryStyle>))]
public enum BingImageryStyle
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Road,
    Aerial,
    Hybrid
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}