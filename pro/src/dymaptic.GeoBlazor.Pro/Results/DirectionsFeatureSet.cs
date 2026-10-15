namespace dymaptic.GeoBlazor.Pro.Results;

/// <summary>
///     DirectionsFeatureSet is a subclass of FeatureSet that contains street directions for a solved route.
///     DirectionsFeatureSet is only returned when a route is solved with an directions output type of "complete", "complete-no-events", "instructions-only", "standard", or "summary-only". The "featuresets" output type returns two regular FeatureSet, one for events, and the other for the path in-between events.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-DirectionsFeatureSet.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public record DirectionsFeatureSet : FeatureSet
{
    /// <summary>
    ///     The extent of the route.
    /// </summary>
    public Extent? Extent { get; set; }
    /// <summary>
    ///     A single polyline representing the route.
    /// </summary>
    public Polyline? MergedGeometry { get; set; }
    /// <summary>
    ///     The ID of the route.
    /// </summary>
    public long? RouteId { get; set; }
    /// <summary>
    ///     The name of the route.
    /// </summary>
    public string? RouteName { get; set; }
    /// <summary>
    ///     A flattened array of all direction strings.
    /// </summary>
    public DirectionsString[]? Strings { get; set; }
    /// <summary>
    ///     The total drive time for the route. Temporal units are defined by RouteParameters.DirectionsTimeAttribute in a Route.Solve() request.
    /// </summary>
    public double? TotalDriveTime { get; set; }
    /// <summary>
    ///     The total length of the route. Length units are defined by RouteParameters.DirectionsLengthUnits in a Route.Solve() request.
    /// </summary>
    public double? TotalLength { get; set; }
    /// <summary>
    ///     The total time for the route including wait and service time. Temporal units are defined by RouteParameters.DirectionsTimeAttribute in a Route.Solve() request.
    /// </summary>
    public double? TotalTime { get; set; }
}