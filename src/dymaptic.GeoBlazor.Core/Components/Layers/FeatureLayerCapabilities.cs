namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Describes the layer's supported capabilities.
/// </summary>
/// <param name="Analytics">
///     Describes what analytics capabilities are enabled on the layer.
/// </param>
/// <param name="Attachment">
///     Describes what attachment capabilities are enabled on the layer.
/// </param>
/// <param name="Data">
///     Describes characteristics of the data in the layer.
/// </param>
/// <param name="Editing">
///     Describes editing capabilities that can be performed on the features in the layer via ApplyEdits().
/// </param>
/// <param name="Metadata">
///     Describes the metadata contained on features in the layer.
/// </param>
/// <param name="Operations">
///     Describes operations that can be performed on features in the layer.
/// </param>
/// <param name="Query">
///     Describes query operations that can be performed on features in the layer.
/// </param>
/// <param name="QueryRelated">
///     Indicates if the layer's query operation supports querying features or records related to features in the layer.
/// </param>
/// <param name="QueryTopFeatures">
///     Describes top features query operations that can be performed on features in the layer.
/// </param>
public record FeatureLayerCapabilities(AnalyticsCapability Analytics, AttachmentCapability Attachment,
    DataCapability Data, EditingCapability Editing, MetadataCapability Metadata, OperationsCapability Operations,
    QueryCapability Query, QueryRelatedCapability QueryRelated, QueryTopFeaturesCapability QueryTopFeatures);

/// <summary>
///     Describes what analytics capabilities are enabled on the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the feature service supports cache hint.
/// </param>
public record AnalyticsCapability(bool SupportsCacheHint);

/// <summary>
///     Describes what attachment capabilities are enabled on the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the attachment operations support a cache hint. This is valid only for hosted feature services.
/// </param>
/// <param name="SupportsContentType">
///     Indicates if the attachments can be queried by their content types.
/// </param>
/// <param name="SupportsExifInfo">
///     Indicates if the attachment queries support exifInfo.
/// </param>
/// <param name="SupportsKeywords">
///     Indicates if the attachments can be queried by their keywords.
/// </param>
/// <param name="SupportsName">
///     Indicates if the attachments can be queried by their names.
/// </param>
/// <param name="SupportsSize">
///     Indicates if the attachments can be queried by their sizes.
/// </param>
/// <param name="SupportsResize">
///     Indicates if resized attachments are supported in the feature layer. This is useful for showing thumbnails in Popups.
/// </param>
public record AttachmentCapability(bool SupportsCacheHint, bool SupportsContentType, bool SupportsExifInfo,
    bool SupportsKeywords, bool SupportsName, bool SupportsSize, bool SupportsResize);

/// <summary>
///     Describes characteristics of the data in the layer.
/// </summary>
/// <param name="IsVersioned">
///     Indicates if the feature service is versioned.
/// </param>
/// <param name="SupportsAttachment">
///     Indicates if the attachment is enabled on the layer.
/// </param>
/// <param name="SupportsM">
///     Indicates if the features in the layer support m-values.
/// </param>
/// <param name="SupportsZ">
///     Indicates if the features in the layer support z-values. See elevationInfo for details regarding placement and rendering of features with z-values in 3D SceneViews.
/// </param>
public record DataCapability(bool IsVersioned, bool SupportsAttachment, bool SupportsM, bool SupportsZ);

