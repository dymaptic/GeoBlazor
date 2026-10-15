namespace dymaptic.GeoBlazor.Pro.Model;


/// <summary>
///     Models the full JSON shape returned by an ArcGIS Feature Service layer-metadata REST endpoint (<c>.../FeatureServer/{layerId}</c>).
/// </summary>
public partial record FeatureLayerMetadata
{
    /// <summary>
    ///     The current service version.
    /// </summary>
    [JsonPropertyName("currentVersion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CurrentVersion { get; init; }

    /// <summary>
    ///     The layer ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Id { get; init; }

    /// <summary>
    ///     The layer name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; init; }

    /// <summary>
    ///     The layer type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; init; }

    /// <summary>
    ///     The portal item ID for the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceItemId { get; init; }

    /// <summary>
    ///     The maximum cache age.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CacheMaxAge { get; init; }

    /// <summary>
    ///     The display field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayField { get; init; }

    /// <summary>
    ///     The layer description.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }

    /// <summary>
    ///     The copyright text.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CopyrightText { get; init; }

    /// <summary>
    ///     Whether the layer is visible by default.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DefaultVisibility { get; init; }

    /// <summary>
    ///     The editing information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LayerEditingInfo? EditingInfo { get; init; }

    /// <summary>
    ///     The layer relationships.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Relationship>? Relationships { get; init; }

    /// <summary>
    ///     Whether the layer is versioned.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsDataVersioned { get; init; }

    /// <summary>
    ///     Whether contingent values are defined.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasContingentValuesDefinition { get; init; }

    /// <summary>
    ///     Whether append is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAppend { get; init; }

    /// <summary>
    ///     Whether calculate is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsCalculate { get; init; }

    /// <summary>
    ///     Whether async calculate is supported.
    /// </summary>
    [JsonPropertyName("supportsASyncCalculate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsASyncCalculate { get; init; }

    /// <summary>
    ///     Whether truncate is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsTruncate { get; init; }

    /// <summary>
    ///     Whether attachments by upload ID are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAttachmentsByUploadId { get; init; }

    /// <summary>
    ///     Whether attachment resizing is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAttachmentsResizing { get; init; }

    /// <summary>
    ///     Whether rollback on failure is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsRollbackOnFailureParameter { get; init; }

    /// <summary>
    ///     Whether statistics are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsStatistics { get; init; }

    /// <summary>
    ///     Whether exceeds-limit statistics are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsExceedsLimitStatistics { get; init; }

    /// <summary>
    ///     Whether advanced queries are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAdvancedQueries { get; init; }

    /// <summary>
    ///     Whether SQL validation is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsValidateSql { get; init; }

    /// <summary>
    ///     Whether coordinate quantization is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsCoordinatesQuantization { get; init; }

    /// <summary>
    ///     Whether layer overrides are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsLayerOverrides { get; init; }

    /// <summary>
    ///     Whether tiles and basic query mode is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsTilesAndBasicQueriesMode { get; init; }

    /// <summary>
    ///     Whether the field description property is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsFieldDescriptionProperty { get; init; }

    /// <summary>
    ///     Whether quantization edit mode is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsQuantizationEditMode { get; init; }

    /// <summary>
    ///     Whether column store indexes are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsColumnStoreIndex { get; init; }

    /// <summary>
    ///     Whether applyEdits with global IDs is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsApplyEditsWithGlobalIds { get; init; }

    /// <summary>
    ///     Whether returning query geometry is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsReturningQueryGeometry { get; init; }

    /// <summary>
    ///     Whether null geometry is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableNullGeometry { get; init; }

    /// <summary>
    ///     The advanced query capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdvancedQueryCapabilities? AdvancedQueryCapabilities { get; init; }

    /// <summary>
    ///     The advanced analytic query capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdvancedQueryAnalyticCapabilities? AdvancedQueryAnalyticCapabilities { get; init; }

    /// <summary>
    ///     The query bins capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QueryBinsCapabilities? QueryBinsCapabilities { get; init; }

    /// <summary>
    ///     The operations supported with collation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedOperationsWithCollation { get; init; }

    /// <summary>
    ///     The advanced editing capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdvancedEditingCapabilities? AdvancedEditingCapabilities { get; init; }

    /// <summary>
    ///     The information included in estimates.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? InfoInEstimates { get; init; }

    /// <summary>
    ///     Whether standardized queries are used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseStandardizedQueries { get; init; }

    /// <summary>
    ///     The geometry type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryType? GeometryType { get; init; }

    /// <summary>
    ///     The minimum scale.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; init; }

    /// <summary>
    ///     The maximum scale.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; init; }

    /// <summary>
    ///     The layer extent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; init; }

    /// <summary>
    ///     The spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; init; }

    /// <summary>
    ///     The drawing information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DrawingInfo? DrawingInfo { get; init; }

    /// <summary>
    ///     Whether geometry updates are allowed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllowGeometryUpdates { get; init; }

    /// <summary>
    ///     Whether attachments are present.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasAttachments { get; init; }

    /// <summary>
    ///     The HTML popup type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HtmlPopupType { get; init; }

    /// <summary>
    ///     Whether M values are present.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasM { get; init; }

    /// <summary>
    ///     Whether Z values are present.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasZ { get; init; }

    /// <summary>
    ///     The object ID field name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjectIdField { get; init; }

    /// <summary>
    ///     The unique ID field metadata.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UniqueIdField? UniqueIdField { get; init; }

    /// <summary>
    ///     The global ID field name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GlobalIdField { get; init; }

    /// <summary>
    ///     The type ID field name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TypeIdField { get; init; }

    /// <summary>
    ///     The collation settings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Collation? Collation { get; init; }

    /// <summary>
    ///     The layer fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<LayerMetadataField>? Fields { get; init; }

    /// <summary>
    ///     The layer indexes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<LayerMetadataIndex>? Indexes { get; init; }

    /// <summary>
    ///     The time reference used by date fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeReference? DateFieldsTimeReference { get; init; }

    /// <summary>
    ///     The preferred time reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeReference? PreferredTimeReference { get; init; }

    /// <summary>
    ///     The feature types.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<FeatureType>? Types { get; init; }

    /// <summary>
    ///     The layer templates.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<LayerMetadataTemplate>? Templates { get; init; }

    /// <summary>
    ///     The supported query formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedQueryFormats { get; init; }

    /// <summary>
    ///     The supported append formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedAppendFormats { get; init; }

    /// <summary>
    ///     The supported append source filter formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedAppendSourceFilterFormats { get; init; }

    /// <summary>
    ///     The supported export formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedExportFormats { get; init; }

    /// <summary>
    ///     The supported convert-file formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedConvertFileFormats { get; init; }

    /// <summary>
    ///     The supported convert-content formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedConvertContentFormats { get; init; }

    /// <summary>
    ///     The supported spatial relationships.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? SupportedSpatialRelationships { get; init; }

    /// <summary>
    ///     The GUID format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GuidFormat { get; init; }

    /// <summary>
    ///     Whether contingent values are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsContingentValues { get; init; }

    /// <summary>
    ///     The supported contingent-values formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedContingentValuesFormats { get; init; }

    /// <summary>
    ///     Whether field groups are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsFieldGroups { get; init; }

    /// <summary>
    ///     The supported sync data options.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SupportedSyncDataOptions { get; init; }

    /// <summary>
    ///     Whether static data is present.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasStaticData { get; init; }

    /// <summary>
    ///     The maximum record count.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxRecordCount { get; init; }

    /// <summary>
    ///     The standard maximum record count.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StandardMaxRecordCount { get; init; }

    /// <summary>
    ///     The standard maximum record count when no geometry is returned.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StandardMaxRecordCountNoGeometry { get; init; }

    /// <summary>
    ///     The tile maximum record count.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TileMaxRecordCount { get; init; }

    /// <summary>
    ///     The maximum record count factor.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxRecordCountFactor { get; init; }

    /// <summary>
    ///     The service capabilities string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Capabilities { get; init; }
}


/// <summary>
///     Layer-level editing timestamps (epoch milliseconds) returned by the Feature Service REST endpoint.
/// </summary>
public partial record LayerEditingInfo(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? LastEditDate = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? SchemaLastEditDate = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? DataLastEditDate = null);


/// <summary>
///     Capabilities of advanced spatial/attribute queries exposed by a Feature Service layer.
/// </summary>
public partial record AdvancedQueryCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPagination = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPaginationOnAggregatedQueries = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryRelatedPagination = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithDistance = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsOutDistance = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturningQueryExtent = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsStatistics = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsOrderBy = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDistinct = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithResultType = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSqlExpression = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsTimeRelation = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAdvancedQueryRelated = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsCountDistinct = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPercentileStatistics = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsApproxPercentileStatistics = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSpatialAggregationStatistics = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsLod = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithLodSR = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturningGeometryCentroid = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturningGeometryEnvelope = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithDatumTransformation = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsCurrentUserQueries = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsHavingClause = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsOutFieldSQLExpression = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsMaxRecordCountFactor = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsTopFeaturesQuery = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDisjointSpatialRel = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithCacheHint = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryAnalytic = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryPivot = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryBins = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDefaultSR = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsTranslations = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAggIds = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryWithCollation = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsISODOW = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsISOWeek = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsFullTextSearch = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedSpatialAggregationStatistics = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedLodTypes = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedOperationsWithCacheHint = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    FullTextSearchCapabilities? FullTextSearchCapabilities = null);


/// <summary>
///     Full-text search options supported by a Feature Service layer.
/// </summary>
public partial record FullTextSearchCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAccentSensitivity = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsStopWords = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSearchOperator = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsOperator = null);


/// <summary>
///     Analytic query capabilities (regression, trendline, percentile) for a Feature Service layer.
/// </summary>
public partial record AdvancedQueryAnalyticCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsLinearRegression = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsTrendlineRegression = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAsync = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPercentileAnalytic = null);


/// <summary>
///     Bin/histogram query capabilities for a Feature Service layer.
/// </summary>
public partial record QueryBinsCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAsync = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAutoIntervalBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsFixedIntervalBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsFixedBoundariesBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDateBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsClassificationBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsStackBy = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSplitBy = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsFirstDayOfWeek = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSnapToData = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturnFullIntervalBin = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturnStackValueRange = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsNormalization = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedStatisticTypes = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedNormalizationTypes = null);


