using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     An AttachmentsContent popup element represents an attachment element associated with a feature. This resource is
///     available only if the FeatureLayer.capabilities.data.supportsAttachment is true.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class AttachmentsPopupContent : PopupContent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public AttachmentsPopupContent()
    {
    }
    
    /// <summary>
    ///     Constructor for creating a AttachmentsPopupContent in code.
    /// </summary>
    /// <param name="title">
    ///     A heading indicating what the attachment's content represents.
    /// </param>
    /// <param name="description">
    ///     Describes the attachment's content in detail.
    /// </param>
    /// <param name="displayType">
    ///     A string value indicating how to display an attachment.
    /// </param>
    public AttachmentsPopupContent(string? title = null, string? description = null, string? displayType = null)
    {
#pragma warning disable BL0005
        Title = title;
        Description = description;
        DisplayType = displayType;
#pragma warning restore BL0005
    }
    
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
        return new PopupContentSerializationRecord(Type)
        {
            Description = Description, DisplayType = DisplayType, Title = Title
        };
    }
}