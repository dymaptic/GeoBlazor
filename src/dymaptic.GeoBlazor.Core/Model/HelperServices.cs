using System.Collections.Generic;

namespace dymaptic.GeoBlazor.Core.Model;

public record HelperServices
{
    public AiAssistantServices? AiAssistantServices { get; init; }
    public AiUtilityServices? AiUtilityServices { get; init; }
    public AsyncRoutingService? AsyncClosestFacility { get; init; }
    public AsyncFleetRouting? AsyncFleetRouting { get; init; }
    public AsyncRoutingService? AsyncLocationAllocation { get; init; }
    public AsyncRoutingService? AsyncODCostMatrix { get; init; }
    public AsyncPrintTask? AsyncPrintTask { get; init; }
    public AsyncRoutingService? AsyncRoute { get; init; }
    public AsyncRoutingService? AsyncServiceArea { get; init; }
    public AsyncRoutingService? AsyncVRP { get; init; }
    public RoutingService? ClosestFacility { get; init; }
    public UrlService? DashboardsUtility { get; init; }
    public IReadOnlyCollection<ElevationLayerService>? DefaultElevationLayers { get; init; }
    public UrlService? Elevation { get; init; }
    public UrlService? ElevationSync { get; init; }
    public IReadOnlyCollection<GeocodeService>? Geocode { get; init; }
    public UrlService? Geometry { get; init; }
    public UrlService? Hydrology { get; init; }
    public UrlService? LayoutInfoTask { get; init; }
    public RoutingService? OdCostMatrix { get; init; }
    public UrlService? OrthomappingElevation { get; init; }
    public PackagingService? Packaging { get; init; }
    public PrintTaskService? PrintTask { get; init; }
    public RoutingService? Route { get; init; }
    public UrlService? RoutingUtilities { get; init; }
    public RoutingService? ServiceArea { get; init; }
    public RoutingService? SnapToRoads { get; init; }
    public UrlService? Symbols { get; init; }
    public RoutingService? SyncVRP { get; init; }
    public UrlService? Traffic { get; init; }
    public UrlService? TrafficData { get; init; }
    public UrlService? WorkflowManager { get; init; }
    public UrlService? Analysis { get; init; }
    public UrlService? Geoenrichment { get; init; }
    public UrlService? AsyncGeocode { get; init; }
    public UrlService? CreditEstimation { get; init; }
    public UrlService? LocationTracking { get; init; }
    public UrlService? RasterAnalytics { get; init; }
    public UrlService? RasterUtilities { get; init; }
    public UrlService? DatastoreManagement { get; init; }
    public UrlService? DataPipelines { get; init; }
    public UrlService? AnalysisModels { get; init; }
}

public record AiAssistantServices
{
    public string? Url { get; init; }
    public string? DocChatAssistant { get; init; }
    public string? SqlGenerationAssistant { get; init; }
    public string? GraphQueryAssistant { get; init; }
    public string? QuestionAnswerAssistant { get; init; }
    public string? ItemInformationAssistant { get; init; }
}

public record AiUtilityServices
{
    public string? Url { get; init; }
    public string? TranslateUtility { get; init; }
    public string? ImageExtractTextUtility { get; init; }
}

public record UrlService
{
    public string? Url { get; init; }
}

public record AsyncRoutingService
{
    public string? Url { get; init; }
    public string? DefaultTravelMode { get; init; }
}

public record AsyncFleetRouting
{
    public string? Url { get; init; }
    public string? DefaultTravelMode { get; init; }
}

public record AsyncPrintTask
{
    public string? Url { get; init; }
}

public record RoutingService
{
    public string? Url { get; init; }
    public string? DefaultTravelMode { get; init; }
}

public record ElevationLayerService
{
    public string? Url { get; init; }
    public string? Id { get; init; }
    public string? LayerType { get; init; }
    public string? Units { get; init; }
}

public record GeocodeService
{
    public string? Url { get; init; }
    public string? NorthLat { get; init; }
    public string? SouthLat { get; init; }
    public string? EastLon { get; init; }
    public string? WestLon { get; init; }
    public string? Name { get; init; }
    public bool Batch { get; init; }
    public bool Placefinding { get; init; }
    public bool Suggest { get; init; }
}

public record PackagingService
{
    public string? Url { get; init; }
    public int MaxMapAreaItemsLimit { get; init; }
    public List<ExportTileMap>? ExportTilesMap { get; init; }
}

public record ExportTileMap
{
    public string? Source { get; init; }
    public string? Export { get; init; }
}

public record PrintTaskService
{
    public string? Url { get; init; }
    public List<PrintTemplateService>? Templates { get; init; }
}

public record PrintTemplateService
{
    public string? Format { get; init; }
    public string? Label { get; init; }
    public string? Layout { get; init; }
    public PrintLayoutOptions? LayoutOptions { get; init; }
}

public record PrintLayoutOptions
{
    public bool Legend { get; init; }
}