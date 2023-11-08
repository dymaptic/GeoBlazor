using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.IO.Pipelines;
using System.Text.Json.Serialization;


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
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </param>  
    /// <param name="portalItem">
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </param>
    /// <param name="renderer">
    ///     An abstract base class that implements a variety of imagery renderers.
    /// </param>

    public ImageryLayer(string? url = null, PortalItem? portalItem = null, ImageryRenderer? renderer = null, IReadOnlyCollection<int>? bandIds = null,
        string? blendMode = null, int? compressionQuality = null, double? compressionTolerance = null, string? copyright = null, string? definitionExpression = null,
        Effect? effect = null, Field[]? fields = null, ImageFormat? format = null, bool? hasMultidimensions = null, int? imageMaxHeight = null,
        int? imageMaxWidth = null, int? interpolation = null, bool? legendEnabled = null, int? maxScale = null, int? minScale = null,
        IReadOnlyCollection<int>? noData = null, string? noDataInterpretation = null, string? objectIdField = null, bool? persistenceEnabled = null,
        string? pixelType = null, bool? popupEnabled = null, IReadOnlyCollection<Field>? rasterFields = null, double? refreshInterval = null,
        SpatialReference? spatialReference = null, TimeExtent? timeExtent = null, TimeInfo? timeInfo = null, bool? useViewTime = null
        ) 
    {
#pragma warning disable BL0005
        Renderer = renderer;
        Url = url;
        PortalItem = portalItem;
        BandIds = bandIds;
        BlendMode = blendMode;
        CompressionQuality = compressionQuality;
        CompressionTolerance = compressionTolerance;
        Copyright = copyright;
        DefinitionExpression = definitionExpression;
        Effect = effect;
        Fields = fields;
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
        RasterFields = rasterFields;
        RefreshInterval = refreshInterval;
        SpatialReference = spatialReference;
        TimeExtent = timeExtent;
        TimeInfo = timeInfo;
        UseViewTime = useViewTime;
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
    public ImageryRenderer? Renderer { get; set; }

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
    public string? BlendMode {  get; set; }

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
    ///     An array of fields in the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Field[]? Fields { get; set; }

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
    ///     The multidimensional information associated with the layer if the layer's hasMultidimensions property is true.
    /// </summary>
    //[Parameter]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    //public RasterMultidimensionalInfo? multidimensionalInfo { get; set; }

    /// <summary>
    ///     Represents a multidimensional subset of raster data.
    /// </summary>
    //[Parameter]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    //public MultidimensionalSubset? MultidimensionalSubset { get; set; }

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
    ///     Enable persistence of the layer in a WebMap or WebScene.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PersistenceEnabled { get; set; }

    /// <summary>
    ///     Raster source pixel type.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PixelType { get; set; }

    /// <summary>
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///     A complete list of fields that consists of raster attribute table fields, item pixel value, service pixel value, service pixel value with various server defined function templates, and raster attribute table fields. 
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<Field>? RasterFields { get; set; }

    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///    The spatial reference of the image service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///    The layer's time extent. 
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    ///    TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer.  
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInfo? TimeInfo { get; set; }

    /// <summary>
    ///    A temporary offset of the time data based on a certain TimeInterval.
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
            case ImageryRenderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
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
            case ImageryRenderer _:
                Renderer = null;
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
        Renderer?.ValidateRequiredChildren();
    }
}

/// <summary>
/// The format of the data sent by the server.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageFormat>))]
public enum ImageFormat
{
#pragma warning disable CS1591
    Png,
    Png8,
    Png24,
    Png32,
    Jpg,
    Bmp,
    Gif,
    Jpgpng,
    Lerc,
    Tiff
#pragma warning restore CS1591
}

