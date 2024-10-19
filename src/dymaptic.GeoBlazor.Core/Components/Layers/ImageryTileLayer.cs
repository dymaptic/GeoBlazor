using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


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
        ListMode? listMode = null, int? maxScale = null, int? minScale = null, 
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
    public int? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and lesser than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }

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

/// <summary>
///     Defines how to interpolate pixel values.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PixelInterpolation>))]
public enum PixelInterpolation
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Nearest,
    Bilinear,
    Cubic,
    Majority
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     A subset of multidimensional raster data created by slicing the data along defined variables and dimensions. Only dimensional slices that meet the multidimensionalSubset requirements will be available on a multidimensional ImageryLayer or ImageryTileLayer when the multiDimensionalSubset property is set on the layer. For example, if you have an ImageryLayer that contains 30 years of monthly precipitation data, and you only want to expose data for each January to see how precipitation has changed for that month, you can set the multiDimensionalSubset on the imagery layer.
///     When the multiDimensionalSubset is defined on a layer, the multidimensionalDefinition property of the ImageryTileLayer or the mosaicRule.multidimensionalDefinition of the ImageryLayer must be within the defined multidimensionalSubset, otherwise nothing will be displayed on the map or available for analysis.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MultidimensionalSubset : MapComponent
{
    /// <summary>
    ///     The spatial area of interest as an Extent. The area of interest can only be set on an ImageryLayer. Only the imagery within the area of interest will be available when set.
    ///     Use either this or <see cref="PolygonOfInterest"/>.
    /// </summary>
    /// <remarks>
    ///     This property will not be honored on an ImageryTileLayer.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? ExtentOfInterest { get; set; }
    
    /// <summary>
    ///     The spatial area of interest as a Polygon. The area of interest can only be set on an ImageryLayer. Only the imagery within the area of interest will be available when set.
    ///     Use either this or <see cref="ExtentOfInterest"/>.
    /// </summary>
    /// <remarks>
    ///     This property will not be honored on an ImageryTileLayer.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Polygon? PolygonOfInterest { get; set; }

    /// <summary>
    ///     The variable and dimension subset definitions to set the layer. Only the dimensional definitions defined here will be available on the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
#pragma warning disable BL0007
    public IReadOnlyList<DimensionalDefinition> SubsetDefinitions
#pragma warning restore BL0007
    {
        get => _subsetDefinitions;
        set => _subsetDefinitions = new List<DimensionalDefinition>(value);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DimensionalDefinition dimensionalDefinition:
                _subsetDefinitions.Add(dimensionalDefinition);
                
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
            case DimensionalDefinition dimensionalDefinition:
                _subsetDefinitions.Remove(dimensionalDefinition);
                
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        foreach (DimensionalDefinition definition in _subsetDefinitions)
        {
            definition.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }

    private List<DimensionalDefinition> _subsetDefinitions = new();
}

/// <summary>
///     Describes general raster data information exposed by the ArcGIS REST API for ImageryLayer, ImageryTileLayer and WCSLayer. RasterInfo contains information such band count, statistics, data type, dimensions and key properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AttributeTable">
///     The raster attribute table associated with an imagery layer. It returns categorical mapping of pixel values such as class, group, or category, or membership.
/// </param>
/// <param name="BandCount">
///     Raster band count.
/// </param>
/// <param name="BandInfos">
///     This property provides additional information for each band in the raster. Raster products will include information such as the color name, wavelength range, the radiance gain, radiance bias, and solar irradiance. All other raster datasets will only contain the band index value.
/// </param>
/// <param name="Colormap">
///     Raster colormap that can be used to display the imagery layer. Each element in the array defines the pixel value and the red, green, and blue color values.
/// </param>
/// <param name="DataType">
///     Raster data type controls how the data is rendered by default.
/// </param>
/// <param name="Extent">
///     The minimum and maximum X and Y coordinates of a bounding box containing all the raster data.
/// </param>
/// <param name="HasMultidimensionalTranspose">
///     Indicates whether the source multidimensional data has been transposed. This only applies to ImageryTileLayer that references multidimensional image service.
/// </param>
/// <param name="Height">
///     Raster height (row count) in pixels.
/// </param>
/// <param name="Histograms">
///     Raster histograms return basic name-value pairs for number of bins, min and max bounding values, counts of pixels in each bin.
/// </param>
/// <param name="KeyProperties">
///     Raster key properties.
/// </param>
/// <param name="MultidimensionalInfo">
///     Returns the multidimensional information associated with the raster service referenced in an imagery layer. If defined, it contains an information on variables and dimensions associated with the service. Multidimensional data is stored as variables where each variable is a multidimensional array represents data captured in multiple dimensions like times and depths/heights.
///     You can filter the multidimensional data with one or multiple dimensional slices by setting the mosaicRule.multidimensionalDefinition property on an ImageryLayer or by setting the multidimensionalDefinition property on an ImageryTileLayer or a WCSLayer.
/// </param>
/// <param name="NoDataValue">
///     The pixel value representing no available information. Can be a single number (same value for all bands) or array (specific value for each band).
/// </param>
/// <param name="PixelSize">
///     Raster pixel size. Specifies the pixel size being identified on the x and y axis. Defaults to the base resolution of the dataset when not specified.
/// </param>
/// <param name="PixelType">
///     Pixel type for the raster data source.
/// </param>
/// <param name="SensorInfo">
///     The sensor information associated with an image service referenced by a layer.
/// </param>
/// <param name="SpatialReference">
///     The spatial reference of the raster.
/// </param>
/// <param name="Statistics">
///     Raster band statistics. These include the minimum value in the raster, maximum value, mean of all values, and standard deviation.
/// </param>
/// <param name="Width">
///     Raster width (column count) in pixels.
/// </param>
public record RasterInfo(FeatureSet AttributeTable, int BandCount, RasterBandInfo[] BandInfos,
    double[][] Colormap, RasterDataType DataType, Extent Extent, bool HasMultidimensionalTranspose,
    double Height, Dictionary<string, object>[] Histograms, Dictionary<string, object> KeyProperties,
    RasterMultidimensionalInfo MultidimensionalInfo, double[] NoDataValue, PixelSize PixelSize,
    PixelType PixelType, RasterSensorInfo SensorInfo, SpatialReference SpatialReference,
    RasterStatistics[] Statistics, double Width);
    
    
/// <summary>
///     RasterBandInfo class provides additional information for each raster band in an image service referenced by ImageryLayer or ImageryTileLayer. A band is represented by a single matrix of pixel values, and a raster with multiple bands contains multiple spatially coincident matrices of pixel values representing the same spatial area. Image services can include information such as the band name, band index value, wavelength range, the radiance gain, radiance bias, and solar irradiance. All other raster datasets will only contain the band index value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterBandInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MaxWavelength">
///     The maximum wavelength of the band.
/// </param>
/// <param name="MinWavelength">
///     The minimum wavelength of the band.
/// </param>
/// <param name="Name">
///     The name of the band.
/// </param>
/// <param name="RadianceBias">
///     The radiance bias of the band.
/// </param>
/// <param name="RadianceGain">
///     The radiance gain of the band.
/// </param>
/// <param name="ReflectanceBias">
///     The reflectance bias of the band.
/// </param>
/// <param name="ReflectanceGain">
///     The reflectance gain of the band.
/// </param>
/// <param name="SolarIrradiance">
///     The solar irradiance of the band.
/// </param>
public record RasterBandInfo(double MaxWavelength, double MinWavelength, string Name, double RadianceBias,
    double RadianceGain, double ReflectanceBias, double ReflectanceGain, double SolarIrradiance);

/// <summary>
///     RasterMultidimensionalInfo contains dimensions for each variable in the service describing information about the images collected at multiple times, depths, or heights.
/// </summary>
/// <param name="Variables">
///     The multi dimensional variables. It stores information such as name, unit and dimensions. For example, a temperature variable can store temperature data and the salinity variable can store the salinity data measured daily at different depths.
/// </param>
public record RasterMultidimensionalInfo(RasterMultidimensionalVariable[] Variables);

/// <summary>
///     The multi dimensional variables. It stores information such as name, unit and dimensions. For example, a temperature variable can store temperature data and the salinity variable can store the salinity data measured daily at different depths.
/// </summary>
/// <param name="Name">
///     Variable name.
/// </param>
/// <param name="Description">
///     Variable description.
/// </param>
/// <param name="Unit">
///     Unit of the variable measured in.
/// </param>
/// <param name="Dimensions">
///     A dimension may be used to represent real physical dimensions such as time or depth/height. It may also be used to represent more abstract quantities such as station id or station-time pair. For example, if your temperature data has a corresponding Date dimension field representing the day it was captured, and your salinity data has a Depth dimension field representing the depth at which it was measured, the Dimensions field for that variable would be Date and Depth.
/// </param>
/// <param name="Statistics">
///     Variable statistics.
/// </param>
/// <param name="Histograms">
///     Variable histograms.
/// </param>
public record RasterMultidimensionalVariable(
    string Name,
    string? Description,
    string? Unit,
    RasterDimension[] Dimensions,
    RasterBandStatistics[]? Statistics,
    RasterHistogram[]? Histograms);

/// <summary>
///     A dimension may be used to represent real physical dimensions such as time or depth/height. It may also be used to represent more abstract quantities such as station id or station-time pair. For example, if your temperature data has a corresponding Date dimension field representing the day it was captured, and your salinity data has a Depth dimension field representing the depth at which it was measured, the Dimensions field for that variable would be Date and Depth.
/// </summary>
/// <param name="Name">
///     Dimension name.
/// </param>
/// <param name="Description">
///     Dimension description.
/// </param>
/// <param name="Unit">
///     Dimension unit.
/// </param>
/// <param name="Values">
///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
/// </param>
/// <param name="HasRegularIntervals">
///     Indicates if the dimension is recorded at regular intervals.
/// </param>
/// <param name="Interval">
///     Dimension interval.
/// </param>
/// <param name="IntervalUnit">
///     Dimension interval unit.
/// </param>
/// <param name="Extent">
///     The extent of dimension values.
/// </param>
public record RasterDimension(
    string Name,
    string? Description,
    string? Unit,
    object[]? Values,
    bool? HasRegularIntervals,
    double? Interval,
    string? IntervalUnit,
    double[]? Extent);

/// <summary>
///     Raster pixel size.
/// </summary>
/// <param name="X">
///     Pixel size along the X axis.
/// </param>
/// <param name="Y">
///     Pixel size along the Y axis.
/// </param>
public record PixelSize(double X, double Y);

/// <summary>
///     The RasterSensorInfo class provides additional information on the raster sensor associated with an image service referenced by ImageryLayer or ImageryTileLayer. This information includes sensor name, product name, imagery acquisition date, cloud coverage, sun and sensor elevation and azimuth angle.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AcquisitionDate">
///     The acquisition date.
/// </param>
/// <param name="CloudCover">
///     The cloud coverage (0-1).
/// </param>
/// <param name="ProductName">
///     The satellite product name.
/// </param>
/// <param name="SensorAzimuth">
///     The sensor azimuth.
/// </param>
/// <param name="SensorElevation">
///     The sensor elevation.
/// </param>
/// <param name="SensorName">
///     The sensor name.
/// </param>
/// <param name="SunAzimuth">
///     The sun azimuth.
/// </param>
/// <param name="SunElevation">
///     The sun elevation.
/// </param>
public record RasterSensorInfo(DateOnly AcquisitionDate, double CloudCover, string ProductName,
    double SensorAzimuth, double SensorElevation, string SensorName, double SunAzimuth, double SunElevation);

/// <summary>
///     Raster statistics information returned that meets the specified ImageHistogramParameters from the computeStatisticsHistograms() method on ImageryLayer or ImageryTileLayer.
/// </summary>
/// <param name="Min">
///     Minimum value of the statistics.
/// </param>
/// <param name="Max">
///     Maximum value of the statistics.
/// </param>
/// <param name="Avg">
///     Average of the statistics.
/// </param>
/// <param name="Stddev">
///     Standard deviation of the statistics.
/// </param>
/// <param name="Count">
///     Count of the statistics.
/// </param>
/// <param name="Mode">
///     Mode value of the statistics.
/// </param>
/// <param name="Median">
///     Median value of the statistics.
/// </param>
/// <param name="Sum">
///     Sum of the statistics.
/// </param>
public record RasterBandStatistics(double Min, double Max, double Avg, double Stddev,
    int? Count, double? Mode, double? Median, double? Sum);

/// <summary>
///     Raster histogram information returned that meets the specified ImageHistogramParameters from the computeHistograms() or computeStatisticsHistograms() method.
/// </summary>
/// <param name="Size">
///     Number of bins.
/// </param>
/// <param name="Min">
///     The minimum pixel value of the histogram. Matches the minimum bound of the first bin.
/// </param>
/// <param name="Max">
///     The maximum pixel value of the histogram. Matches the maximum bound of the last bin.
/// </param>
/// <param name="Counts">
///     Count of pixels that fall into each bin.
/// </param>
public record RasterHistogram(int Size, double Min, double Max, int[] Counts);


/// <summary>
///     Possible data types for Rasters
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RasterDataType>))]
public enum RasterDataType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Generic,
    Elevation,
    Thematic,
    Processed,
    Scientific,
    VectorUv,
    VectorU,
    VectorV,
    VectorMagdir,
    VectorMagnitude,
    VectorDirection,
    StandardTime
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     Types of pixels for raster data sources
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PixelType>))]
public enum PixelType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Unknown,
    S8,
    S16,
    S32,
    U8,
    U16,
    U32,
    F32,
    F64
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}