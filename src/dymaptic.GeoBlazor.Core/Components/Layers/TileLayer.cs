using dymaptic.GeoBlazor.Core.Components.Geometries;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The TileLayer allows you work with a cached map service exposed by the ArcGIS Server REST API and add it to a Map
///     as a tile layer. A cached service accesses tiles from a cache instead of dynamically rendering images. Because they
///     are cached, tiled layers render faster than MapImageLayers. To create an instance of TileLayer, you must reference
///     the URL of the cached map service.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TileLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "tile";
    
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer dashboard. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }

    /// <summary>
    ///     The URL of the REST endpoint of the layer.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }
    
    /// <summary>
    ///     A flat Collection of all the sublayers in the MapImageLayer including the sublayers of its sublayers. All sublayers are referenced in the order in which they are drawn in the view (bottom to top).
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Sublayer>? AllSublayers =>
        Sublayers?.SelectMany(s => new[]{s}.Concat(s.GetAllSublayers()))
            .ToList();
    
    /// <summary>
    ///     Indicates the layer's supported capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public MapImageLayerCapabilities? Capabilities { get; private set; }

    /// <summary>
    ///     The copyright text as defined by the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Copyright { get; private set; }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }
    
    /// <summary>
    ///     Indicates whether the layer will be included in the legend.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and lesser than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }
    
    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }
    
    /// <summary>
    ///     The map service's metadata JSON exposed by the ArcGIS REST API. While most commonly used properties are exposed on the MapImageLayer class directly, this property gives access to all information returned by the map service. This property is useful if working in an application built using an older version of the API which requires access to map service properties from a more recent version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? SourceJSON { get; private set; }
    
    /// <summary>
    ///     The spatial reference of the layer as defined by the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public SpatialReference? SpatialReference { get; private set; }

    /// <summary>
    ///     A Collection of Sublayer objects. All sublayers are referenced in the order in which they are drawn in the view (bottom to top). Sublayer properties on TileLayer are read-only, with the following exceptions: LegendEnabled, PopupEnabled, PopupTemplate
    /// </summary>
    public IReadOnlyList<Sublayer>? Sublayers
    {
        get => _sublayers;
        set => _sublayers = value?.ToList();
    }
    
    /// <summary>
    ///     The tiling scheme information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }
    
    /// <summary>
    ///     An array of tile servers used for changing map tiles.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? TileServers { get; set; }

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

    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
        TileLayer renderedTileLayer = (TileLayer)renderedLayer;
        Sublayers ??= renderedTileLayer.Sublayers;
        Url ??= renderedTileLayer.Url;
        Title ??= renderedTileLayer.Title;
        Effect ??= renderedTileLayer.Effect;
        LegendEnabled ??= renderedTileLayer.LegendEnabled;
        ListMode ??= renderedTileLayer.ListMode;
        MaxScale ??= renderedTileLayer.MaxScale;
        MinScale ??= renderedTileLayer.MinScale;
        Opacity ??= renderedTileLayer.Opacity;
        PersistenceEnabled ??= renderedTileLayer.PersistenceEnabled;
        RefreshInterval ??= renderedTileLayer.RefreshInterval;
        Capabilities ??= renderedTileLayer.Capabilities;
        Copyright ??= renderedTileLayer.Copyright;
        SourceJSON ??= renderedTileLayer.SourceJSON;
        SpatialReference ??= renderedTileLayer.SpatialReference;
        MinScale ??= renderedTileLayer.MinScale;
        MaxScale ??= renderedTileLayer.MaxScale;
        PortalItem ??= renderedTileLayer.PortalItem;

        _sublayers ??= new List<Sublayer>();

        if (renderedTileLayer.Sublayers is not null)
        {
            foreach (Sublayer renderedSubLayer in renderedTileLayer.Sublayers!)
            {
                Sublayer? matchingLayer = _sublayers.FirstOrDefault(l => l.Id == renderedSubLayer.Id);

                if (matchingLayer is not null)
                {
                    matchingLayer.Parent = this;
                    matchingLayer.JsModule = JsModule;
                    matchingLayer.View = View;
                    await matchingLayer.UpdateFromJavaScript(renderedSubLayer);
                }
                else
                {
                    await RegisterNewSublayer(renderedSubLayer);
                }
            }
        }
    }

    private async Task RegisterNewSublayer(Sublayer sublayer)
    {
        sublayer.Parent = this;
        sublayer.JsModule = JsModule;
        sublayer.View = View;
        _sublayers!.Add(sublayer);
        await JsModule!.InvokeVoidAsync("registerGeoBlazorSublayer", Id,
            sublayer.SublayerId, sublayer.Id);

        foreach (Sublayer subsub in sublayer.Sublayers)
        {
            await RegisterNewSublayer(subsub);
        }
    }
    
    private List<Sublayer>? _sublayers;
}