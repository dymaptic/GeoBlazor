namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The attachment to be added, updated or deleted in an <see cref="AttachmentEdit"/>.
/// </summary>
public record Attachment
{
    /// <summary>
    ///     The globalId of the attachment to be added or updated. These Global IDs must be from the Global ID field created by ArcGIS. For more information on ArcGIS generated Global IDs, see the Global IDs and Attachments and relationship classes sections in the <a target="_blank" href="https://enterprise.arcgis.com/en/server/latest/publish-services/windows/prepare-data-for-offline-use.htm#ESRI_SECTION1_CDC34577197B43A980E4B5021DB1C32A">Data Preparation</a> documentation.
    /// </summary>
    public string GlobalId { get; set; } = default!;

    /// <summary>
    ///     The name of the attachment. This parameter must be set if the attachment type is Blob.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The content type of the attachment. For example, 'image/jpeg'. See the ArcGIS REST API documentation for more information on supported attachment types.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    ///     The id of pre-loaded attachment.
    /// </summary>
    public string? UploadId { get; set; }

    /// <summary>
    ///     The attachment data.
    /// </summary>
    public string? Data { get; set; }
}