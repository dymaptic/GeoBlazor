using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     WebTileLayer provides a simple way to add non-ArcGIS Server map tiles as a layer to a map. The constructor takes a URL template that usually follows a pattern of http://some.domain.com/{level}/{col}/{row}/ where level corresponds to a zoom level, and column and row represent tile column and row, respectively. This pattern is not required, but is the most common one currently on the web.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#urlTemplate">ArcGIS JS API</a>
/// </summary>
public class WebTileLayer: Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "web-tile";
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     The attribution information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }
    
    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }
    
    /// <summary>
    ///     Refresh interval of the layer in minutes.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///     A string of subDomain names where tiles are served to speed up tile retrieval. If subDomains are specified, the <see cref="UrlTemplate"/> should include a {subDomain} place holder.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<string>? SubDomains { get; set; }
    
    /// <summary>
    ///     The url template is a string that specifies the URL of the hosted tile images to load. The url template resembles an absolute URL but with a number of placeholder strings that the source evaluates to decide which tiles to load.
    /// </summary>
    /// <remarks>
    ///     The url template can follow a pattern of https://some.domain.com/{level}/{col}/{row}/ where level corresponds to a zoom level, and column and row represent a tile column and row, respectively. It can also follow a pattern of https://some.domain.com/{z}/{x}/{y}/ where z corresponds to a zoom level, and x and y represent a tile location along x and y axis. The urlTemplate should contain a {subDomain} place holder if subDomains are specified.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UrlTemplate { get; set; }
    
    /// <summary>
    ///     The portal item from which the layer is loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     The tiling scheme information for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }

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
            case TileInfo tileInfo:
                if (!tileInfo.Equals(TileInfo))
                {
                    TileInfo = tileInfo;
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
            case TileInfo _:
                TileInfo = null;
                LayerChanged = true;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        PortalItem?.ValidateRequiredChildren();
        TileInfo?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
/// </summary>
/// <remarks>
///     See more at <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#blendMode">ArcGIS JS API: Blend Mode</a>
/// </remarks>
[JsonConverter(typeof(BlendModeConverter))]
public enum BlendMode
{
#pragma warning disable CS1591
    Average,
    ColorBurn,
    ColorDodge,
    Color,
    Darken,
    DestinationAtop,
    DestinationIn,
    DestinationOut,
    DestinationOver,
    Difference,
    Exclusion,
    HardLight,
    Hue,
    Invert,
    Lighten,
    Lighter,
    Luminosity,
    Minus,
    Multiply,
    Normal,
    Overlay,
    Plus,
    Reflect,
    Saturation,
    Screen,
    SoftLight,
    SourceAtop,
    SourceIn,
    SourceOut,
    VividLight,
    Xor
#pragma warning restore CS1591
}

internal class BlendModeConverter : JsonConverter<BlendMode>
{
    public override BlendMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, BlendMode value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(BlendMode), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}