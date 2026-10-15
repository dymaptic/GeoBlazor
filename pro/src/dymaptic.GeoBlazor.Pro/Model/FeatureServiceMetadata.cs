namespace dymaptic.GeoBlazor.Pro.Model;


/// <summary>
///     Models the JSON response from an ArcGIS Feature Service root endpoint (<c>.../FeatureServer</c>).
/// </summary>
public partial record FeatureServiceMetadata
{
    /// <summary>
    ///     The current service version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CurrentVersion { get; init; }

    /// <summary>
    ///     The portal item ID for the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceItemId { get; init; }

    /// <summary>
    ///     The service description.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceDescription { get; init; }

    /// <summary>
    ///     Whether the service uses versioned data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasVersionedData { get; init; }

    /// <summary>
    ///     Whether the service exposes static data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasStaticData { get; init; }

    /// <summary>
    ///     The maximum record count.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxRecordCount { get; init; }

    /// <summary>
    ///     The supported query formats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SupportedQueryFormats { get; init; }

    /// <summary>
    ///     The service capabilities string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Capabilities { get; init; }

    /// <summary>
    ///     The service description text.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }

    /// <summary>
    ///     The copyright text.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CopyrightText { get; init; }

    /// <summary>
    ///     The spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; init; }

    /// <summary>
    ///     The initial extent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? InitialExtent { get; init; }

    /// <summary>
    ///     The full extent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; init; }

    /// <summary>
    ///     Whether geometry updates are allowed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllowGeometryUpdates { get; init; }

    /// <summary>
    ///     The units used by the service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Units { get; init; }

    /// <summary>
    ///     Whether sync is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SyncEnabled { get; init; }

    /// <summary>
    ///     The layer metadata entries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<ServiceLayerInfo>? Layers { get; init; }

    /// <summary>
    ///     The table metadata entries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<ServiceLayerInfo>? Tables { get; init; }

    /// <summary>
    ///     Whether append is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAppend { get; init; }

    /// <summary>
    ///     Whether applyEdits with global IDs is supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsApplyEditsWithGlobalIds { get; init; }

    /// <summary>
    ///     Whether shared templates are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsSharedTemplates { get; init; }

    /// <summary>
    ///     Whether true curves are supported.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsTrueCurve { get; init; }

    /// <summary>
    ///     The sync capability details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SyncCapabilities? SyncCapabilities { get; init; }

    /// <summary>
    ///     The editor tracking details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EditorTrackingInfo? EditorTrackingInfo { get; init; }

    /// <summary>
    ///     The XSS prevention details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public XssPreventionInfo? XssPreventionInfo { get; init; }

    /// <summary>
    ///     Whether XSS prevention is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? XssPreventionEnabled { get; init; }
}


/// <summary>
///     Per-layer entry in a Feature Service root response (used for both Layers and Tables arrays).
/// </summary>
public partial record ServiceLayerInfo(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? Id = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? ParentLayerId = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? DefaultVisibility = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<int>? SubLayerIds = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? MinScale = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? MaxScale = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Type = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    GeometryType? GeometryType = null);


/// <summary>
///     Sync capabilities advertised by a Feature Service.
/// </summary>
public partial record SyncCapabilities(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAsync = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsRegisteringExistingData = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSyncDirectionControl = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPerLayerSync = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPerReplicaSync = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsRollbackOnFailure = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? SupportedSyncDataOptions = null);


/// <summary>
///     Editor-tracking configuration reported by a Feature Service.
/// </summary>
public partial record EditorTrackingInfo(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? EnableEditorTracking = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? EnableOwnershipAccessControl = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? AllowOthersToUpdate = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? AllowOthersToDelete = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? AllowOthersToQuery = null);


/// <summary>
///     XSS-prevention configuration reported by a Feature Service.
/// </summary>
public partial record XssPreventionInfo(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? XssPreventionEnabled = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? XssPreventionRule = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? XssInputRule = null);
