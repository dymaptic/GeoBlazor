using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     MapImageLayer allows you to display and analyze data from sublayers defined in a map service, exporting images instead of features. Map service images are dynamically generated on the server based on a request, which includes an LOD (level of detail), a bounding box, dpi, spatial reference and other options. In 2D, the exported image is of the entire map extent specified. In 3D, two images are exported: an image with higher resolution for the area closer to the camera and a lower resolution image for the area farther away from the camera.
///     Unlike FeatureLayer, MapImageLayer processing is handled by the server, not the client. Offloading the processing to the server allows MapImageLayer to render more features with a higher level of performance in some cases.
///     MapImageLayer does not display tiled images. To display tiled map service layers, see TileLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MapImageLayer : Layer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public MapImageLayer()
    {
    }
    
    /// <summary>
    ///     Creates a new MapImageLayer in code with parameters.
    /// </summary>
    /// <param name="url">
    ///     The URL to the REST endpoint of the map service.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item from which the layer is loaded. This will load the layer along with any overridden properties (e.g. renderers, definition expressions, etc.) saved to the portal item, not the map service.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </param>
    /// <param name="customParameters">
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer. It's an object with key-value pairs where value is a string. The layer's refresh() method needs to be called if the customParameters are updated at runtime.
    /// </param>
    /// <param name="dpi">
    ///     The output dots per inch (DPI) of the MapImageLayer.
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </param>
    /// <param name="gdbVersion">
    ///     The version of the geodatabase of the map service data. Read the <a target="_blank" href="https://desktop.arcgis.com/en/arcmap/latest/manage-data/geodatabases/an-overview-of-versioning.htm">Overview of versioning</a> topic for more details about this capability.
    /// </param>
    /// <param name="imageFormat">
    ///     The output image type.
    /// </param>
    /// <param name="imageMaxHeight">
    ///     Indicates the maximum height of the image exported by the service.
    /// </param>
    /// <param name="imageMaxWidth">
    ///     Indicates the maximum width of the image exported by the service.
    /// </param>
    /// <param name="imageTransparency">
    ///     Indicates whether the background of the image exported by the service is transparent.
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Enable persistence of the layer in a WebMap or WebScene.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    /// </param>
    /// <param name="timeExtent">
    ///     The layer's time extent. When the layer's useViewTime is false, the layer instructs the view to show data from the layer based on this time extent. If the useViewTime is true, and both layer and view time extents are set, then features that fall within the intersection of the view and layer time extents will be displayed. For example, if the layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    /// </param>
    /// <param name="timeInfo">
    ///     TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer. The timeInfo property, along with its startField and endField properties, must be set at the time of layer initialization if it is being set for a CSVLayer, GeoJSONLayer or FeatureLayer initialized from client-side features. The fullTimeExtent for timeInfo is automatically calculated based on its startField and endField properties. The timeInfo parameters cannot be changed after the layer is loaded.
    /// </param>
    /// <param name="timeInterval">
    ///     A temporary offset of the time data based on a certain TimeInterval. This allows users to overlay features from two or more time-aware layers with different time extents. For example, if a layer has data recorded for the year 1970, an offset value of 2 years would temporarily shift the data to 1972. You can then overlay this data with data recorded in 1972. A time offset can be used for display purposes only. The query and selection are not affected by the offset.
    /// </param>
    /// <param name="useViewTime">
    ///     Determines if the layer will update its temporal data based on the view's timeExtent. When false, the layer will display its temporal data based on the layer's timeExtent, regardless of changes to the view. If both view and layer time extents are set while this property is true, then the features that fall within the intersection of the view and layer time extents will be displayed. For example, if a layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    /// </param>
    /// <param name="sublayers">
    ///     A Collection of Sublayer objects that allow you to alter the properties of one or more sublayers of the MapImageLayer. If this property is not specified, all the sublayers from the service are displayed as defined in the service. If an empty array is passed to this property then none of the sublayers from the service are displayed in the layer.
    /// </param>
    /// <param name="listMode">
    ///     The list mode of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the layer is visible in the view.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    public MapImageLayer(string? url = null, PortalItem? portalItem = null, BlendMode? blendMode = null, 
        Dictionary<string, object>? customParameters = null, int? dpi = null, Effect? effect = null, 
        string? gdbVersion = null, MapImageFormat? imageFormat = null, int? imageMaxHeight = null,
        int? imageMaxWidth = null, bool? imageTransparency = null, bool? legendEnabled = null, int? maxScale = null,
        int? minScale = null, bool? persistenceEnabled = null, double? refreshInterval = null, 
        TimeExtent? timeExtent = null, TimeInfo? timeInfo = null, TimeInterval? timeInterval = null, 
        bool? useViewTime = null, IReadOnlyList<Sublayer>? sublayers = null, ListMode? listMode = null,
        bool? visible = null, double? opacity = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        Url = url;
        PortalItem = portalItem;
        BlendMode = blendMode;
        CustomParameters = customParameters;
        DPI = dpi;
        Effect = effect;
        GdbVersion = gdbVersion;
        ImageFormat = imageFormat;
        ImageMaxHeight = imageMaxHeight;
        ImageMaxWidth = imageMaxWidth;
        ImageTransparency = imageTransparency;
        LegendEnabled = legendEnabled;
        MaxScale = maxScale;
        MinScale = minScale;
        PersistenceEnabled = persistenceEnabled;
        RefreshInterval = refreshInterval;
        TimeExtent = timeExtent;
        TimeInfo = timeInfo;
        TimeInterval = timeInterval;
        UseViewTime = useViewTime;
        PortalItem = portalItem;
        ListMode = listMode;
        Visible = visible;
        Opacity = opacity;

        if (sublayers is not null)
        {
            Sublayers = new List<Sublayer>(sublayers);
        }
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <inheritdoc />
    public override string LayerType => "map-image";

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
    ///     The output dots per inch (DPI) of the MapImageLayer.
    ///     Default Value:96
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DPI { get; set; }
    
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
    public int? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }
    
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
    ///     A temporary offset of the time data based on a certain TimeInterval. This allows users to overlay features from two or more time-aware layers with different time extents. For example, if a layer has data recorded for the year 1970, an offset value of 2 years would temporarily shift the data to 1972. You can then overlay this data with data recorded in 1972. A time offset can be used for display purposes only. The query and selection are not affected by the offset.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInterval? TimeInterval { get; set; }
    
    /// <summary>
    ///     The URL to the REST endpoint of the map service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }
    
    /// <summary>
    ///     Determines if the layer will update its temporal data based on the view's timeExtent. When false, the layer will display its temporal data based on the layer's timeExtent, regardless of changes to the view. If both view and layer time extents are set while this property is true, then the features that fall within the intersection of the view and layer time extents will be displayed. For example, if a layer's time extent is set to display features between 1970 and 1975 and the view has a time extent set to 1972-1980, the effective time on the feature layer will be 1972-1975.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewTime { get; set; }
    
    /// <summary>
    ///     The portal item from which the layer is loaded. This will load the layer along with any overridden properties (e.g. renderers, definition expressions, etc.) saved to the portal item, not the map service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }
    
    /// <summary>
    ///     A Collection of Sublayer objects that allow you to alter the properties of one or more sublayers of the MapImageLayer. If this property is not specified, all the sublayers from the service are displayed as defined in the service. If an empty array is passed to this property then none of the sublayers from the service are displayed in the layer.
    ///     All sublayers are referenced in the order in which they are drawn in the view (bottom to top).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IReadOnlyList<Sublayer> Sublayers
    {
        get => _sublayers;
        set => _sublayers = new List<Sublayer>(value);
    }
    
    //TODO: Add support for adding, removing, reordering sublayers
    
    /// <summary>
    ///     A flat Collection of all the sublayers in the MapImageLayer including the sublayers of its sublayers. All sublayers are referenced in the order in which they are drawn in the view (bottom to top).
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Sublayer>? AllSublayers =>
        Sublayers.SelectMany(s => new[]{s}.Concat(s.GetAllSublayers()))
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
    ///     The time zone that dates are stored in. This property does not apply to date fields referenced by timeInfo.
    ///     Even though dates are transmitted as UTC epoch values, this property may be useful when constructing date or time where clauses for querying. If constructing date or time where clauses, use FieldIndex.getTimeZone() to get the time zone for the given date field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? DateFieldsTimeZone { get; private set; }
    
    /// <summary>
    ///     This property is set by the service publisher and indicates that dates should be considered without the local timezone. This applies to both requests and responses.
    /// </summary>
    /// <remarks>
    ///     Known Limitations
    ///     - This capability is only available with services published with ArcGIS Enterprise 10.9 or greater.
    ///     - When setting timeExtent in a query, filter or layer, dates must be defined in terms of UTC as illustrated in the code below.
    ///     - When using Layer.TimeInfo.FullTimeExtent in conjunction with TimeSlider, the local timezone offset must be removed.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? DatesInUnknownTimezone { get; private set; }
    
    /// <summary>
    ///     The IANA time zone the author of the service intended data from date fields to be viewed in.
    ///     Default Value: null
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? PreferredTimeZone { get; private set; }
    
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
    ///     The version of ArcGIS Server in which the map service is published.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Version { get; private set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                PortalItem = portalItem;
                
                break;
            case Sublayer sublayer:
                _sublayers.Add(sublayer);
                
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
                
                break;
            case Sublayer sublayer:
                _sublayers.Remove(sublayer);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        PortalItem?.ValidateRequiredChildren();

        foreach (Sublayer sublayer in _sublayers)
        {
            sublayer.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
    
    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
        var renderedMapLayer = (MapImageLayer)renderedLayer;
        Url ??= renderedMapLayer.Url;
        Title ??= renderedMapLayer.Title;
        DPI ??= renderedMapLayer.DPI;
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

        foreach (Sublayer renderedSubLayer in renderedMapLayer.Sublayers)
        {
            Sublayer? matchingLayer = _sublayers.FirstOrDefault(l => l.Id == renderedSubLayer.Id);

            if (matchingLayer is not null)
            {
                matchingLayer.Parent = this;
                matchingLayer.View = View;
                await matchingLayer.UpdateFromJavaScript(renderedSubLayer);
            }
            else
            {
                await RegisterNewSublayer(renderedSubLayer);
            }
        }
    }
    
    private async Task RegisterNewSublayer(Sublayer sublayer)
    {
        sublayer.Parent = this;
        sublayer.View = View;
        _sublayers.Add(sublayer);
        await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorSublayer", Id,
            sublayer.SublayerId, sublayer.Id);

        foreach (Sublayer subsub in sublayer.Sublayers)
        {
            await RegisterNewSublayer(subsub);
        }
    }
    
    private List<Sublayer> _sublayers = new();
}

