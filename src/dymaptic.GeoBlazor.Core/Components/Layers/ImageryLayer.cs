namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class ImageryLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.Imagery;


    /// <summary>
    ///     The tiling scheme information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }


    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode {  get; set; }


    /// <summary>
    ///     Controls the tolerance of the lerc compression algorithm.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CompressionTolerance { get; set; }

    /// <summary>
    ///     The copyright text as defined by the service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }
    
        
    /// <summary>
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? CustomParameters { get; set; }

    /// <summary>
    ///     The SQL where clause used to filter rasters.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }

    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }

    /// <summary>
    ///     The format of the exported image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageFormat? Format { get; set; }

    /// <summary>
    ///     Indicates if the layer has multidimensionalInfo.
    /// </summary>
    [JsonInclude]
    public bool? HasMultidimensions { get; protected set; }

    /// <summary>
    ///     Indicates the maximum height of the image exported by the service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ImageMaxHeight { get; set; }

    /// <summary>
    ///     Indicates the maximum width of the image exported by the service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ImageMaxWidth { get; set; }


    /// <summary>
    ///     Indicates whether the layer will be included in the legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }

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
    ///     The name of an oid field containing a unique value or identifier for each raster in the layer..
    /// </summary>
    [JsonInclude]
    public string? ObjectIdField { get; protected set; }

    /// <summary>
    ///     Raster source pixel type.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PixelType? PixelType { get; set; }

    /// <summary>
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }
    
    /// <summary>
    ///     The layer's time extent. When the layer's useViewTime is false, the layer instructs the view to show data from the layer based on this time extent. If the useViewTime is true, and both layer and view time extents are set, then features that fall within the intersection of the view and layer time extents will be displayed. For example, if the layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }
    
    /// <summary>
    ///     TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer.
    ///     Default Value:null
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
    ///    Determines if the layer will update its temporal data based on the view's timeExtent. 
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewTime { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case TileInfo tileInfo:
                if (!tileInfo.Equals(TileInfo))
                {
                    TileInfo = tileInfo;
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
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

            case TileInfo _:
                TileInfo = null;
                

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}