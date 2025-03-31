namespace dymaptic.GeoBlazor.Core.Model;

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