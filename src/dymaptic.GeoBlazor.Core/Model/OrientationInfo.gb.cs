// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.OrientationInfo.html">GeoBlazor Docs</a>
///     An object containing properties specific to the orientation of an image attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Id">
///     The identifier for the orientation info.
/// </param>
/// <param name="Rotation">
///     The rotation value for the attached image.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Mirrored">
///     Indicates whether the image displays mirrored.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="OrientationInfoId">
///     The identifier for the orientation info.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query-support-AttachmentInfo.html#OrientationInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record OrientationInfo(
    long Id,
    double Rotation,
    bool Mirrored,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? OrientationInfoId = null);