/// <summary>
///     Describes editing capabilities that can be performed on the features in the layer via ApplyEdits().
/// </summary>
/// <param name="SupportsDeleteByAnonymous">
///     Indicates if anonymous users can delete features created by others.
/// </param>
/// <param name="SupportsDeleteByOthers">
///     Indicates if logged in users can delete features created by others.
/// </param>
/// <param name="SupportsGeometryUpdate">
///     Indicates if the geometry of the features in the layer can be edited.
/// </param>
/// <param name="SupportsGlobalId">
///     Indicates if the globalId values provided by the client are used in applyEdits.
/// </param>
/// <param name="SupportsRollbackOnFailure">
///     Indicates if the globalId values provided by the client are used in applyEdits.
/// </param>
/// <param name="SupportsUpdateByAnonymous">
///     Indicates if anonymous users can update features created by others.
/// </param>
/// <param name="SupportsUpdateByOthers">
///     Indicates if logged in users can update features created by others.
/// </param>
/// <param name="SupportsUploadWithItemId">
///     Indicates if the layer supports uploading attachments by UploadId.
/// </param>
/// <param name="SupportsUpdateWithoutM">
///     Indicates if m-values must be provided when updating features.
/// </param>
public record EditingCapability(bool SupportsDeleteByAnonymous, bool SupportsDeleteByOthers, bool SupportsGeometryUpdate,
    bool SupportsGlobalId, bool SupportsRollbackOnFailure, bool SupportsUpdateByAnonymous, bool SupportsUpdateByOthers,
    bool SupportsUploadWithItemId, bool SupportsUpdateWithoutM);

/// <summary>
///     Describes the metadata contained on features in the layer.
/// </summary>
/// <param name="SupportsAdvancedFieldProperties">
///     Indicates whether to provide a user-defined field description. See Describe attribute fields for additional information.
/// </param>
public record MetadataCapability(bool SupportsAdvancedFieldProperties);

/// <summary>
///     Describes operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsAdd">
///     Indicates if new features can be added to the layer.
/// </param>
/// <param name="SupportsCalculate">
///     Indicates if values of one or more field values in the layer can be updated. See the Calculate REST operation document for more information.
/// </param>
/// <param name="SupportsDelete">
///     Indicates if features can be deleted from the layer.
/// </param>
/// <param name="SupportsEditing">
///     Indicates if features in the layer can be edited. Use supportsAdd, supportsUpdate and supportsDelete to determine which editing operations are supported.
/// </param>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be queried.
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports REST API queryAttachments operation. If false, queryAttachments() method can only return attachments for one feature at a time. If true, queryAttachments() can return attachments for array of objectIds.
/// </param>
/// <param name="SupportsQueryTopFeatures">
///     Indicates if the layer supports REST API queryTopFeatures operation.
/// </param>
/// <param name="SupportsUpdate">
///     Indicates if features in the layer can be updated.
/// </param>
/// <param name="SupportsValidateSql">
///     Indicates if the layer supports a SQL-92 expression or where clause.
/// </param>
public record OperationsCapability(bool SupportsAdd, bool SupportsCalculate, bool SupportsDelete, bool SupportsEditing,
    bool SupportsQuery, bool SupportsQueryAttachments, bool SupportsQueryTopFeatures, bool SupportsUpdate, 
    bool SupportsValidateSql);

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

/// <summary>
///     List of supported aggregated geometries returned for each distinct group when groupByFieldsForStatistics is used.
/// </summary>
/// <param name="Centroid">
///     Indicates if the layer can return centroid for each distinct group for groupByFieldsForStatistics.
/// </param>
/// <param name="Envelope">
///     Indicates if the layer can return extent for each distinct group for groupByFieldsForStatistics.
/// </param>
/// <param name="ConvexHull">
///     Indicates if the layer can return convex hull for each distinct group for groupByFieldsForStatistics.
/// </param>
public record SupportedSpatialStatisticAggregations(bool Centroid, bool Envelope, bool ConvexHull);

/// <summary>
///     Indicates if the layer's query operation supports querying features or records related to features in the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the relationship query operation supports a cache hint. This is valid only for hosted feature services.
/// </param>
/// <param name="SupportsCount">
///     Indicates if the layer's query response includes the number of features or records related to features in the layer.
/// </param>
/// <param name="SupportsOrderBy">
///     Indicates if the related features or records returned in the query response can be ordered by one or more fields.
/// </param>
/// <param name="SupportsPagination">
///     Indicates if the query response supports pagination for related features or records.
/// </param>
public record QueryRelatedCapability(bool SupportsCacheHint, bool SupportsCount, bool SupportsOrderBy,
    bool SupportsPagination);

/// <summary>
///     Describes top features query operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the top query operation supports a cache hint. This is valid only for hosted feature services.
/// </param>
public record QueryTopFeaturesCapability(bool SupportsCacheHint);