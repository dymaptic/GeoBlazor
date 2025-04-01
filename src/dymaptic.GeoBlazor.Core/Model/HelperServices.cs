namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Provides access to various ArcGIS helper services and endpoints
/// </summary>
public record HelperServices
{
    /// <summary>
    ///     AI assistant services for various natural language processing tasks
    /// </summary>
    public AiAssistantServices? AiAssistantServices { get; init; }

    /// <summary>
    ///     Utility services for AI-related operations like translation and text extraction
    /// </summary>
    public AiUtilityServices? AiUtilityServices { get; init; }

    /// <summary>
    ///     Asynchronous closest facility routing service
    /// </summary>
    public AsyncRoutingService? AsyncClosestFacility { get; init; }

    /// <summary>
    ///     Asynchronous fleet routing service
    /// </summary>
    public AsyncFleetRouting? AsyncFleetRouting { get; init; }

    /// <summary>
    ///     Asynchronous location allocation service
    /// </summary>
    public AsyncRoutingService? AsyncLocationAllocation { get; init; }

    /// <summary>
    ///     Asynchronous origin-destination cost matrix service
    /// </summary>
    public AsyncRoutingService? AsyncODCostMatrix { get; init; }

    /// <summary>
    ///     Asynchronous print task service
    /// </summary>
    public AsyncPrintTask? AsyncPrintTask { get; init; }

    /// <summary>
    ///     Asynchronous route service
    /// </summary>
    public AsyncRoutingService? AsyncRoute { get; init; }

    /// <summary>
    ///     Asynchronous service area calculation service
    /// </summary>
    public AsyncRoutingService? AsyncServiceArea { get; init; }

    /// <summary>
    ///     Asynchronous vehicle routing problem service
    /// </summary>
    public AsyncRoutingService? AsyncVRP { get; init; }

    /// <summary>
    ///     Synchronous closest facility routing service
    /// </summary>
    public RoutingService? ClosestFacility { get; init; }

    /// <summary>
    ///     Service for working with dashboards
    /// </summary>
    public UrlService? DashboardsUtility { get; init; }

    /// <summary>
    ///     Collection of default elevation layers
    /// </summary>
    public IReadOnlyCollection<ElevationLayerService>? DefaultElevationLayers { get; init; }

    /// <summary>
    ///     Elevation service
    /// </summary>
    public UrlService? Elevation { get; init; }

    /// <summary>
    ///     Synchronous elevation service
    /// </summary>
    public UrlService? ElevationSync { get; init; }

    /// <summary>
    ///     Collection of geocode services
    /// </summary>
    public IReadOnlyCollection<GeocodeService>? Geocode { get; init; }

    /// <summary>
    ///     Geometry service for spatial operations
    /// </summary>
    public UrlService? Geometry { get; init; }

    /// <summary>
    ///     Hydrology service for water-related analysis
    /// </summary>
    public UrlService? Hydrology { get; init; }

    /// <summary>
    ///     Service for layout information tasks
    /// </summary>
    public UrlService? LayoutInfoTask { get; init; }

    /// <summary>
    ///     Origin-destination cost matrix service
    /// </summary>
    public RoutingService? OdCostMatrix { get; init; }

    /// <summary>
    ///     Orthomapping elevation service
    /// </summary>
    public UrlService? OrthomappingElevation { get; init; }

    /// <summary>
    ///     Service for packaging maps and data for offline use
    /// </summary>
    public PackagingService? Packaging { get; init; }

    /// <summary>
    ///     Print task service for creating printable maps
    /// </summary>
    public PrintTaskService? PrintTask { get; init; }

    /// <summary>
    ///     Route service for calculating paths between locations
    /// </summary>
    public RoutingService? Route { get; init; }

    /// <summary>
    ///     Utilities for routing operations
    /// </summary>
    public UrlService? RoutingUtilities { get; init; }

    /// <summary>
    ///     Service area calculation service
    /// </summary>
    public RoutingService? ServiceArea { get; init; }

