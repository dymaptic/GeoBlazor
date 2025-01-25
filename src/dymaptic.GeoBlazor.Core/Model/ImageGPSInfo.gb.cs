// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Image GPS information for images returned as a result of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryGPSInfo">ImageryLayer.queryGPSInfo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-imageService.html#queryGPSInfo">imageService.queryGPSInfo()</a> methods.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AcquisitionDate">
///     Image acquisition date represented using Linux Epoch time.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#acquisitionDate">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="CameraID">
///     Image's camera id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#cameraID">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Center">
///     Image's center.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#center">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Gps">
///     Image's GPS location.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#gps">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ImageGPSInfoId">
///     Image id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#id">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Name">
///     Image name.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#name">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Orientation">
///     Image's orientation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfo.html#orientation">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImageGPSInfo(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    DateTime? AcquisitionDate = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? CameraID = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Point? Center = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Gps = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? ImageGPSInfoId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Orientation = null);

