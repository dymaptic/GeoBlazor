using dymaptic.GeoBlazor.Core.Components.Geometries;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     This class defines parameters for executing queries for related records from a layer. Once a RelationshipQuery
///     object's properties are defined, it can then be passed into the query.executeRelationshipQuery() and
///     FeatureLayer.queryRelatedFeatures() methods, which will return FeatureSets grouped by source layer/table objectIds.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html#maxAllowableOffset">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class RelationshipQuery
{
    /// <summary>
    ///     Indicates if the service should cache the relationship query results. It only applies if the layer's
    ///     capabilities.queryRelated.supportsCacheHint is set to true. Use only for queries that have the same parameters
    ///     every time the app is used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CacheHint { get; set; }

    /// <summary>
    ///     Specify the geodatabase version to query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }

    /// <summary>
    ///     Specify the number of decimal places for the geometries returned by the query operation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GeometryPrecision { get; set; }

    /// <summary>
    ///     The historic moment to query. This parameter applies only if the supportsHistoricMoment on FeatureLayer property of
    ///     the layer is set to true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? HistoricMoment { get; set; }

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
    /// <remarks>
    ///     Known Limitations
    ///     - If querying a MapImageLayer, then supportsAdvancedQueries must be true on the service.
    ///     - For FeatureLayer, FeatureLayer.capabilities.queryRelated.supportsOrderBy must be true.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OrderByFields { get; set; }

    /// <summary>
    ///     Attribute fields to include in the FeatureSet. Fields must exist in the map layer. You must list actual field names
    ///     rather than the alias names. You are, however, able to use the alias names when you display the results.
    ///     When specifying the output fields, you should limit the fields to only those you expect to use in the query or the
    ///     results. The fewer fields you include, the faster the response will be.
    ///     Each query must have access to the Shape and ObjectId fields for a layer. However, your list of fields does not
    ///     need to include these two fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OutFields { get; set; }

    /// <summary>
    ///     The spatial reference for the returned geometry. If outSpatialReference is not defined, the spatialReference of the
    ///     view is used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? OutSpatialReference { get; set; }

    /// <summary>
    ///     The ID of the relationship to be queried. The ids for the relationships the table or layer participates in are
    ///     listed in the ArcGIS Services directory. The ID of the relationship to be queried. The relationships that this
    ///     layer/table participates in are included in the Feature Service Layer resource response. Records in tables/layers
    ///     corresponding to the related table/layer of the relationship are queried.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RelationshipId { get; set; }

    /// <summary>
    ///     If true, each feature in the FeatureSet includes the geometry. Set to false (default) if you do not plan to include
    ///     highlighted features on a map since the geometry makes up a significant portion of the response.
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
    ///     The zero-based index indicating where to begin retrieving features. This property should be used in conjunction
    ///     with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending
    ///     by object ID by default.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Start { get; set; }

    /// <summary>
    ///     The definition expression to be applied to the related table or layer. Only records in the list of objectIds that
    ///     satisfy the definition expression are queried for related records.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
}