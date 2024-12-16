using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Object containing features and attachments to be added, updated or deleted.
///     For use with <see cref="FeatureLayer.ApplyEdits"/>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#applyEdits">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record FeatureEdits
{
    /// <summary>
    ///     An array or a collection of features to be added. Values of non nullable fields must be provided when adding new features. Date fields must have numeric values representing universal time.
    /// </summary>
    public IEnumerable<Graphic>? AddFeatures { get; set; }
    /// <summary>
    ///     An array or a collection of features to be updated. Each feature must have valid objectId. Values of non nullable fields must be provided when updating features. Date fields must have numeric values representing universal time.
    /// </summary>
    public IEnumerable<Graphic>? UpdateFeatures { get; set; }
    /// <summary>
    ///     An array or a collection of features, or an array of objects with objectId or globalId of each feature to be deleted. When an array or collection of features is passed, each feature must have a valid objectId. When an array of objects is used, each object must have a valid value set for objectId or globalId property.
    /// </summary>
    public IEnumerable<Graphic>? DeleteFeatures { get; set; }
    /// <summary>
    ///     An array of attachments to be added. Applies only when the options.globalIdUsed parameter is set to true. User must provide globalIds for all attachments to be added.
    /// </summary>
    public IEnumerable<AttachmentEdit>? AddAttachments { get; set; }
    /// <summary>
    ///     An array of attachments to be updated. Applies only when the options.globalIdUsed parameter is set to true. User must provide globalIds for all attachments to be updated.
    /// </summary>
    public IEnumerable<AttachmentEdit>? UpdateAttachments { get; set; }
    /// <summary>
    ///     An array of globalIds for attachments to be deleted. Applies only when the options.globalIdUsed parameter is set to true.
    /// </summary>
    public IEnumerable<string>? DeleteAttachments { get; set; }
}