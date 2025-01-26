namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     An object containing properties specific to the orientation of an image attachment. This information is stored within the attachment's exifInfo. In order to read this, you must first set the attachment query's returnMetadata to true to get the exif info associated with the attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS JS API</a>
/// </summary>
/// <param name = "Id">
///     The identifier for the orientation info.
/// </param>
/// <param name = "Rotation">
///     The rotation value for the attached image.
/// </param>
/// <param name = "Mirrored">
///     Indicates whether the image displays mirrored.
/// </param>
public record OrientationInfo(long Id, int Rotation, bool Mirrored);