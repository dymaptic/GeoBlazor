namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     An array of <a href="https://en.wikipedia.org/wiki/Exif" target="_blank">Exchangeable image file format</a> information for the attachment. You must set the attachment query's returnMetadata to true to get the exif info associated with the attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#ExifInfo">ArcGIS JS API</a>
/// </summary>
/// <param name = "Name">
///     The file name.
/// </param>
/// <param name = "Tags">
///     Array of <see cref = "ExifInfoTag"/> objects.
/// </param>
public record ExifInfo(string Name, ExifInfoTag[] Tags);