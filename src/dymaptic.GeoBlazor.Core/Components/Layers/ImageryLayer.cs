using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents a dynamic image service resource as a layer. An ImageryLayer retrieves and displays data from dynamic image services. An image service supports
///     accessing the mosaicked image, its catalog, and the individual rasters in the catalog. An image service supports dynamic access and tiled access. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class ImageryLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "imagery";

    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public ImageryLayer()
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
    /// <param name="compressionQuality">
    ///     The compression quality value.
    /// </param>
    /// <param name="compressionTolerance">
    ///     Controls the tolerance of the lerc compression algorithm.
    /// </param>
    /// <param name="copyright">
    ///     The SQL where clause used to filter rasters.
    /// </param>
    /// <param name="definitionExpression">
    ///     The SQL where clause used to filter rasters.
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    /// </param>
    /// <param name="format">
    ///     The format of the exported image.
    /// </param>
    /// <param name="hasMultidimensions">
    ///     Indicates if the layer has multidimensionalInfo.
    /// </param>
    /// <param name="imageMaxHeight">
    ///     Indicates the maximum height of the image exported by the service.
    /// </param>
    /// <param name="imageMaxWidth">
    ///     Indicates the maximum width of the image exported by the service.
    /// </param>
    /// <param name="interpolation">
    ///     Defines how to interpolate pixel values.
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </param>
    /// <param name="noData">
    ///     The pixel value representing no available information.
    /// </param>
    /// <param name="noDataInterpretation">
    ///     Interpretation of the noData setting.
    /// </param>
    /// <param name="objectIdField">
    ///     The name of an oid field containing a unique value or identifier for each raster in the layer..
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Enable persistence of the layer in a WebMap or WebScene.
    /// </param>
    /// <param name="pixelType">
    ///     Raster source pixel type.
    /// </param>
    /// <param name="popupEnabled">
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    /// </param>
    /// <param name="useViewTime">
    ///     Determines if the layer will update its temporal data based on the view's timeExtent.
    /// </param>
    /// <param name="tileInfo">
    ///     The tiling scheme information for the layer.
    /// </param>
    /// <param name="timeExtent">
    ///     The layer's time extent. When the layer's useViewTime is false, the layer instructs the view to show data from the layer based on this time extent. If the useViewTime is true, and both layer and view time extents are set, then features that fall within the intersection of the view and layer time extents will be displayed. For example, if the layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    /// </param>
    /// <param name="timeInfo">
    ///     TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer.
    /// </param>
    /// <param name="timeOffset">
    ///     A temporary offset of the time data based on a certain TimeInterval. This allows users to overlay features from two or more time-aware layers with different time extents. For example, if a layer has data recorded for the year 1970, an offset value of 2 years would temporarily shift the data to 1972. You can then overlay this data with data recorded in 1972. A time offset can be used for display purposes only. The query and selection are not affected by the offset.
    /// </param>
    /// <param name="title">
    ///     The title of the layer.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="listMode">
    ///     The list mode of the layer.
    /// </param>
    /// <param name="visible">
    ///     The visibility of the layer.
    /// </param>
    /// <param name="customParameters">
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </param>
    /// <param name="fullExtent">
    ///     The full extent of the layer.
    /// </param>
    public ImageryLayer(string? url = null, PortalItem? portalItem = null, IImageryRenderer? renderer = null,
        IReadOnlyCollection<int>? bandIds = null, BlendMode? blendMode = null, int? compressionQuality = null, 
        double? compressionTolerance = null, string? copyright = null, string? definitionExpression = null,
        Effect? effect = null, ImageFormat? format = null,
        bool? hasMultidimensions = null, int? imageMaxHeight = null, int? imageMaxWidth = null, 
        int? interpolation = null, bool? legendEnabled = null, int? maxScale = null, int? minScale = null,
        IReadOnlyCollection<int>? noData = null, string? noDataInterpretation = null, string? objectIdField = null,
        bool? persistenceEnabled = null, PixelType? pixelType = null, bool? popupEnabled = null, 
        double? refreshInterval = null, bool? useViewTime = null, TileInfo? tileInfo = null, 
        TimeExtent? timeExtent = null, TimeInfo? timeInfo = null, TimeInterval? timeOffset = null, 
        string? title = null, double? opacity = null, ListMode? listMode = null, bool? visible = null, 
        Dictionary<string, object>? customParameters = null, Extent? fullExtent = null) 
    {
#pragma warning disable BL0005
        Title = title;
        Opacity = opacity;
        ListMode = listMode;
        Visible = visible;
        FullExtent = fullExtent;
        Renderer = renderer;
        Url = url;
        PortalItem = portalItem;
        BandIds = bandIds;
        BlendMode = blendMode;
        CompressionQuality = compressionQuality;
        CompressionTolerance = compressionTolerance;
        Copyright = copyright;
        CustomParameters = customParameters;
        DefinitionExpression = definitionExpression;
        Effect = effect;
        Format = format;
        HasMultidimensions = hasMultidimensions;
        ImageMaxHeight  = imageMaxHeight;
        ImageMaxWidth = imageMaxWidth;
        Interpolation = interpolation;
        LegendEnabled = legendEnabled;
        MaxScale = maxScale;
        MinScale = minScale;
        NoData = noData;
        NoDataInterpretation = noDataInterpretation;
        ObjectIdField = objectIdField;
        PersistenceEnabled = persistenceEnabled;
        PixelType = pixelType;
        PopupEnabled = popupEnabled;
        RefreshInterval = refreshInterval;
        UseViewTime = useViewTime;
        TileInfo = tileInfo;
        TimeExtent = timeExtent;
        TimeInfo = timeInfo;
        TimeOffset = timeOffset;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The url for the Imagery Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

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
    ///     The tiling scheme information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }
    
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
    ///     The compression quality value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CompressionQuality { get; set; }

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
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasMultidimensions { get; set; }

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
    ///    Defines how to interpolate pixel values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Interpolation { get; set; }

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
    public int? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }

    /// <summary>
    ///     The pixel value representing no available information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<int>? NoData { get; set; }

    /// <summary>
    ///     Interpretation of the noData setting.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NoDataInterpretation { get; set; }

    /// <summary>
    ///     The name of an oid field containing a unique value or identifier for each raster in the layer..
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjectIdField { get; set; }

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
            case IImageryRenderer _:
                Renderer = null;
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
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
        TileInfo?.ValidateRequiredChildren();
        (Renderer as MapComponent)?.ValidateRequiredChildren();
    }
}