    /// <summary>
    ///     Service for snapping points to roads
    /// </summary>
    public RoutingService? SnapToRoads { get; init; }

    /// <summary>
    ///     Symbol server for accessing map symbols
    /// </summary>
    public UrlService? Symbols { get; init; }

    /// <summary>
    ///     Synchronous vehicle routing problem service
    /// </summary>
    public RoutingService? SyncVRP { get; init; }

    /// <summary>
    ///     Traffic information service
    /// </summary>
    public UrlService? Traffic { get; init; }

    /// <summary>
    ///     Traffic data service
    /// </summary>
    public UrlService? TrafficData { get; init; }

    /// <summary>
    ///     Workflow manager service
    /// </summary>
    public UrlService? WorkflowManager { get; init; }

    /// <summary>
    ///     Analysis service for spatial analysis tasks
    /// </summary>
    public UrlService? Analysis { get; init; }

    /// <summary>
    ///     Geoenrichment service for adding demographic data
    /// </summary>
    public UrlService? Geoenrichment { get; init; }

    /// <summary>
    ///     Asynchronous geocoding service
    /// </summary>
    public UrlService? AsyncGeocode { get; init; }

    /// <summary>
    ///     Service for estimating credits for operations
    /// </summary>
    public UrlService? CreditEstimation { get; init; }

    /// <summary>
    ///     Service for tracking locations
    /// </summary>
    public UrlService? LocationTracking { get; init; }

    /// <summary>
    ///     Service for raster analysis operations
    /// </summary>
    public UrlService? RasterAnalytics { get; init; }

    /// <summary>
    ///     Utilities for raster operations
    /// </summary>
    public UrlService? RasterUtilities { get; init; }

    /// <summary>
    ///     Service for managing datastores
    /// </summary>
    public UrlService? DatastoreManagement { get; init; }

    /// <summary>
    ///     Service for data pipeline operations
    /// </summary>
    public UrlService? DataPipelines { get; init; }

    /// <summary>
    ///     Service for analysis models
    /// </summary>
    public UrlService? AnalysisModels { get; init; }
}

/// <summary>
///     Provides access to AI assistant services for various natural language processing tasks
/// </summary>
public record AiAssistantServices
{
    /// <summary>
    ///     Base URL for AI assistant services
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Path for the documentation chat assistant service
    /// </summary>
    public string? DocChatAssistant { get; init; }

    /// <summary>
    ///     Path for the SQL generation assistant service
    /// </summary>
    public string? SqlGenerationAssistant { get; init; }

    /// <summary>
    ///     Path for the graph query generation assistant service
    /// </summary>
    public string? GraphQueryAssistant { get; init; }

    /// <summary>
    ///     Path for the question answering assistant service
    /// </summary>
    public string? QuestionAnswerAssistant { get; init; }

    /// <summary>
    ///     Path for the item information suggester service
    /// </summary>
    public string? ItemInformationAssistant { get; init; }
}

/// <summary>
///     Provides access to AI utility services for operations like translation
/// </summary>
public record AiUtilityServices
{
    /// <summary>
    ///     Base URL for AI utility services
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Path for the translation utility service
    /// </summary>
    public string? TranslateUtility { get; init; }

    /// <summary>
    ///     Path for the image text extraction service
    /// </summary>
    public string? ImageExtractTextUtility { get; init; }
}

/// <summary>
///     Base service providing a URL endpoint
/// </summary>
public record UrlService
{
    /// <summary>
    ///     URL for accessing the service
    /// </summary>
    public string? Url { get; init; }
}

/// <summary>
///     Asynchronous routing service with travel mode support
/// </summary>
public record AsyncRoutingService
{
    /// <summary>
    ///     URL for accessing the asynchronous routing service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Default travel mode identifier for routing
    /// </summary>
    public string? DefaultTravelMode { get; init; }
}

