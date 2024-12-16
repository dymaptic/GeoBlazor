namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     The options to use with <see cref="FeatureLayer.ApplyEdits"/>.
/// </summary>
public record FeatureEditOptions
{
    /// <summary>
    ///     The geodatabase version to apply the edits. This parameter applies only if the capabilities.data.isVersioned property of the layer is true. If the gdbVersion parameter is not specified, edits are made to the published map’s version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }

    /// <summary>
    ///     Indicates whether the edit results should return the time edits were applied. If true, the feature service will return the time edits were applied in the edit result's editMoment property. Only applicable with ArcGIS Server services only.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnEditMoment { get; set; }

    /// <summary>
    ///     If set to original-and-current-features, the EditedFeatureResult parameter will be included in the applyEdits response. It contains all edited features participating in composite relationships in a database as result of editing a feature. Note that even for deletions, the geometry and attributes of the deleted feature are returned. The original-and-current-features option is only valid when rollbackOnFailureEnabled is true. The default value is none, which will not include the EditedFeatureResult parameter in the response. This is only applicable with ArcGIS Server services only.
    /// </summary>
    /// <remarks>
    ///     Possible values: "none" | "original-and-current-features"
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReturnServiceEditsOption { get; set; }

    /// <summary>
    ///     Indicates whether the edits should be applied only if all submitted edits succeed. If false, the server will apply the edits that succeed even if some of the submitted edits fail. If true, the server will apply the edits only if all edits succeed. The layer's capabilities.editing.supportsRollbackOnFailure property must be true if using this parameter. If supportsRollbackOnFailure is false for a layer, then rollbackOnFailureEnabled will always be true, regardless of how the parameter is set.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RollbackOnFailureEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the edits can be applied using globalIds of features or attachments. This parameter applies only if the layer's capabilities.editing.supportsGlobalId property is true. When false, globalIds submitted with the features are ignored and the service assigns new globalIds to the new features. When true, the globalIds must be submitted with the new features. When updating existing features, if the globalIdUsed is false, the objectIds of the features to be updated must be provided. If the globalIdUsed is true, globalIds of features to be updated must be provided. When deleting existing features, set this property to false as deletes operation only accepts objectIds at the current version of the API.
    ///     When adding, updating or deleting attachments, globalIdUsed parameter must be set to true and the attachment globalId must be set. For new attachments, the user must provide globalIds. In order for an attachment to be updated or deleted, clients must include its globalId. Attachments are not supported in an edit payload when globalIdUsed is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? GlobalIdUsed { get; set; }
}