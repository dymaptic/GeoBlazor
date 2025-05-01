namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class TileLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.Tile;
    
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer Portal. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }

    
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
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    
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

    /// <summary>  
    ///     Asynchronously retrieve the current value of the Subtables property.  
    /// </summary>  
    public Task<IReadOnlyList<Sublayer>?> GetSubtables()
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
        TileLayer renderedTileLayer = (TileLayer)renderedLayer;
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

        Sublayers ??= [];

        if (renderedTileLayer.Sublayers is not null)
        {
            foreach (Sublayer renderedSubLayer in renderedTileLayer.Sublayers!)
            {
                Sublayer? matchingLayer = Sublayers.FirstOrDefault(l => l.Id == renderedSubLayer.Id);

                if (matchingLayer is not null)
                {
                    matchingLayer.Parent = this;
                    matchingLayer.View = View;
                    matchingLayer.Layer = this;
                    await matchingLayer.UpdateFromJavaScript(renderedSubLayer);
                }
                else
                {
                    await RegisterNewSublayer(renderedSubLayer);
                }
            }
        }

        AllSublayers = Sublayers.Concat(Sublayers.SelectMany(s => s.GetAllSublayers() ?? [])).ToList();
    }

    private async Task RegisterNewSublayer(Sublayer sublayer)
    {
        sublayer.Parent = this;
        sublayer.View = View;
        sublayer.Layer = this;
        Sublayers ??= [];
        Sublayers = [..Sublayers, sublayer];
        await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorSublayer", Id,
            sublayer.SublayerId, sublayer.Id);

        if (sublayer.Sublayers is null)
        {
            return;
        }

        foreach (Sublayer subsub in sublayer.Sublayers)
        {
            await RegisterNewSublayer(subsub);
        }
    }
}