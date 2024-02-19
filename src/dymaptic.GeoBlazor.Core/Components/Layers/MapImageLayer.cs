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
        bool? useViewTime = null, IEnumerable<Sublayer>? sublayers = null, ListMode? listMode = null,
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
            Sublayers = new HashSet<Sublayer>(sublayers);
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
    ///     Enable persistence of the layer in a WebMap or WebScene.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PersistenceEnabled { get; set; }
    
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
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IReadOnlyCollection<Sublayer> Sublayers
    {
        get => _sublayers;
        set => _sublayers = new HashSet<Sublayer>(value);
    }
    
    /// <summary>
    ///     A flat Collection of all the sublayers in the MapImageLayer including the sublayers of its sublayers. All sublayers are referenced in the order in which they are drawn in the view (bottom to top).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IReadOnlyCollection<Sublayer>? AllSublayers { private get; set; }
    
    /// <summary>
    ///     Indicates the layer's supported capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public MapImageLayerCapabilities? Capabilities { get; set; }

    /// <summary>
    ///     The copyright text as defined by the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Copyright { get; set; }
    
    /// <summary>
    ///     The time zone that dates are stored in. This property does not apply to date fields referenced by timeInfo.
    ///     Even though dates are transmitted as UTC epoch values, this property may be useful when constructing date or time where clauses for querying. If constructing date or time where clauses, use FieldIndex.getTimeZone() to get the time zone for the given date field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? DateFieldsTimeZone { get; set; }
    
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
    public bool? DatesInUnknownTimezone { get; set; }
    
    /// <summary>
    ///     The IANA time zone the author of the service intended data from date fields to be viewed in.
    ///     Default Value: null
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? PreferredTimeZone { get; set; }
    
    /// <summary>
    ///     The map service's metadata JSON exposed by the ArcGIS REST API. While most commonly used properties are exposed on the MapImageLayer class directly, this property gives access to all information returned by the map service. This property is useful if working in an application built using an older version of the API which requires access to map service properties from a more recent version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? SourceJSON { get; set; }
    
    /// <summary>
    ///     The spatial reference of the layer as defined by the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     The version of ArcGIS Server in which the map service is published.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Version { get; set; }
    
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
        AllSublayers ??= renderedMapLayer.AllSublayers;
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
                matchingLayer.UpdateFromJavaScript(renderedSubLayer);
            }
            else
            {
                _sublayers.Add(renderedSubLayer);
            }
        }
    }
    
    private HashSet<Sublayer> _sublayers = new();
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
///     Represents a Sublayer in a MapImageLayer or a TileLayer. MapImageLayer allows you to display, query, and analyze layers from data defined in a map service. Map services contain Sublayers with properties such as renderer, labelingInfo, and definitionExpression, and others that are defined on the server. The properties of each MapImageLayer Sublayer on the map service may be dynamically changed by the user or developer. The properties of each TileLayer Sublayer are read-only, and cannot be modified.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Sublayer: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public Sublayer()
    {
    }
    
    /// <summary>
    ///     Creates a new Sublayer in code with parameters.
    /// </summary>
    /// <param name="sublayerId">
    ///     The sublayer's layer ID. When a source is not defined on the layer, this value represents the id of the sublayer defined by the map service. If creating a DynamicDataLayer or a MapDataLayer and adding it to the source property of the sublayer, the value of this property can be anything set by the developer.
    /// </param>
    /// <param name="labelsVisible">
    ///     Indicates if labels for the sublayer will be visible in the view.
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend. When false, the layer will be excluded from the legend.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </param>
    /// <param name="opacity">
    ///     The level of opacity to set on the sublayer on a scale from 0.0 - 1.0 where 0 is fully transparent and 1.0 is fully opaque. If the MapImageLayer.opacity is set, the actual opacity value of the sublayer will be the value of MapImageLayer.opacity multiplied by the sublayer's opacity.
    /// </param>
    /// <param name="popupEnabled">
    ///     Indicates whether to display popups when features in the layer are clicked. The layer's popupTemplate is used to define the content of the popup. If popupEnabled is false, then the popupTemplate is ignored.
    /// </param>
    /// <param name="title">
    ///     The title of the sublayer. This is the name that is displayed to the user in places such as the LayerList widget.
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the layer is visible in the view.
    /// </param>
    /// <param name="definitionExpression">
    ///     A SQL where clause used to filter features in the image. Only the features that satisfy the definition expression are displayed in the View. Definition expressions may be set when a Sublayer is constructed prior to it loading in the view or after it has been added to the MapImageLayer. To see if you can use this property, check the supportsSublayerDefinitionExpression property of MapImageLayer.capabilities.
    /// </param>
    /// <param name="floorInfo">
    ///     If a map image layer contains a sublayer which is meant to be floor-aware, then that sublayer must have a floorInfo property, containing a LayerFloorInfo object which has a string property to represent the floorField.
    /// </param>
    public Sublayer(int? sublayerId = null, bool? labelsVisible = null, bool? legendEnabled = null, 
        ListMode? listMode = null, int? maxScale = null, int? minScale = null, double? opacity = null, 
        bool? popupEnabled = null, string? title = null, bool? visible = null, string? definitionExpression = null, 
        LayerFloorInfo? floorInfo = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        SublayerId = sublayerId;
        LabelsVisible = labelsVisible;
        LegendEnabled = legendEnabled;
        ListMode = listMode;
        MaxScale = maxScale;
        MinScale = minScale;
        Opacity = opacity;
        PopupEnabled = popupEnabled;
        Title = title;
        Visible = visible;
        DefinitionExpression = definitionExpression;
        FloorInfo = floorInfo;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <summary>
    ///     A SQL where clause used to filter features in the image. Only the features that satisfy the definition expression are displayed in the View. Definition expressions may be set when a Sublayer is constructed prior to it loading in the view or after it has been added to the MapImageLayer. To see if you can use this property, check the supportsSublayerDefinitionExpression property of MapImageLayer.capabilities.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }
    
    /// <summary>
    ///     If a map image layer contains a sublayer which is meant to be floor-aware, then that sublayer must have a floorInfo property, containing a LayerFloorInfo object which has a string property to represent the floorField.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LayerFloorInfo? FloorInfo { get; set; }
    
    /// <summary>
    ///     The sublayer's layer ID. When a source is not defined on the layer, this value represents the id of the sublayer defined by the map service. If creating a DynamicDataLayer or a MapDataLayer and adding it to the source property of the sublayer, the value of this property can be anything set by the developer.
    /// </summary>
    /// <remarks>
    ///     This maps to the ArcGIS sublayer.id property.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SublayerId { get; set; }
    
    /// <summary>
    ///     Indicates if labels for the sublayer will be visible in the view.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelsVisible { get; set; }
    
    /// <summary>
    ///     Indicates whether the layer will be included in the legend. When false, the layer will be excluded from the legend.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }
    
    /// <summary>
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ListMode? ListMode { get; set; }
    
    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }
    
    /// <summary>
    ///     The level of opacity to set on the sublayer on a scale from 0.0 - 1.0 where 0 is fully transparent and 1.0 is fully opaque. If the MapImageLayer.opacity is set, the actual opacity value of the sublayer will be the value of MapImageLayer.opacity multiplied by the sublayer's opacity.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }
    
    /// <summary>
    ///     Indicates whether to display popups when features in the layer are clicked. The layer needs to have a popupTemplate to define what information should be displayed in the popup. Alternatively, a default popup template may be automatically used if Popup.defaultPopupTemplateEnabled is set to true.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }
    
    /// <summary>
    ///     The title of the sublayer used to identify it in places such as the LayerList and Legend widgets. This value can be defined in the map service or programmatically by the developer. It can also be useful for finding a specific sublayer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Title { get; set; }
    
    /// <summary>
    ///     Indicates if the layer is visible in the view. To see if you can use this property, check the supportsSublayerVisibility property of MapImageLayer.capabilities.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Visibility { get; set; }
    
    /// <summary>
    ///     The label definition for this layer, specified as an array of LabelClass objects. Use this property to specify labeling properties for the layer such as label expression, placement, and size.
    /// </summary>
    public IReadOnlyCollection<Label> LabelingInfo
    {
        get => _labelingInfo;
        set => _labelingInfo = new HashSet<Label>(value);
    }
    
    /// <summary>
    ///     The popup template for the sublayer. When set, the popupTemplate allows users to access attributes and display their values in the view's popup when the user clicks the image.
    ///     Sublayers with a RasterDataSource cannot be queried and therefore do not support PopupTemplate.
    ///     Alternatively, a default popup template may be automatically used if Popup.defaultPopupTemplateEnabled is set to true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     The renderer to apply to the sublayer. This value overrides the renderer read from the map service. To see if you can use this property, check the supportsDynamicLayers property of MapImageLayer.capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Renderer? Renderer { get; set; }
    
    /// <summary>
    ///     An object that allows you to create a dynamic layer with data either from the map service sublayers or data from a registered workspace. See DynamicMapLayer for creating dynamic layers from map service layers for on the fly rendering, labeling, and filtering (definition expressions). To create dynamic layers from other sources in registered workspaces such as tables and table joins, see DynamicDataLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? Source { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IReadOnlyCollection<Sublayer> Sublayers
    {
        get => _sublayers;
        set => _sublayers = new HashSet<Sublayer>(value);
    }

    /// <summary>
    ///     The MapImageLayer or TileLayer to which the sublayer belongs.
    /// </summary>
    public Layer? Layer => Parent is Sublayer sublayer
        ? sublayer.Layer
        : Parent as Layer;

    public void UpdateFromJavaScript(Sublayer renderedSublayer)
    {
        DefinitionExpression ??= renderedSublayer.DefinitionExpression;
        FloorInfo ??= renderedSublayer.FloorInfo;
        SublayerId ??= renderedSublayer.SublayerId;
        LabelsVisible ??= renderedSublayer.LabelsVisible;
        LegendEnabled ??= renderedSublayer.LegendEnabled;
        ListMode ??= renderedSublayer.ListMode;
        MaxScale ??= renderedSublayer.MaxScale;
        MinScale ??= renderedSublayer.MinScale;
        Opacity ??= renderedSublayer.Opacity;
        PopupEnabled ??= renderedSublayer.PopupEnabled;
        Title ??= renderedSublayer.Title;
        Visibility ??= renderedSublayer.Visibility;
        PopupTemplate ??= renderedSublayer.PopupTemplate;
        Renderer ??= renderedSublayer.Renderer;
        Source ??= renderedSublayer.Source;
        Capabilities ??= renderedSublayer.Capabilities;
        Fields ??= renderedSublayer.Fields;
        FieldsIndex ??= renderedSublayer.FieldsIndex;
        FullExtent ??= renderedSublayer.FullExtent;
        ObjectIdField ??= renderedSublayer.ObjectIdField;
        SourceJSON ??= renderedSublayer.SourceJSON;
        TypeIdField ??= renderedSublayer.TypeIdField;
        Types ??= renderedSublayer.Types;
        Url ??= renderedSublayer.Url;

        foreach (Sublayer renderedSubLayer in renderedSublayer.Sublayers)
        {
            Sublayer? matchingLayer = _sublayers.FirstOrDefault(l => l.Id == renderedSubLayer.Id);

            if (matchingLayer is not null)
            {
                matchingLayer.UpdateFromJavaScript(renderedSubLayer);
            }
            else
            {
                _sublayers.Add(renderedSubLayer);
            }
        }
    }
    
    /// <summary>
    ///     Describes the layer's supported capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public SublayerCapabilities? Capabilities { get; set; }
    
    /// <summary>
    ///     An array of fields in the Sublayer. Each field represents an attribute that may contain a value for each feature in the Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Field[]? Fields { get; set; }

    /// <summary>
    ///     A convenient property that can be used to make case-insensitive lookups for a field by name. It can also provide a list of the date fields in a Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public FieldsIndex? FieldsIndex { get; set; }
    
    /// <summary>
    ///     Rhe full extent of the Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Extent? FullExtent { get; set; }

    /// <summary>
    ///     The name of an oid field containing a unique value or identifier for each feature in the Sublayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ObjectIdField { get; set; }

    /// <summary>
    ///     The map service's metadata JSON exposed by the ArcGIS REST API. While most commonly used properties are exposed on the Sublayer class directly, this property gives access to all information returned by the map service. This property is useful if working in an application built using an older version of the API which requires access to map service properties from a more recent version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? SourceJSON { get; set; }

    /// <summary>
    ///     The name of the field holding the type ID or subtypes for the features. See ArcGIS Pro subtypes document. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? TypeIdField { get; set; }

    /// <summary>
    ///     An array of types defined in the feature service exposed by ArcGIS REST API. Each item includes information about the type, such as the type ID, name, and definition expression. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public FeatureType[]? Types { get; set; }

    /// <summary>
    ///     Rhe URL to the REST endpoint of the sublayer. This allows you to view the schema of fields and query tables located in registered workspaces.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Url { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerFloorInfo floorInfo:
                FloorInfo = floorInfo;
                
                break;
            case Label label:
                _labelingInfo.Add(label);

                break;
            case PopupTemplate popupTemplate:
                PopupTemplate = popupTemplate;
                
                break;
            case Renderer renderer:
                Renderer = renderer;

                break;
            case Sublayer sublayer:
                _sublayers.Add(sublayer);

                break;
            case DynamicLayer dynamicLayer:
                Source = dynamicLayer;

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
            case LayerFloorInfo:
                FloorInfo = null;
                
                break;
            case Label label:
                _labelingInfo.Remove(label);

                break;
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case DynamicLayer:
                Source = null;

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
        FloorInfo?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        Source?.ValidateRequiredChildren();

        foreach (Label label in _labelingInfo)
        {
            label.ValidateRequiredChildren();
        }

        foreach (Sublayer sublayer in _sublayers)
        {
            sublayer.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
    
    private HashSet<Label> _labelingInfo = new();
    private HashSet<Sublayer> _sublayers = new();
}

