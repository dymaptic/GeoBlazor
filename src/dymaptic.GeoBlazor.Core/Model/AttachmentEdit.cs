namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     AttachmentEdit represents an attachment that can be added, updated or deleted via applyEdits. This object can be either pre-uploaded data or base 64 encoded data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#AttachmentEdit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public record AttachmentEdit
{
    /// <summary>
    ///     Construct an AttachmentEdit from a <see cref="Graphic"/> "Feature" and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(Graphic feature, Attachment attachment)
    {
        Feature = feature;
        Attachment = attachment;
    }

    /// <summary>
    ///     Construct an AttachmentEdit from a Feature's `objectId` and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(int objectId, Attachment attachment)
    {
        ObjectId = objectId;
        Attachment = attachment;
    }

    /// <summary>
    ///     Construct an AttachmentEdit from a Feature's `globalId` and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(string globalId, Attachment attachment)
    {
        GlobalId = globalId;
        Attachment = attachment;
    }
    
    /// <summary>
    ///     The feature of feature associated with the attachment.
    /// </summary>
    [JsonConverter(typeof(GraphicToIdConverter))]
    public Graphic? Feature { get; set; }
    
    /// <summary>
    ///     The `objectId` of the feature associated with the attachment.
    /// </summary>
    public int? ObjectId { get; set; }
    
    /// <summary>
    ///     The `globalId` of the feature associated with the attachment.
    /// </summary>
    public string? GlobalId { get; set; }

    /// <summary>
    ///     The attachment to be added, updated or deleted.
    /// </summary>
    public Attachment Attachment { get; set; } = default!;
}