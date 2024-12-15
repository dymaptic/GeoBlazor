using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Enums;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     This class defines parameters for executing top features queries from a FeatureLayer. Once a TopFeaturesQuery
///     object's properties are defined, it can then be passed into executable functions on a server-side FeatureLayer,
///     which can return a FeatureSet containing features within a group. For example, you can use FeatureLayer's
///     queryTopFeatures() method to query the most populous three counties in each state of the United States.
///     This class has many of the same properties as Query class. However, unlike the Query class, this class does not
///     support properties such as outStatistics and its related parameters or returnDistinctValues.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record TopFeaturesQuery
{
    /// <summary>
    ///     Indicates if the service should cache the query results. It only applies if the layer's
    ///     capabilities.queryTopFeatures.supportsCacheHint is set to true. Use only for queries that have the same parameters
    ///     every time the app is used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CacheHint { get; set; }

    /// <summary>
    ///     Specifies a search distance from a given geometry in a spatial query. The units property indicates the unit of
    ///     measurement. In essence, setting this property creates a buffer at the specified size around the input geometry.
    ///     The query will use that buffer to return features in the layer or layer view that adhere to the to the indicated
    ///     spatial relationship.
    ///     If querying a feature service, the supportsQueryWithDistance capability must be true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Distance { get; set; }

    /// <summary>
    ///     The geometry to apply to the spatial filter. The spatial relationship as specified by spatialRelationship will
    ///     indicate how the geometry should be used to query features.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Mesh geometry types are currently not supported.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    /// <summary>
    ///     Specify the number of decimal places for the geometries returned by the query operation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GeometryPrecision { get; set; }

    /// <summary>
    ///     The maximum allowable offset used for generalizing geometries returned by the query operation. The offset is in the
    ///     units of outSpatialReference. If outSpatialReference is not defined, the spatialReference of the view is used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxAllowableOffset { get; set; }

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
    ///     An array of objectIds for the features in the layer/table being queried.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<int>? ObjectIds { get; set; }

    /// <summary>
    ///     One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the
    ///     field name to control the order. The default order is ASC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OrderByFields { get; set; }

    /// <summary>
    ///     Attribute fields to include in the FeatureSet. Fields must exist in the service layer. You must list actual field
    ///     names rather than field aliases. You may, however, use field aliases when you display the results of the query.
    ///     When specifying the output fields, you should limit the fields to only those you expect to use in the query or the
    ///     results. The fewer fields you include, the smaller the payload size, and therefore the faster the response of the
    ///     query.
    ///     You can also specify SQL expressions as outFields to calculate new values server side for the query results. See
    ///     the example snippets below for an example of this.
    ///     Each query must have access to the Shape and ObjectId fields for a layer. However, the list of outFields does not
    ///     need to include these two fields.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: If specifying outFields as expressions on a feature service-based FeatureLayer, the service
    ///     capabilities advancedQueryCapabilities.supportsOutFieldSQLExpression and useStandardizedQueries must both be true.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OutFields { get; set; }

    /// <summary>
    ///     The spatial reference for the returned geometry. If not specified, the geometry is returned in the spatial
    ///     reference of the queried layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? OutSpatialReference { get; set; }

    /// <summary>
    ///     If true, each feature in the returned FeatureSet includes the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnGeometry { get; set; }

    /// <summary>
    ///     If true, and returnGeometry is true, then m-values are included in the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnM { get; set; }

    /// <summary>
    ///     If true, and returnGeometry is true, then z-values are included in the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnZ { get; set; }

    /// <summary>
    ///     For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view
    ///     against the input geometry. The spatial relationships discover how features are spatially related to each other.
    ///     For example, you may want to know if a polygon representing a county completely contains points representing
    ///     settlements.
    ///     The spatial relationship is determined by whether the boundaries or interiors of a geometry intersect.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialRelationship? SpatialRelationship { get; set; }

    /// <summary>
    ///     The zero-based index indicating where to begin retrieving features. This property should be used in conjunction
    ///     with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending
    ///     by object ID by default.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Start { get; set; }

    /// <summary>
    ///     A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes
    ///     that occurred during the night shift from 10 PM to 6 AM on a particular date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    ///     A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes
    ///     that occurred during the night shift from 10 PM to 6 AM on a particular date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TopFilter? TopFilter { get; set; }

    /// <summary>
    ///     The unit for calculating the buffer distance when distance is specified in spatial queries. If units is not
    ///     specified, the unit is derived from the geometry spatial reference. If the geometry spatial reference is not
    ///     specified, the unit is derived from the feature service data spatial reference. For service-based queries, this
    ///     parameter only applies if the layer's capabilities.query.supportsDistance is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LinearUnit? Units { get; set; }

    /// <summary>
    ///     A where clause for the query. Any legal SQL where clause operating on the fields in the layer is allowed. Be sure
    ///     to have the correct sequence of single and double quotes when writing the where clause in JavaScript.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
}

/// <summary>
///     This class defines the top filter parameters for executing top features queries for features from a FeatureLayer.
///     This parameter must be set on the TopFeaturesQuery object when calling any of top query methods on a FeatureLayer.
///     It is used to set the groupByFields, orderByFields, and count criteria used the top features query. For example,
///     you can use FeatureLayer's queryTopFeatures() method to query the most populous three counties in each state of the
///     United States.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFilter.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record TopFilter(IReadOnlyList<string>? GroupByFields, IReadOnlyList<string>? OrderByFields, int? TopCount)
{
    /// <summary>
    ///     When one or more field names are provided in this property, the output result will be grouped based on unique
    ///     values from those fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? GroupByFields { get; set; } = GroupByFields;

    /// <summary>
    ///     One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the
    ///     field name to control the order. The default order is ASC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? OrderByFields { get; set; } = OrderByFields;

    /// <summary>
    ///     Defines the number of features to be returned from the top features query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TopCount { get; set; } = TopCount;
}