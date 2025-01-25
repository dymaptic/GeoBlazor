// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#getSamples">getSamples</a> method on <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html">ImageryLayer</a> returns <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleResult.html">ImageSampleResult</a> containing array of this class.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Attributes">
///     Name-value pairs of fields and field values associated with the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#location">sample location</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#attributes">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Location">
///     The sample location.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#location">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="LocationId">
///     The location id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#locationId">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PixelValue">
///     The pixel value associated with the sampled location.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#pixelValue">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="RasterId">
///     The raster id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Resolution">
///     The resolution representing the average of source raster's resolutions in x and y axes.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSample.html#resolution">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImageSample(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Attributes = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Point? Location = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? LocationId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<double>? PixelValue = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? RasterId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Resolution = null);

