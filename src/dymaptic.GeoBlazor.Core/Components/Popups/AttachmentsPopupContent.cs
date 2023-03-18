using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     An AttachmentsContent popup element represents an attachment element associated with a feature. This resource is
///     available only if the FeatureLayer.capabilities.data.supportsAttachment is true.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class AttachmentsPopupContent : PopupContent
{
    /// <inheritdoc />
    public override string Type => "attachments";

    /// <summary>
    ///     Describes the attachment's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     A string value indicating how to display an attachment.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayType { get; set; }

    /// <summary>
    ///     A heading indicating what the attachment's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new AttachmentsPopupContentSerializationRecord(Description, DisplayType, Title);
    }
}

internal record AttachmentsPopupContentSerializationRecord(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]string? Description, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]string? DisplayType, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]string? Title) 
    : PopupContentSerializationRecord("attachments");