/// <summary>
///     Describes the layer's supported capabilities.
/// </summary>
/// <param name="Data">
///     Describes characteristics of the data in the layer.
/// </param>
/// <param name="Operations">
///     Describes operations that can be performed on features in the layer.
/// </param>
public record SublayerCapabilities(SublayerData Data, SublayerOperations Operations);

/// <summary>
///     Describes characteristics of the data in the layer.
/// </summary>
/// <param name="SupportsAttachment">
///     Indicates if attachments are enabled on the layer.
/// </param>
public record SublayerData(bool SupportsAttachment);

/// <summary>
///     Describes operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be queried.
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports REST API queryAttachments operation. If false, queryAttachments() method can only return attachments for one feature at a time. If true, queryAttachments() can return attachments for array of objectIds.
/// </param>
public record SublayerOperations(bool SupportsQuery, bool SupportsQueryAttachments);

/// <summary>
///     This class provides convenient methods that can be used to make case-insensitive lookups for a field by its name. It also provides more information such as the list of date fields in a layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FieldsIndex.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FieldsIndex : MapComponent
{
    /// <summary>
    ///     For internal use only, JavaScript object reference.
    /// </summary>
    public IJSObjectReference JsFieldsReference { get; set; } = default!;
    
    /// <summary>
    ///     An array of date fields or field json objects.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Field[]? DateFields { get; set; }

    /// <summary>
    ///     Returns a field with the specified field name.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field. The name is case-insensitive.
    /// </param>
    public async Task<Field> Get(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<Field>("get", fieldName);
    }

    /// <summary>
    ///     Returns a time zone for a field. Use this method to ensure queries in the following places are issued in the time zone of the given date field:
    ///     FeatureLayer.DefinitionExpression
    ///     Query.Where
    ///     FeatureFilter.Where
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field.
    /// </param>
    /// <returns>
    ///     For Date Fields: Returns the time zone associated with the date field. Returns null if the layer's date fields are in unknown time zone.
    ///     For DateOnly, TimeOnly, or TimeStampOffset Fields: Returns null.
    ///     All other fields return null.
    /// </returns>
    public async Task<string?> GetTimeZone(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<string>("getTimeZone", fieldName);
    }

    /// <summary>
    ///     Checks if a field with the specified field name exists in the layer.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field. The name is case-insensitive.
    /// </param>
    public async Task<bool> Has(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<bool>("has", fieldName);
    }
    
    /// <summary>
    ///     Checks if a field with the specified field name is a date field.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field.
    /// </param>
    public async Task<bool> IsDateField(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<bool>("isDateField", fieldName);
    }
}

