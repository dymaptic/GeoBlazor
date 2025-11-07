namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class AttachmentsPopupContent : PopupContent
{

    
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Attachments;

    /// <summary>
    ///     Describes the attachment's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     A string value indicating how to display an attachment.
    ///     default "auto"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html#displayType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttachmentsPopupContentDisplayType? DisplayType { get; set; }

    /// <summary>
    ///     A heading indicating what the attachment's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }


    public override PopupContentSerializationRecord ToProtobuf()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            Description = Description,
            DisplayType = DisplayType?.ToString().ToKebabCase(),
            Title = Title
        };
    }
}