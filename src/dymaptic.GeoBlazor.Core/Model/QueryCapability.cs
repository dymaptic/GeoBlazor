namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes query operations that can be performed on features in the layer.
/// </summary>
/// <param name="MaxRecordCount">
///     The maximum number of records that will be returned for a given query.
/// </param>
/// <param name="SupportsCacheHint">
///     Indicates if the query operation supports a cache hint. This is valid only for hosted feature services.
/// </param>
/// <param name="SupportsCentroid">
///     Indicates if the geometry centroid associated with each polygon feature can be returned.
/// </param>
/// <param name="SupportsDisjointSpatialRelationship">
///     Indicates if the query operation supports disjoint spatial relationship. This is valid only for hosted feature services.
/// </param>
/// <param name="SupportsDistance">
///     Indicates if the layer's query operation supports a buffer distance for input geometries.
/// </param>
/// <param name="SupportsDistinct">
///     Indicates if the layer supports queries for distinct values based on fields specified in the outFields.
/// </param>
/// <param name="SupportsExtent">
///     Indicates if the layer's query response includes the extent of features.
/// </param>
/// <param name="SupportsGeometryProperties">
///     Indicates if the layer's query response contains geometry attributes, including shape area and length attributes.
/// </param>
/// <param name="SupportsHavingClause">
///     Indicates if the layer supports the having clause on the service.
/// </param>
/// <param name="SupportsHistoricMoment">
///     Indicates if the layer supports historic moment query.
/// </param>
/// <param name="SupportsOrderBy">
///     Indicates if features returned in the query response can be ordered by one or more fields.
/// </param>
/// <param name="SupportsPagination">
///     Indicates if the query response supports pagination.
/// </param>
/// <param name="SupportsPercentileStatistics">
///     Indicates if the layer supports percentile statisticType.
/// </param>
/// <param name="SupportsQuantization">
///     Indicates if the query operation supports the projection of geometries onto a virtual grid.
/// </param>
/// <param name="SupportsQuantizationEditMode">
///     Indicates if the query operation supports quantization designed to be used in edit mode (highest resolution at the given spatial reference).
/// </param>
/// <param name="SupportsQueryGeometry">
///     Indicates if the query response includes the query geometry.
/// </param>
/// <param name="SupportsResultType">
///     Indicates if the number of features returned by the query operation can be controlled.
/// </param>
/// <param name="SupportsStandardizedQueriesOnly">
///     Indicates if the layer supports using standardized queries. Learn more about standardized queries here.
/// </param>
/// <param name="SupportsStatistics">
///     Indicates if the layer supports field-based statistical functions.
/// </param>
/// <param name="SupportsSqlExpression">
///     Indicates if the layer supports SQL expressions.
/// </param>
/// <param name="SupportsSpatialAggregationStatistics">
///     Indicates if the layer supports spatial extent, center or convex hull to be returned for each distinct group when groupByFieldsForStatistics is used. Supported with ArcGIS Online hosted features services only.
/// </param>
/// <param name="SupportedSpatialStatisticAggregations">
///     List of supported aggregated geometries returned for each distinct group when groupByFieldsForStatistics is used.
/// </param>
public record QueryCapability(int MaxRecordCount, bool SupportsCacheHint, bool SupportsCentroid,
    bool SupportsDisjointSpatialRelationship, bool SupportsDistance, bool SupportsDistinct, bool SupportsExtent,
    bool SupportsGeometryProperties, bool SupportsHavingClause, bool SupportsHistoricMoment, bool SupportsOrderBy,
    bool SupportsPagination, bool SupportsPercentileStatistics, bool SupportsQuantization,
    bool SupportsQuantizationEditMode, bool SupportsQueryGeometry, bool SupportsResultType,
    bool SupportsStandardizedQueriesOnly, bool SupportsStatistics, bool SupportsSqlExpression,
    bool SupportsSpatialAggregationStatistics,
    SupportedSpatialStatisticAggregations SupportedSpatialStatisticAggregations);