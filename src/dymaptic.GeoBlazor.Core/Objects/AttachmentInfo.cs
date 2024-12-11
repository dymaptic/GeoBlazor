namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The AttachmentInfo class returns information about attachments associated with a feature. The contents of the attachment are streamed to the client. Attachments are available if the FeatureLayer.capabilities.data.supportsAttachment is true.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html">ArcGIS JS API</a>
/// </summary>
/// <param name="ContentType">
///     The content type of the attachment. For example, 'image/jpeg'. See the <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/query-attachments-feature-service-layer-.htm">ArcGIS REST API documentation</a> for more information on supported attachment types.
/// </param>
/// <param name="ExifInfo">
///     An array of <see cref="ExifInfo"/> for the attachment.
/// </param>
/// <param name="GlobalId">
///     The global identifier for the attachment.
/// </param>
/// <param name="Id">
///     The identifier for the attachment.
/// </param>
/// <param name="Keywords">
///     Keywords used for the attachment.
/// </param>
/// <param name="Name">
///     String value indicating the name of the file attachment.
/// </param>
/// <param name="OrientationInfo">
///     The OrientationInfo for the attachment. This is derived from the exifInfo. In order to read this, you must first set the attachment query's returnMetadata to true to get the exif info associated with the attachment.
/// </param>
/// <param name="ParentGlobalId">
///     The parent or the feature global id of the attachment.
/// </param>
/// <param name="ParentObjectId">
///     The parent or the feature object id of the attachment.
/// </param>
/// <param name="Size">
///     The file size of the attachment. This is specified in bytes.
/// </param>
/// <param name="Url">
///     The URL of the attachment.
/// </param>
public record AttachmentInfo(string ContentType, ExifInfo[]? ExifInfo, string GlobalId, long Id, string Keywords,
    string Name, OrientationInfo OrientationInfo, long ParentGlobalId, long ParentObjectId, long Size, string Url);
    
/// <summary>
///     An array of <a href="https://en.wikipedia.org/wiki/Exif" target="_blank">Exchangeable image file format</a> information for the attachment. You must set the attachment query's returnMetadata to true to get the exif info associated with the attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#ExifInfo">ArcGIS JS API</a>
/// </summary>
/// <param name="Name">
///     The file name.
/// </param>
/// <param name="Tags">
///     Array of <see cref="ExifInfoTag"/> objects.
/// </param>
public record ExifInfo(string Name, ExifInfoTag[] Tags);

/// <summary>
///     The tag for an ExifInfo object.
/// </summary>
/// <param name="Name">
///     The tag name.
/// </param>
/// <param name="Description">
///     The tag description.
/// </param>
/// <param name="Value">
///     The value of the tag.
/// </param>
public record ExifInfoTag(string Name, string Description, object Value);

/// <summary>
///     An object containing properties specific to the orientation of an image attachment. This information is stored within the attachment's exifInfo. In order to read this, you must first set the attachment query's returnMetadata to true to get the exif info associated with the attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS JS API</a>
/// </summary>
/// <param name="Id">
///     The identifier for the orientation info.
/// </param>
/// <param name="Rotation">
///     The rotation value for the attached image.
/// </param>
/// <param name="Mirrored">
///     Indicates whether the image displays mirrored.
/// </param>
public record OrientationInfo(long Id, int Rotation, bool Mirrored);