/// <summary>
///     Indicates the layer's supported capabilities.
/// </summary>
/// <param name="ExportMap">
///     Indicates options supported by the exportMap operation. Will be null if the supportsExportMap is false.
/// </param>
/// <param name="ExportTiles">
///     Indicates options supported by the exportTiles operation. Will be null if the supportsExportTiles is false.
/// </param>
/// <param name="Operations">
///     Indicates operations that can be performed on the service.
/// </param>
public record MapImageLayerCapabilities(
    MapImageExportMap ExportMap,
    MapImageExportTiles ExportTiles,
    MapImageOperations Operations);

/// <summary>
///     Indicates options supported by the exportMap operation. Will be null if the supportsExportMap is false.
/// </summary>
/// <param name="SupportsArcadeExpressionForLabeling">
///     Indicates if sublayers support Arcade expressions for labeling. Only applies to MapImageLayer.
/// </param>
/// <param name="SupportsDynamicLayers">
///     Indicates if sublayers rendering can be modified or added using dynamic layers.
/// </param>
/// <param name="SupportsSublayersChanges">
///     Indicates if sublayers can be added, or removed. supportsDynamicLayers must be true as well to be able to reorder sublayers.
/// </param>
/// <param name="SupportsSublayerDefinitionExpression">
///     Indicates if sublayers definition expression can be set.
/// </param>
/// <param name="SupportsSublayerVisibility">
///     Indicates if sublayers visibility can be changed.
/// </param>
/// <param name="SupportsCIMSymbols">
///     Indicates if CIMSymbol can be used in a sublayer's renderer.
/// </param>
public record MapImageExportMap(bool SupportsArcadeExpressionForLabeling, bool SupportsDynamicLayers,
    bool SupportsSublayersChanges, bool SupportsSublayerDefinitionExpression,
    bool SupportsSublayerVisibility, bool SupportsCIMSymbols);