/// <summary>
///     Advanced editing capabilities (calculate SQL formats, async apply-edits, upload-id flows) for a Feature Service layer.
/// </summary>
public partial record AdvancedEditingCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<string>? SupportedSqlFormatsInCalculate = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAsyncApplyEdits = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsReturnEditResults = null,
    [property: JsonPropertyName("supportsApplyEditsbyUploadID")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsApplyEditsByUploadId = null,
    [property: JsonPropertyName("supportedApplyEditsUploadIDFormats")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? SupportedApplyEditsUploadIdFormats = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsTranslation = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? SupportsMaxTranslations = null);


/// <summary>
///     Identifies the layer's unique-id field and whether the system maintains its values.
/// </summary>
public partial record UniqueIdField(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? IsSystemMaintained = null);


/// <summary>
///     SQL string-comparison collation settings reported by a Feature Service layer.
/// </summary>
public partial record Collation(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Locale = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? CaseSensitive = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? AccentSensitive = null);


/// <summary>
///     Time-zone reference applied to date fields in a Feature Service layer.
/// </summary>
public partial record TimeReference(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? TimeZone = null,
    [property: JsonPropertyName("timeZoneIANA")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? TimeZoneIana = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? RespectsDaylightSaving = null);


/// <summary>
///     Describes a database index defined on a Feature Service layer.
/// </summary>
public partial record LayerMetadataIndex(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Fields = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? IsAscending = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? IsUnique = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Description = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? IndexType = null);


/// <summary>
///     Drawing/rendering configuration block for a Feature Service layer. Polymorphic renderer dispatch is handled by RendererConverter.
/// </summary>
public partial record DrawingInfo(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Renderer? Renderer = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Transparency = null);


/// <summary>
///     Schema description for a single field on a Feature Service layer. Type is the raw "esriFieldType*" string.
/// </summary>
public partial record LayerMetadataField(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Type = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? ActualType = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Alias = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? SqlType = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? Length = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? Nullable = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? Editable = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Domain? Domain = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    object? DefaultValue = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? Precision = null);


/// <summary>
///     Prototype attribute bag for a feature template returned by a Feature Service layer.
/// </summary>
public partial record FeatureTemplatePrototype(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyDictionary<string, object?>? Attributes = null);


/// <summary>
///     REST-shape feature template (name, description, drawing tool, prototype) returned by a Feature Service layer.
/// </summary>
public partial record LayerMetadataTemplate(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Description = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? DrawingTool = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    FeatureTemplatePrototype? Prototype = null);
