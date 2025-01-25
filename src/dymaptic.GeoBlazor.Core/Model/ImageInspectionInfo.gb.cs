// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Image information for images returned as a result of running <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#findImages">ImageryLayer.findImages()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-imageService.html#findImages">imageService.findImages()</a> methods.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AcquisitionDate">
///     Image acquisition date represented in Linux Epoch time.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#acquisitionDate">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="CameraID">
///     Image's camera id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#cameraID">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Center">
///     Image's center.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#center">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Cols">
///     Camera's columns.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#cols">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="FocalLength">
///     Camera's focal length.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#focalLength">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ImageInspectionInfoId">
///     Image id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#id">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Make">
///     Camera's manufacturer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#make">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Model">
///     Camera's model.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#model">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Orientation">
///     Image's orientation along x, y, z axis.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#orientation">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PerspectiveCenter">
///     Perspective center.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#perspectiveCenter">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PixelSize">
///     Camera's pixel size.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ReferenceUri">
///     The relative reference to the image's uri.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#referenceUri">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Rows">
///     Camera's rows.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageInspectionInfo.html#rows">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImageInspectionInfo(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    DateTime? AcquisitionDate = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? CameraID = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Point? Center = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Cols = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? FocalLength = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? ImageInspectionInfoId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Make = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Model = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    ImageInspectionInfoOrientation? Orientation = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Point? PerspectiveCenter = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? PixelSize = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? ReferenceUri = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Rows = null);