/// <summary>
///     Asynchronous fleet routing service
/// </summary>
public record AsyncFleetRouting
{
    /// <summary>
    ///     URL for accessing the fleet routing service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Default travel mode identifier for fleet routing
    /// </summary>
    public string? DefaultTravelMode { get; init; }
}

/// <summary>
///     Asynchronous print task service
/// </summary>
public record AsyncPrintTask
{
    /// <summary>
    ///     URL for accessing the asynchronous print service
    /// </summary>
    public string? Url { get; init; }
}

/// <summary>
///     Synchronous routing service with travel mode support
/// </summary>
public record RoutingService
{
    /// <summary>
    ///     URL for accessing the routing service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Default travel mode identifier for routing
    /// </summary>
    public string? DefaultTravelMode { get; init; }
}

/// <summary>
///     Service for accessing elevation layer data
/// </summary>
public record ElevationLayerService
{
    /// <summary>
    ///     URL for accessing the elevation layer
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Unique identifier for the elevation layer
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    ///     Type of the elevation layer
    /// </summary>
    public string? LayerType { get; init; }

    /// <summary>
    ///     Units of measurement for elevation values
    /// </summary>
    public string? Units { get; init; }
}

/// <summary>
///     Service for geocoding addresses and locations
/// </summary>
public record GeocodeService
{
    /// <summary>
    ///     URL for accessing the geocode service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Parameter name for northern latitude boundary
    /// </summary>
    public string? NorthLat { get; init; }

    /// <summary>
    ///     Parameter name for southern latitude boundary
    /// </summary>
    public string? SouthLat { get; init; }

    /// <summary>
    ///     Parameter name for eastern longitude boundary
    /// </summary>
    public string? EastLon { get; init; }

    /// <summary>
    ///     Parameter name for western longitude boundary
    /// </summary>
    public string? WestLon { get; init; }

    /// <summary>
    ///     Display name for the geocode service
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    ///     Indicates if the service supports batch geocoding
    /// </summary>
    public bool Batch { get; init; }

    /// <summary>
    ///     Indicates if the service supports place finding
    /// </summary>
    public bool Placefinding { get; init; }

    /// <summary>
    ///     Indicates if the service supports address suggestions
    /// </summary>
    public bool Suggest { get; init; }
}

/// <summary>
///     Service for packaging maps and data for offline use
/// </summary>
public record PackagingService
{
    /// <summary>
    ///     URL for accessing the packaging service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Maximum number of items allowed in a map area
    /// </summary>
    public int MaxMapAreaItemsLimit { get; init; }

    /// <summary>
    ///     Mapping of source URLs to export URLs for tile services
    /// </summary>
    public List<ExportTileMap>? ExportTilesMap { get; init; }
}

/// <summary>
///     Mapping between source and export URLs for tile services
/// </summary>
public record ExportTileMap
{
    /// <summary>
    ///     Source URL for tile service
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    ///     Export URL for tile service
    /// </summary>
    public string? Export { get; init; }
}

/// <summary>
///     Service for print tasks to create printable maps
/// </summary>
public record PrintTaskService
{
    /// <summary>
    ///     URL for accessing the print task service
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    ///     Available print templates
    /// </summary>
    public List<PrintTemplateService>? Templates { get; init; }
}

/// <summary>
///     Template configuration for print services
/// </summary>
public record PrintTemplateService
{
    /// <summary>
    ///     Format of the output (e.g., PNG32, PDF)
    /// </summary>
    public string? Format { get; init; }

    /// <summary>
    ///     Display label for the template
    /// </summary>
    public string? Label { get; init; }

    /// <summary>
    ///     Layout identifier for the template
    /// </summary>
    public string? Layout { get; init; }

    /// <summary>
    ///     Additional layout options for printing
    /// </summary>
    public PrintLayoutOptions? LayoutOptions { get; init; }
}

/// <summary>
///     Options for configuring print layouts
/// </summary>
public record PrintLayoutOptions
{
    /// <summary>
    ///     Indicates whether to include a legend in the printed output
    /// </summary>
    public bool Legend { get; init; }
}