/// <summary>
///     Indicates options supported by the exportTiles operation. Will be null if the supportsExportTiles is false.
/// </summary>
/// <param name="MaxExportTilesCount">
///     Specifies the maximum number of tiles that can be exported to a cache dataset or a tile package.
/// </param>
public record MapImageExportTiles(int MaxExportTilesCount);

/// <summary>
///     Indicates operations that can be performed on the service.
/// </summary>
/// <param name="SupportsExportMap">
///     Indicates if the service can generate images.
/// </param>
/// <param name="SupportsExportTiles">
///     Indicates if the tiles from the service can be exported.
/// </param>
/// <param name="SupportsIdentify">
///     Indicates if the service supports the identify operation.
/// </param>
/// <param name="SupportsQuery">
///     Indicates if features in the sublayers can be queried.
/// </param>
/// <param name="SupportsTileMap">
///     Indicates if the service exposes a tile map that describes the presence of tiles.
/// </param>
public record MapImageOperations(bool SupportsExportMap, bool SupportsExportTiles, bool SupportsIdentify, 
    bool SupportsQuery, bool SupportsTileMap);

/// <summary>
///     The output image type of the MapImageLayer.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<MapImageFormat>))]
public enum MapImageFormat
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Png,
    Png8,
    Png24,
    Png32,
    Jpg,
    Pdf,
    Bmp,
    Gif,
    Svg,
    Pngjpg
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}