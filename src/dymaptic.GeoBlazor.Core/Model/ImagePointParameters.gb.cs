// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Input parameters used by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measurePointOrCentroid">ImageryLayer.measurePointOrCentroid()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-imageService.html#measurePointOrCentroid">imageService.measurePointOrCentroid()</a> methods to perform imagery point or centroid mensuration.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MosaicRule">
///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MosaicRule.html">mosaic rule</a> on how individual images should be mosaicked when the measure is computed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-BaseImageMeasureParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PixelSize">
///     Specifies the pixel size.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-BaseImageMeasureParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Geometry">
///     Input geometry to determine a a point location or a centroid of a given area.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Is3D">
///     When `true`, this method calculates the z-value for the returned point geometry.
///     default false
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#is3D">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImagePointParameters(
    MosaicRule MosaicRule,
    PixelSize PixelSize,
    Geometry? Geometry = null,
    bool? Is3D = null) : BaseImageMeasureParameters(
    MosaicRule,
    PixelSize)
{
    /// <summary>
    ///     Input geometry to determine a a point location or a centroid of a given area.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Geometry? Geometry { get; set; } = Geometry;
    
    /// <summary>
    ///     When `true`, this method calculates the z-value for the returned point geometry.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#is3D">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public bool? Is3D { get; set; } = Is3D;
    
}

