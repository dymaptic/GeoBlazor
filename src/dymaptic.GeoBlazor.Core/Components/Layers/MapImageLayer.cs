namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class MapImageLayer : Layer
{

    
    /// <inheritdoc />
    public override LayerType Type => LayerType.MapImage;

    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }

    /// <summary>
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? CustomParameters { get; set; }

    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }
    
    /// <summary>
    ///     The version of the geodatabase of the map service data. Read the <a target="_blank" href="https://desktop.arcgis.com/en/arcmap/latest/manage-data/geodatabases/an-overview-of-versioning.htm">Overview of versioning</a> topic for more details about this capability.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
    
    /// <summary>
    ///     The output image type.
    ///     Default Value:Png24
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapImageFormat? ImageFormat { get; set; }
    
    /// <summary>
    ///     Indicates the maximum height of the image exported by the service.
    ///     Default Value: 2048
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ImageMaxHeight { get; set; }
    
    /// <summary>
    ///     Indicates the maximum width of the image exported by the service.
    ///     Default Value: 2048
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ImageMaxWidth { get; set; }
    
    /// <summary>
    ///     Indicates whether the background of the image exported by the service is transparent.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ImageTransparency { get; set; }
    
    /// <summary>
    ///     Indicates whether the layer will be included in the legend.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }
    
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
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }
    
    /// <summary>
    ///     The layer's time extent. When the layer's useViewTime is false, the layer instructs the view to show data from the layer based on this time extent. If the useViewTime is true, and both layer and view time extents are set, then features that fall within the intersection of the view and layer time extents will be displayed. For example, if the layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    ///     TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer. The timeInfo property, along with its startField and endField properties, must be set at the time of layer initialization if it is being set for a CSVLayer, GeoJSONLayer or FeatureLayer initialized from client-side features. The fullTimeExtent for timeInfo is automatically calculated based on its startField and endField properties. The timeInfo parameters cannot be changed after the layer is loaded.
    ///     TimeInfo's startField and endField can be date, date-only or timestamp-offset field type for FeatureLayer and MapImageLayer.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInfo? TimeInfo { get; set; }
    
    /// <summary>
    ///     Determines if the layer will update its temporal data based on the view's timeExtent. When false, the layer will display its temporal data based on the layer's timeExtent, regardless of changes to the view. If both view and layer time extents are set while this property is true, then the features that fall within the intersection of the view and layer time extents will be displayed. For example, if a layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewTime { get; set; }

    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case Sublayer sublayer:
                Sublayers ??= [];
                Sublayers = [..Sublayers, sublayer];
                
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

            case Sublayer sublayer:
                Sublayers = Sublayers?.Except([sublayer]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    
    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
        var renderedMapLayer = (MapImageLayer)renderedLayer;
        Url ??= renderedMapLayer.Url;
        Title ??= renderedMapLayer.Title;
        Dpi ??= renderedMapLayer.Dpi;
        Effect ??= renderedMapLayer.Effect;
        GdbVersion ??= renderedMapLayer.GdbVersion;
        ImageFormat ??= renderedMapLayer.ImageFormat;
        ImageMaxHeight ??= renderedMapLayer.ImageMaxHeight;
        ImageMaxWidth ??= renderedMapLayer.ImageMaxWidth;
        ImageTransparency ??= renderedMapLayer.ImageTransparency;
        LegendEnabled ??= renderedMapLayer.LegendEnabled;
        ListMode ??= renderedMapLayer.ListMode;
        MaxScale ??= renderedMapLayer.MaxScale;
        MinScale ??= renderedMapLayer.MinScale;
        Opacity ??= renderedMapLayer.Opacity;
        PersistenceEnabled ??= renderedMapLayer.PersistenceEnabled;
        RefreshInterval ??= renderedMapLayer.RefreshInterval;
        Capabilities ??= renderedMapLayer.Capabilities;
        Copyright ??= renderedMapLayer.Copyright;
        DateFieldsTimeZone ??= renderedMapLayer.DateFieldsTimeZone;
        DatesInUnknownTimezone ??= renderedMapLayer.DatesInUnknownTimezone;
        PreferredTimeZone ??= renderedMapLayer.PreferredTimeZone;
        SourceJSON ??= renderedMapLayer.SourceJSON;
        SpatialReference ??= renderedMapLayer.SpatialReference;
        MinScale ??= renderedMapLayer.MinScale;
        MaxScale ??= renderedMapLayer.MaxScale;
        PortalItem ??= renderedMapLayer.PortalItem;
        TimeInfo ??= renderedMapLayer.TimeInfo;
        Version ??= renderedMapLayer.Version;

        Sublayers ??= [];

        // create or update each sublayer individually
        if (renderedMapLayer.Sublayers is not null)
        {
            foreach (Sublayer renderedSubLayer in renderedMapLayer.Sublayers)
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