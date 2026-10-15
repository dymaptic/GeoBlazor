namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     A stop represents the start, end, or midpoint of a route in RouteLayer or RouteParameters.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Stop.html">ArcGIS SDK for JavaScript</a>
/// </summary>
public record RouteStop
{
    /// <summary>
    ///     The date and time value indicating the arrival time at the stop.
    /// </summary>
    public DateTime? ArriveTime { get; set; }
    
    /// <summary>
    ///     The local time offset (in minutes) for the arrival time.
    /// </summary>
    public double? ArriveTimeOffset { get; set; }
    
    /// <summary>
    ///     Specify the direction a vehicle may arrive at and depart from the stop.
    /// </summary>
    public StopCurbApproach? CurbApproach { get; set; }
    
    /// <summary>
    ///     The date and time value indicating the departure time from the stop.
    /// </summary>
    public DateTime? DepartTime { get; set; }
    
    /// <summary>
    ///     The local time offset (in minutes) for the departure time.
    /// </summary>
    public double? DepartTimeOffset { get; set; }
    
    /// <summary>
    ///     The point location of the stop.
    /// </summary>
    public Point? Geometry { get; set; }
    
    /// <summary>
    ///     The type of stop.
    /// </summary>
    public StopLocationType? LocationType { get; set; }
    
    /// <summary>
    ///     The name of the stop. The name is used in the driving directions. If the name is not specified, a unique name prefixed with Location is automatically generated in the output stops, routes, and directions.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    ///     If the findBestSequence parameter is set to false, the output routes will visit the stops in the order you specify with this attribute. In a group of stops that have the same RouteName value, the sequence number should be greater than 0 but not greater than the total number of stops. Also, the sequence number should not be duplicated.
    /// </summary>
    public int? Sequence { get; set; }
    
    /// <summary>
    ///     Indicates the status of the point with respect to its location on the network and the outcome of the analysis.
    /// </summary>
    public StopStatus? Status { get; set; }
    
    /// <summary>
    ///     The latest time the route can visit the stop. The values for this field are copied from the TimeWindowEnd field on the input stops.
    /// </summary>
    public DateTime? TimeWindowEnd { get; set; }
    
    /// <summary>
    ///     The earliest time the route can visit the stop. The values for this field are copied from the TimeWindowStart field on the input stops.
    /// </summary>
    public DateTime? TimeWindowStart { get; set; }
}