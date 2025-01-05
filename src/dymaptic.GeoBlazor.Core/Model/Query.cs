using ParameterValue = Microsoft.AspNetCore.Components.ParameterValue;

namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     This class defines parameters for executing queries for features from a layer or layer view. Once a Query object's
///     properties are defined, it can then be passed into an executable function, which will return the features in a
///     FeatureSet.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record Query
{
    /// <summary>
    ///     A where clause for the query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }

    /// <summary>
    ///     For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view
    ///     against the input geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialRelationship? SpatialRelationship { get; set; }

    /// <summary>
    ///     The geometry to apply to the spatial filter.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    /// <summary>
    ///     Attribute fields to include in the FeatureSet.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OutFields { get; set; }

    /// <summary>
    ///     If true, each feature in the returned FeatureSet includes the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnGeometry { get; set; }

    /// <summary>
    ///     Determines whether to use the view's extent as the query geometry
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewExtent { get; set; }

    /// <summary>
    ///     An array of Object IDs representing aggregate (i.e. cluster) graphics. This property should be used to query
    ///     features represented by one or more cluster graphics with the given Object IDs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<int>? AggregateIds { get; set; }

    /// <summary>
    ///     Indicates if the service should cache the query results. It only applies if the layer's
    ///     capabilities.query.supportsCacheHint is set to true. Use only for queries that have the same parameters every time
    ///     the app is used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CacheHint { get; set; }

    /// <summary>
    ///     Datum transformation used for projecting geometries in the query results when outSpatialReference is different than
    ///     the layer's spatial reference. Requires ArcGIS Server service 10.5 or greater.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? DatumTransformation { get; set; }

    /// <summary>
    ///     Specifies a search distance from a given geometry in a spatial query. The units property indicates the unit of
    ///     measurement. In essence, setting this property creates a buffer at the specified size around the input geometry.
    ///     The query will use that buffer to return features in the layer or layer view that adhere to the indicated spatial
    ///     relationship.
    ///     If querying a feature service, the supportsQueryWithDistance capability must be true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Distance { get; set; }

    /// <summary>
    ///     Specifies the geodatabase version to display for feature service queries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }

    /// <summary>
    ///     Specifies the number of decimal places for geometries returned by the JSON query operation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? GeometryPrecision { get; set; }

    /// <summary>
    ///     Used only in statistical queries. When one or more field names are provided in this property, the output statistics
    ///     will be grouped based on unique values from those fields. This is only valid when outStatistics has been defined.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? GroupByFieldsForStatistics { get; set; }

    /// <summary>
    ///     A condition used with outStatistics and groupByFieldsForStatistics to limit query results to groups that satisfy
    ///     the aggregation function(s).
    ///     The following aggregation functions are supported in this clause: MIN | MAX | AVG | SUM | STDDEV | COUNT | VAR
    ///     Aggregation functions used in having must be included in the outStatistics as well. See the snippet below for an
    ///     example of how this works.
    ///     For service-based layer queries, this parameter applies only if the supportsHavingClause property of the layer is
    ///     true. This property is supported on all LayerView queries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Having { get; set; }

    /// <summary>
    ///     The historic moment to query. This parameter applies only if the supportsQueryWithHistoricMoment capability of the
    ///     service being queried is true. This setting is provided in the layer resource.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? HistoricMoment { get; set; }

    /// <summary>
    ///     The maximum distance in units of outSpatialReference used for generalizing geometries returned by the query
    ///     operation. It limits how far any part of the generalized geometry can be from the original geometry. If
    ///     outSpatialReference is not defined, the spatialReference of the data is used.
    /// </summary>
    /// <remarks>
    ///     This property does not apply to LayerView or CSVLayer queries.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxAllowableOffset { get; set; }

    /// <summary>
    ///     When set, the maximum number of features returned by the query will equal the maxRecordCount of the service
    ///     multiplied by this factor. The value of this property may not exceed 5.
    /// </summary>
    /// <remarks>
    ///     Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6 services.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxRecordCountFactor { get; set; }

    /// <summary>
    ///     The number of features to retrieve. This option should be used in conjunction with the start property. Use this to
    ///     implement paging (i.e. to retrieve "pages" of results when querying).
    ///     If not provided, but an instance of Query has a start property, then the default value of num is 10. If neither num
    ///     nor start properties are provided, then the default value of num is equal to the maxRecordCount of the service,
    ///     which can be found at the REST endpoint of the FeatureLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Num { get; set; }

    /// <summary>
    ///     An array of ObjectIDs to be used to query for features in a layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<long>? ObjectIds { get; set; }

    /// <summary>
    ///     One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the
    ///     field name to control the order. The default order is ASC.
    /// </summary>
    /// <remarks>
    ///     If querying a MapImageLayer, then supportsAdvancedQueries must be true on the service.
    ///     For FeatureLayer, FeatureLayer.capabilities.queryRelated.supportsOrderBy must be true.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OrderByFields { get; set; }

    /// <summary>
    ///     The spatial reference for the returned geometry. If not specified, the geometry is returned in the spatial
    ///     reference of the queried layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? OutSpatialReference { get; set; }

    /// <summary>
    ///     The definitions for one or more field-based statistics to be calculated. If outStatistics is specified the only
    ///     other query parameters that should be used are groupByFieldsForStatistics, orderByFields, text, and where.
    /// </summary>
    /// <remarks>
    ///     For service-based queries, outStatistics is only supported on layers where supportsStatistics = true.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<StatisticDefinition>? OutStatistics { get; set; }

    /// <summary>
    ///     Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any
    ///     parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS
    ///     Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ParameterValue>? ParameterValues { get; set; }

    /// <summary>
    ///     Used to project the geometry onto a virtual grid, likely representing pixels on the screen. Geometry coordinates
    ///     are converted to integers by building a grid with a resolution matching the quantizationParameters.tolerance. Each
    ///     coordinate is then snapped to one pixel on the grid.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QuantizationParameters? QuantizationParameters { get; set; }

    /// <summary>
    ///     Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services
    ///     10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<RangeValue>? RangeValues { get; set; }

    /// <summary>
    ///     The Dimensionally Extended 9 Intersection Model (DE-9IM) matrix relation (encoded as a string) to query the spatial
    ///     relationship of the input geometry to the layer's features. This string contains the test result of each
    ///     intersection represented in the DE-9IM matrix. Each result is one character of the string and may be represented as
    ///     either a number (maximum dimension returned: 0,1,2), a Boolean value (T or F), or a mask character (for ignoring
    ///     results: '*').
    ///     Set this parameter when the spatialRelationship is relation. The Relational functions for ST_Geometry topic has
    ///     additional details on how to construct these strings.
    /// </summary>
    /// <remarks>
    ///     This property does not apply to layer view or CSVLayer queries.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RelationParameter { get; set; }

    /// <summary>
    ///     If true, each feature in the returned FeatureSet will be returned with a centroid. This property only applies to
    ///     queries against polygon FeatureLayers.
    /// </summary>
    /// <remarks>
    ///     Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6.1 services.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnCentroid { get; set; }

    /// <summary>
    ///     If true then the query returns distinct values based on the field(s) specified in outFields.
    /// </summary>
    /// <remarks>
    ///     For service-based queries, this parameter applies only if the supportsAdvancedQueries capability of the layer is
    ///     true.
    ///     Make sure to set returnGeometry to false when returnDistinctValues is true. Otherwise, reliable results will not be
    ///     returned.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnDistinctValues { get; set; }

    /// <summary>
    ///     If true, then all features are returned for each tile request, even if they exceed the maximum record limit per
    ///     query indicated on the service by maxRecordCount. If false, the tile request will not return any features if the
    ///     maxRecordCount limit is exceeded.
    ///     Default Value: true
    /// </summary>
    /// <remarks>
    ///     Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6 services.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnExceededLimitFeatures { get; set; }

    /// <summary>
    ///     If true, and returnGeometry is true, then m-values are included in the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnM { get; set; }

    /// <summary>
    ///     If true, the query geometry will be returned with the query results. It is useful for getting the buffer geometry
    ///     generated when querying features by distance or getting the query geometry projected in the outSpatialReference of
    ///     the query. The query geometry is returned only for client-side queries and hosted feature services and if the
    ///     layer's capabilities.query.supportsQueryGeometry is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnQueryGeometry { get; set; }

    /// <summary>
    ///     If true, and returnGeometry is true, then z-values are included in the geometry.
    /// </summary>
    /// <remarks>
    ///     FeatureLayerView.queryFeatures(), GeoJSONLayerView.queryFeatures(), and OGCFeatureLayerView.queryFeatures() results
    ///     do not include the z-values when called in 2D MapView even if returnZ is set to true.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnZ { get; set; }

    /// <summary>
    ///     This parameter can be either standard SQL92 standard or it can use the native SQL of the underlying datastore
    ///     native. See the ArcGIS REST API documentation for more information.
    /// </summary>
    /// <remarks>
    ///     This property does not apply to layer view or CSVLayer queries.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SqlFormat? SqlFormat { get; set; }

    /// <summary>
    ///     The zero-based index indicating where to begin retrieving features. This property should be used in conjunction
    ///     with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending
    ///     by object ID by default.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Start { get; set; }

    /// <summary>
    ///     Shorthand for a where clause using "like". The field used is the display field defined in the services directory.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>
    ///     A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes
    ///     that occurred during the night shift from 10 PM to 6 AM on a particular date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    ///     The unit for calculating the buffer distance when distance is specified in spatial queries. If units is not
    ///     specified, the unit is derived from the geometry spatial reference. If the geometry spatial reference is not
    ///     specified, the unit is derived from the feature service data spatial reference. For service-based queries, this
    ///     parameter only applies if the layer's capabilities.query.supportsDistance is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryEngineLinearUnit? Units { get; set; }
}