/// <summary>
///     The output image type of the MapImageLayer.
/// </summary>
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

/// <summary>
///     LayerFloorInfo contains properties that allow a layer to be floor-aware. These properties are used to filter the levels, or floors, of a facility that are displayed. The FloorFilter widget currently supports FeatureLayers, SceneLayers and MapImageLayers (map services).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LayerFloorInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LayerFloorInfo: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public LayerFloorInfo()
    {
    }
    
    /// <summary>
    ///     Creates a new LayerFloorInfo in code with parameters.
    /// </summary>
    /// <param name="floorField">
    ///     The field name derived from a floor-aware layer and used to filter features by floor level.
    /// </param>
    public LayerFloorInfo(string floorField)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        FloorField = floorField;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <summary>
    ///     The field name derived from a floor-aware layer and used to filter features by floor level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FloorField { get; set; }
}

/// <summary>
///     Abstract base class for <see cref="DynamicMapLayer"/> and <see cref="DynamicDataLayer"/>.
/// </summary>
public abstract class DynamicLayer : MapComponent
{
    /// <summary>
    ///     The type of dynamic layer
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     A dynamic map layer refers to a layer published in a map service that has dynamic layers enabled. This layer type may be used to create multiple sublayers that point to the same service layer, but are assigned different definition expressions, renderers, and other properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#DynamicMapLayer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DynamicMapLayer : DynamicLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicMapLayer()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicMapLayer in code with parameters.
    /// </summary>
    /// <param name="mapLayerId">
    ///     The id of the service sublayer.
    /// </param>
    /// <param name="gdbVersion">
    ///     An optional property for specifying the GDB version.
    /// </param>
    public DynamicMapLayer(int mapLayerId, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        MapLayerId = mapLayerId;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <inheritdoc />
    public override string Type => "map-layer";
    
    /// <summary>
    ///     The id of the service sublayer.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public int MapLayerId { get; set; }
    
    /// <summary>
    ///     An optional property for specifying the GDB version.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}

/// <summary>
///     A dynamic data layer is a layer created on-the-fly with data stored in a registered workspace. This is data that can be rendered and queried on the fly, but that isn't explicitly exposed as a service sublayer. Depending on the type of data source, these layers are classified as one of the following:
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#DynamicDataLayer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DynamicDataLayer : DynamicLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicDataLayer()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicDataLayer in code with parameters.
    /// </summary>
    /// <param name="dataSource">
    ///     The data source for the dynamic data layer.
    /// </param>
    /// <param name="fields">
    ///     Controls field visibility in the layer. Only specified fields will be visible. If null, all fields are visible in the dynamic layer. The specification for a field object is provided below.
    /// </param>
    public DynamicDataLayer(DynamicDataSource dataSource, IEnumerable<DynamicLayerField>? fields = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        DataSource = dataSource;

        if (fields is not null)
        {
            _fields = new HashSet<DynamicLayerField>(fields);
        }
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <inheritdoc />
    public override string Type => "data-layer";
    
    /// <summary>
    ///     A table, feature class, or raster that resides in a registered workspace (either a folder or geodatabase). The data sources are not visible in the Services Directory by default. They may be viewed, published, and configured using the ArcGIS Server Manager.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicDataSource? DataSource { get; set; }
    
    /// <summary>
    ///     Controls field visibility in the layer. Only specified fields will be visible. If null, all fields are visible in the dynamic layer. The specification for a field object is provided below.
    /// </summary>
    public IReadOnlyCollection<DynamicLayerField> Fields
    {
        get => _fields;
        set => _fields = new HashSet<DynamicLayerField>(value);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicDataSource dataSource:
                DataSource = dataSource;
                
                break;
            case DynamicLayerField field:
                _fields.Add(field);
                
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
            case DynamicDataSource:
                DataSource = null;
                
                break;
            case DynamicLayerField field:
                _fields.Remove(field);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        DataSource?.ValidateRequiredChildren();

        foreach (DynamicLayerField field in _fields)
        {
            field.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
    
    private HashSet<DynamicLayerField> _fields = new();
}

/// <summary>
///     Abstract base class for data sources in a dynamic data layer.
/// </summary>
public abstract class DynamicDataSource : MapComponent
{
    /// <summary>
    ///     The name of the data source type.
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     A table or feature class that resides in a registered workspace (either a folder or geodatabase). In the case of a geodatabase, if versioned, use version to switch to an alternate geodatabase version.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#TableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public TableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new TableDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="dataSourceName">
    ///     The name of the table in the registered workspace.
    /// </param>
    /// <param name="gdbVersion">
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </param>
    public TableDataSource(string workspaceId, string dataSourceName, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "table";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }
    
    /// <summary>
    ///     The name of the table in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }
    
    /// <summary>
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}

/// <summary>
///     A query table is a feature class or table defined by a SQL query on the fly. Query layers allow both spatial and nonspatial information stored in a database to be easily integrated into map service operations. Since a query table uses SQL to directly query database tables and views, spatial information used by a query table is not required to be in a geodatabase.
///     This data source is useful for scenarios where you have a table containing multiple records that match to a single geometry in either another table or a map service layer. You can use the QueryTableDataSource to select only a subset of those matching records and join them to the table with geometries so records in both tables have a one-to-one relationship with each other.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#QueryTableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class QueryTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public QueryTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new QueryTableDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="query">
    ///     The SQL query used to filter records.
    /// </param>
    /// <param name="oidFields">
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </param>
    /// <param name="geometryType">
    ///     The geometry type of each record in the table.
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </param>
    public QueryTableDataSource(string workspaceId, string query, string? oidFields = null, 
        GeometryType? geometryType = null, SpatialReference? spatialReference = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        Query = query;
        OidFields = oidFields;
        GeometryType = geometryType;
        SpatialReference = spatialReference;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "query-table";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }

    /// <summary>
    ///     The SQL query used to filter records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Query { get; set; }
    
    /// <summary>
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OidFields { get; set; }
    
    /// <summary>
    ///     The geometry type of each record in the table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryType? GeometryType { get; set; }
    
    /// <summary>
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference spatialReference:
                SpatialReference = spatialReference;

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
            case SpatialReference _:
                SpatialReference = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     A file-based raster that resides in a registered raster workspace. The raster may only be displayed in the view, not queried or assigned a renderer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#RasterDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RasterDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public RasterDataSource()
    {
    }

    /// <summary>
    ///     Creates a new RasterDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="dataSourceName">
    ///     The name of the raster in the registered workspace.
    /// </param>
    public RasterDataSource(string workspaceId, string dataSourceName)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "raster";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }
    
    /// <summary>
    ///     The name of the raster in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }
}

/// <summary>
///     The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.
///     <a target="_blank" href="The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class JoinTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public JoinTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new JoinTableDataSource in code with parameters.
    /// </summary>
    /// <param name="leftTableKey">
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </param>
    /// <param name="rightTableKey">
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </param>
    /// <param name="joinType">
    ///     The type of join that will be performed.
    /// </param>
    /// <param name="leftTableSource">
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    /// <param name="rightTableSource">
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    public JoinTableDataSource(string leftTableKey, string rightTableKey, DynamicJoinType joinType,
        DynamicLayer leftTableSource, DynamicLayer rightTableSource)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        LeftTableKey = leftTableKey;
        RightTableKey = rightTableKey;
        JoinType = joinType;
        LeftTableSource = leftTableSource;
        RightTableSource = rightTableSource;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "join-table";
    
    /// <summary>
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LeftTableKey { get; set; }
    
    /// <summary>
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RightTableKey { get; set; }
    
    /// <summary>
    ///     The type of join that will be performed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicJoinType? JoinType { get; set; }
    
    /// <summary>
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? LeftTableSource { get; set; }
    
    /// <summary>
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? RightTableSource { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicLayer dynamicLayer:
                if (LeftTableSource is null)
                {
                    LeftTableSource = dynamicLayer;
                }
                else
                {
                    RightTableSource = dynamicLayer;
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
            case DynamicLayer dynamicLayer:
                if (dynamicLayer.Equals(LeftTableSource))
                {
                    LeftTableSource = null;
                }
                else
                {
                    RightTableSource = null;
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
        LeftTableSource?.ValidateRequiredChildren();
        RightTableSource?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Possible types of joins for a <see cref="JoinTableDataSource"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DynamicJoinType>))]
public enum DynamicJoinType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    LeftOuterJoin,
    LeftInnerJoin
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     Defines fields that should be visible in the <see cref="DynamicDataLayer"/>
/// </summary>
public class DynamicLayerField : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicLayerField()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicLayerField in code with parameters.
    /// </summary>
    /// <param name="name">
    ///     The name of the field.
    /// </param>
    /// <param name="alias">
    ///     The alias of the field.
    /// </param>
    public DynamicLayerField(string name, string? alias = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        Name = name;
        Alias = alias;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <summary>
    ///     The name of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    ///     The alias of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Alias { get; set; }
}