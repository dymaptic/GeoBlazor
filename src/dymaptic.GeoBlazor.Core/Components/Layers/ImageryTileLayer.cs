using dymaptic.GeoBlazor.Core.Attributes;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     ImageryTileLayer presents raster data from a tiled image service. Binary imagery tiles are projected, processed, and rendered on the client-side. Tiled access is fast and scalable. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class ImageryTileLayer : Layer, IPopupTemplateLayer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "imagery-tile";

    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public ImageryTileLayer()
    {
    }

    /// <summary>
    ///     Construct an Imagery Layer in code
    /// </summary>
    /// <param name="url">
    ///     The url for the Imagery Layer source data.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item for the Imagery Layer source data.
    /// </param>
    /// <param name="renderer">
    ///     An interface that implements the various imagery renderers.
    /// </param>
    /// <param name="bandIds">
    ///     Defines a band combination using 0-based band indexes.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    /// </param>
    /// <param name="copyright">
    ///     The copyright text as defined by the service.
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    /// </param>
    /// <param name="interpolation">
    ///     Defines how to interpolate pixel values.
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend.
    /// </param>
    /// <param name="listMode">
    ///     Determines how the layer is displayed in the LayerList widget.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </param>
    /// <param name="multidimensionalDefinition">
    ///     The multidimensional definitions associated with the layer.
    /// </param>
    /// <param name="multidimensionalSubset">
    ///     A subset of multidimensional raster data created by slicing the data along defined variables and dimensions.
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Enable persistence of the layer in a WebMap or WebScene.
    /// </param>
    /// <param name="popupEnabled">
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </param>
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </param>
    /// <param name="useViewTime">
    ///     Determines if the layer will update its temporal data based on the view's timeExtent.
    /// </param>
    /// <param name="customParameters">
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="title">
    ///     The title of the layer.
    /// </param>
    public ImageryTileLayer(string? url = null, PortalItem? portalItem = null, IImageryRenderer? renderer = null, 
        IReadOnlyCollection<int>? bandIds = null, BlendMode? blendMode = null, string? copyright = null, 
        Effect? effect = null, PixelInterpolation? interpolation = null, bool? legendEnabled = null, 
        ListMode? listMode = null, double? maxScale = null, double? minScale = null, 
        IReadOnlyList<DimensionalDefinition>? multidimensionalDefinition = null, 
        MultidimensionalSubset? multidimensionalSubset = null,
        bool? persistenceEnabled = null, bool? popupEnabled = null, PopupTemplate? popupTemplate = null,
        bool? useViewTime = null, Dictionary<string, object>? customParameters = null,
        double? opacity = null, string? title = null
        ) 
    {
#pragma warning disable BL0005
        Title = title;
        Opacity = opacity;
        Renderer = renderer;
        ListMode = listMode;
        Url = url;
        PortalItem = portalItem;
        BandIds = bandIds;
        BlendMode = blendMode;
        Copyright = copyright;
        Effect = effect;
        Interpolation = interpolation;
        LegendEnabled = legendEnabled;
        MaxScale = maxScale;
        MinScale = minScale;

        if (multidimensionalDefinition is not null)
        {
            MultidimensionalDefinition = new List<DimensionalDefinition>(multidimensionalDefinition);
        }

        MultidimensionalSubset = multidimensionalSubset;
        PersistenceEnabled = persistenceEnabled;
        PopupEnabled = popupEnabled;
        UseViewTime = useViewTime;
        CustomParameters = customParameters;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? CustomParameters { get; set; }

    /// <summary>
    ///     The url for the Imagery Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }
    
    /// <summary>
    ///     The tiling scheme information for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }
    
    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     The portal item for the Imagery Layer source data.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     An interface that implements the various imagery renderers.
    /// </summary>
    public IImageryRenderer? Renderer { get; set; }

    /// <summary>
    ///     Defines a band combination using 0-based band indexes.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<int>? BandIds { get; set; }

    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode {  get; set; }

    /// <summary>
    ///     The copyright text as defined by the service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }

    /// <summary>
    ///     The multidimensional definitions associated with the layer. Filters the layer by slicing data along defined variables and dimensions such as time, depth, altitude, etc. For example, you can display a particular variable such as temperature or salinity measured at a fixed dimension (e.g. time, depth).
    /// </summary>
    [Parameter]
#pragma warning disable BL0007
    public IReadOnlyList<DimensionalDefinition> MultidimensionalDefinition
#pragma warning restore BL0007
    {
        get => _multidimensionalDefinition;
        set => _multidimensionalDefinition = new List<DimensionalDefinition>(value);
    }

    /// <summary>
    ///     Represents a multidimensional subset of raster data. This includes subsets of both variables and dimensions. When the multidimensionalSubset is defined on a layer, the multidimensionalDefinition must be within the defined multidimensionalSubset, otherwise nothing will be displayed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MultidimensionalSubset? MultidimensionalSubset { get; set; }

    /// <summary>
    ///    Defines how to interpolate pixel values. By default, this will be set to the service's resampling method, if it has one. If the service does not have a default resampling method, the bilinear resampling will be used in most cases. However, if the image service's cacheType is Raster and the data source is thematic (as declared in the service's keyProperties), and the service does not have a default resampling method, then the nearest interpolation type will be used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PixelInterpolation? Interpolation { get; set; }

    /// <summary>
    ///     Indicates whether the layer will be included in the legend.
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
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///    Determines if the layer will update its temporal data based on the view's timeExtent. 
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewTime { get; set; }
    
    /// <summary>
    ///     The layer's time extent. When the layer's useViewTime is false, the layer instructs the view to show data from the layer based on this time extent. If the useViewTime is true, and both layer and view time extents are set, then features that fall within the intersection of the view and layer time extents will be displayed. For example, if the layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }
    
    /// <summary>
    ///     TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInfo? TimeInfo { get; set; }
    
    /// <summary>
    ///     A temporary offset of the time data based on a certain TimeInterval. This allows users to overlay features from two or more time-aware layers with different time extents. For example, if a layer has data recorded for the year 1970, an offset value of 2 years would temporarily shift the data to 1972. You can then overlay this data with data recorded in 1972. A time offset can be used for display purposes only. The query and selection are not affected by the offset.
    ///     Default Value:null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInterval? TimeOffset { get; set; }

    /// <summary>
    ///     Retrieves the <see cref="RasterInfo"/> for the layer from the server.
    /// </summary>
    public async Task<RasterInfo?> GetServiceRasterInfo()
    {
        if (JsComponentReference is null) return null;
        return await JsComponentReference.InvokeAsync<RasterInfo>("getServiceRasterInfo", View?.Id);    
    }

    /// <summary>
    ///     Updates the renderer after initial render.
    /// </summary>
    public async Task SetRenderer(IImageryRenderer renderer)
    {
        Renderer = renderer;

        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("setRenderer", renderer);
    }

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
            case IImageryRenderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    LayerChanged = true;
                }
                break;
            case MultidimensionalSubset subset:
                if (!subset.Equals(MultidimensionalSubset))
                {
                    MultidimensionalSubset = subset;
                    LayerChanged = true;
                }

                break;
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                    LayerChanged = true;
                }

                break;
            case DimensionalDefinition definition:
                if (!_multidimensionalDefinition.Contains(definition))
                {
                    _multidimensionalDefinition.Add(definition);
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
            case IImageryRenderer _:
                Renderer = null;
                LayerChanged = true;
                break;
            case MultidimensionalSubset _:
                MultidimensionalSubset = null;
                LayerChanged = true;
                break;
            case PopupTemplate _:
                PopupTemplate = null;
                LayerChanged = true;

                break;
            case DimensionalDefinition definition:
                if (_multidimensionalDefinition.Remove(definition))
                {
                    LayerChanged = true;
                }

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
        (Renderer as MapComponent)?.ValidateRequiredChildren();
        MultidimensionalSubset?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();

        foreach (DimensionalDefinition definition in _multidimensionalDefinition)
        {
            definition.ValidateRequiredChildren();
        }
    }
    
    private List<DimensionalDefinition> _multidimensionalDefinition = new();
}