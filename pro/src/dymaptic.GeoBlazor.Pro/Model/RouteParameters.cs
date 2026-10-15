namespace dymaptic.GeoBlazor.Pro.Model;


/// <summary>
///     Input parameters for route. Specifies details such as stop locations, barrier locations, the impedance attribute, etc.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RouteParameters.html">ArcGIS SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public record RouteParameters
{
    /// <summary>
    ///     Use this property to specify whether the operation should accumulate values other than the value specified for impedanceAttribute. For example, if your impedanceAttribute is set to TravelTime, the total travel time for the route will be calculated by the operation. However, if you also want to calculate the total distance of the route in miles, you can specify Miles as the value for the accumulateAttributes property.
    /// </summary>
    /// <remarks>
    ///     See also <a target="_blank" href="https://desktop.arcgis.com/en/arcmap/latest/extensions/network-analyst/understanding-network-attributes.htm">Understanding the network attribute.</a>
    ///     See also <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/route-sync-services.htm#ESRI_SECTION2_021FFBC4CA30405C8A32C31E471C82DE">accumulateAttributeNames</a>
    /// </remarks>
    public AccumulateAttribute[]? AccumulateAttributes { get; set; }
    
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer dashboard. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    public string? ApiKey { get; set; }
    
    /// <summary>
    ///     Use this property to specify additional values required by an attribute or restriction, such as to specify whether the restriction prohibits, avoids, or prefers travel on restricted roads. If the restriction is meant to avoid or prefer roads, you can further specify the degree to which they are avoided or preferred using this property. For example, you can choose to never use toll roads, avoid them as much as possible, or prefer them.
    /// </summary>
    public AttributeParameterValue[]? AttributeParameterValues { get; set; }
    
    /// <summary>
    ///     The language that will be used when generating travel directions. This parameter applies only when the returnDirections parameter is set to true. The service supports generating directions in the following languages: ar, bg, bs, ca, cs, da, de, el, en, es, et, fi, fr, he, hr, hu, id, it, ja, ko, lt, lv, nb, nl, pl, pt-BR, pt-PT, ro, ru, sk, sl, sr, sv, th, tr, uk, vi, zh-CN, zh-HK and zh-TW.
    /// </summary>
    public string? DirectionsLanguage { get; set; }
    
    /// <summary>
    ///     Specify the units for displaying travel distance in the driving directions. This property applies only when the returnDirections property is set to true.
    /// </summary>
    public DirectionsLengthUnits? DirectionsLengthUnits { get; set; }
    
    /// <summary>
    ///     Define the content and verbosity of the driving directions. This property applies only when the returnDirections property is set to true.
    /// </summary>
    public DirectionsOutputType? DirectionsOutputType { get; set; }
    
    /// <summary>
    ///     Specify the name of the formatting style for the directions. This property applies only when the returnDirections property is set to true.
    /// </summary>
    public DirectionsStyleName? DirectionsStyleName { get; set; }
    
    /// <summary>
    ///     Set the time-based impedance attribute to display the duration of a maneuver, such as "Go northwest on Alvorado St. for 5 minutes." The units for all the time attributes is minutes.
    /// </summary>
    public DirectionsTimeAttribute? DirectionsTimeAttribute { get; set; }
    
    /// <summary>
    ///     Use this property to specify whether the operation should reorder stops to find the optimized route. If the property value is false, the operation returns a route that visits stops in the order you define. If the parameter value is true, the operation finds the best order to visit the stops. The operation will account for a variety of variables so that the total travel distance or travel time for the route is minimized. You can elect to preserve the origin and the destination stops while allowing the operation to reorder intermediary stops by setting the preserveFirstStop and preserveLastStop properties.
    /// </summary>
    public bool? FindBestSequence { get; set; }
    
    /// <summary>
    ///     Use this property to specify the number of decimal places in the response geometries returned by solve operation. This applies to x- and y-values only (not m- or z-values).
    /// </summary>
    public int? GeometryPrecision { get; set; }
    
    /// <summary>
    ///     Use this property to specify the number of decimal places in the response geometries returned by solve operation. This applies to m-value only (not x-,y- or z-values).
    /// </summary>
    public int? GeometryPrecisionM { get; set; }
    
    /// <summary>
    ///     Use this property to specify the number of decimal places in the response geometries returned by a solve operation. This applies to z-value only (not x-,y- or m-values).
    /// </summary>
    public int? GeometryPrecisionZ { get; set; }
    
    /// <summary>
    ///     Specify whether invalid input locations should be ignored when finding the best solution. An input point is deemed invalid by the operation if it is not within the maximum snap tolerance of any traversable street. When true invalid points are ignored. When false any invalid point in your request will cause the operation to return a failure.
    /// </summary>
    public bool? IgnoreInvalidLocations { get; set; }
    
    /// <summary>
    ///     Specifies the impedance.
    ///     Impedance is a value that quantifies travel along the transportation network. Travel distance is an example of impedance; it quantifies the length of walkways and road segments. Similarly, drive time—the typical time it takes to drive a car along a road segment—is an example of impedance. This property will be ignored if travelMode is set.
    /// </summary>
    public ImpedanceAttribute? ImpedanceAttribute { get; set; }
    
    /// <summary>
    ///     Use this property to specify by how much you want to simplify the route geometry returned by the operation. Simplification maintains critical points on a route, such as turns at intersections, to define the essential shape of the route and removes other points. The value of this property, regardless of whether you rely on the default or explicitly set a value, is overridden when you pass in travelMode.
    ///     The units are specified with the <see cref="OutputGeometryPrecisionUnits"/> parameter.
    /// </summary>
    public double? OutputGeometryPrecision { get; set; }
    
    /// <summary>
    ///     Use this property to specify the units for the value specified for the outputGeometryPrecision parameter. The value of this parameter, regardless of whether you rely on the default or explicitly set a value, is overridden when you pass in travelMode.
    /// </summary>
    public OutputGeometryPrecisionUnits? OutputGeometryPrecisionUnits { get; set; }
    
    /// <summary>
    ///     Use this property to specify the type of route features that are output by the operation. This parameter is applicable only if the returnRoutes parameter is set to true.
    /// </summary>
    public OutputLines? OutputLines { get; set; }
    
    /// <summary>
    ///     Use this property to specify the spatial reference of the geometries, such as line or point features, returned by a solve operation.
    /// </summary>
    public SpatialReference? OutSpatialReference { get; set; }
    
    /// <summary>
    ///     Use this property to specify one or more points that will act as temporary restrictions or represent additional time or distance that may be required to travel on the underlying streets. For example, a point barrier can be used to represent a fallen tree along a street or a time delay spent at a railroad crossing.
    /// </summary>
    public IEnumerable<PointBarrier>? PointBarriers { get; set; }
    
    /// <summary>
    ///     Use this property to specify polygons that either completely restrict travel or proportionately scale the time or distance required to travel on the streets intersected by the polygons.
    /// </summary>
    public IEnumerable<PolygonBarrier>? PolygonBarriers { get; set; }
    
    /// <summary>
    ///     Use this property to specify one or more lines that prohibit travel anywhere the lines intersect the streets. For example, a parade or protest that blocks traffic across several street segments can be modeled with a line barrier.
    /// </summary>
    public IEnumerable<PolylineBarrier>? PolylineBarriers { get; set; }
    
    /// <summary>
    ///     Use this property to indicate whether the operation should keep the first stop fixed when reordering the stops. This property is applicable only if the findBestSequence parameter value is true.
    /// </summary>
    public bool? PreserveFirstStop { get; set; }
    
    /// <summary>
    ///     Use this property to indicate whether the operation should keep the last stop fixed when reordering the stops. This property is applicable only if the findBestSequence parameter value is true.
    /// </summary>
    public bool? PreserveLastStop { get; set; }
   
    /// <summary>
    ///     Use this property to specify if the Object IDs specified for input locations such as stops or barriers should be preserved when the input locations are returned as output.
    /// </summary>
    public bool? PreserveObjectId { get; set; }
    
    /// <summary>
    ///     Use this property to specify which restrictions should be honored by the operation. A restriction represents a driving preference or requirement. This value is ignored if travelMode is specified.
    /// </summary>
    public RestrictionAttribute[]? RestrictionAttributes { get; set; }
    
    /// <summary>
    ///     Use this property to restrict or permit the route from making U-turns at junctions. This value is ignored if travelMode is specified.
    /// </summary>
    public RestrictUTurns? RestrictUTurns { get; set; }
    
    /// <summary>
    ///     Specify whether point barriers will be returned by the routing operation.
    ///     Default Value: false
    /// </summary>
    public bool? ReturnBarriers { get; set; }
    
    /// <summary>
    ///     Specify whether the operation should generate driving directions for each route. If true directions are configured based on the values for the directionsLanguage, directionsOutputType, directionsStyleName, and directionsLengthUnits properties.
    ///     Default Value:false
    /// </summary>
    public bool? ReturnDirections { get; set; }
    
    /// <summary>
    ///     Specify whether polygon barriers will be returned by the routing operation.
    ///     Default Value:false
    /// </summary>
    public bool? ReturnPolygonBarriers { get; set; }
    
    /// <summary>
    ///     Specify whether polyline barriers will be returned by the routing operation.
    ///     Default Value:false
    /// </summary>
    public bool? ReturnPolylineBarriers { get; set; }
    
    /// <summary>
    ///     Use this property to specify if the operation should return routes. If true, the shape of the routes depends on the value for the outputLines property.
    ///     Default Value:true
    /// </summary>
    public bool? ReturnRoutes { get; set; }
    
    /// <summary>
    ///     Use this property to specify whether stops will be returned by the routing operation.
    ///     Default Value:false
    /// </summary>
    public bool? ReturnStops { get; set; }
    
    /// <summary>
    ///     Specify whether traversed edges will be returned by the operation.
    /// </summary>
    public bool? ReturnTraversedEdges { get; set; }
    
    /// <summary>
    ///     Specify whether traversed junctions will be returned by the operation.
    /// </summary>
    public bool? ReturnTraversedJunctions { get; set; }
    
    /// <summary>
    ///     Specify whether traversed turns will be returned by the operation.
    /// </summary>
    public bool? ReturnTraversedTurns { get; set; }
    
    /// <summary>
    ///     Include z values for the returned geometries if supported by the underlying network.
    ///     Default Value:true
    /// </summary>
    public bool? ReturnZ { get; set; }
    
    /// <summary>
    ///     Specifies the locations the output route or routes will visit.
    /// </summary>
    public FeatureSet? FeatureSetStops { get; set; }

    /// <summary>
    ///     Specifies the locations the output route or routes will visit.
    /// </summary>
    /// <remarks>
    ///     Not supporting a collection of <see cref="RouteStop"/> objects until this underlying bug is fixed in ArcGIS JS: https://community.esri.com/t5/arcgis-javascript-maps-sdk-questions/route-layer-javascript-api-4-24-issue-route-layer/m-p/1219564
    /// </remarks>
    [Obsolete("Not working, bug in ArcGIS. Use FeatureSetStops instead.")]
    public RouteStop[]? RouteStops
    {
        get => null;
        set => throw new NotImplementedException("There is a bug in ArcGIS that prevents us from using this collection. Use FeatureSetStops instead.");
    }

    /// <summary>
    ///     Specify whether the timeWindowStart and timeWindowEnd property values on stops are specified in UTC or geographically local time.
    /// </summary>
    public bool? TimeWindowsAreUTC { get; set; }
    
    /// <summary>
    ///     A travel mode represents a means of transportation, such as driving or walking. Travel modes define the physical characteristics of a vehicle or pedestrian.
    ///     Use <see cref="NetworkService.FetchServiceDescription"/> to obtain a list of predefined travel modes and the default travel mode that is used if one is not specified in a routing request.
    /// </summary>
    public TravelMode? TravelMode { get; set; }
    
    /// <summary>
    ///     Specify whether hierarchy should be used when finding the shortest paths. This value is ignored if a TravelMode is specified.
    /// </summary>
    public bool? UseHierarchy { get; set; }
    
    /// <summary>
    ///     Use this property to indicate whether the operation should consider time windows specified on the stops when finding the best route. The time windows are specified on stops using the TimeWindowStart and TimeWindowEnd properties.
    /// </summary>
    public bool? UseTimeWindows { get; set; }
}