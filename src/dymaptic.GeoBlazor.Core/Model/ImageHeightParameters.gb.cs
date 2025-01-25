// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Input parameters used by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureHeight">ImageryLayer.measureHeight()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-imageService.html#measureHeight">imageService.measureHeight()</a> methods to perform imagery height mensuration.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MosaicRule">
///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MosaicRule.html">mosaic rule</a> on how individual images should be mosaicked when the measure is computed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-BaseImageMeasureParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PixelSize">
///     Specifies the pixel size.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-BaseImageMeasureParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="FromGeometry">
///     A point that defines the from location of the height measurement.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#fromGeometry">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="LinearUnit">
///     Linear unit used for height calculation.
///     default "meters"
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="OperationType">
///     Determines how the height will be measured when the sensor info is available.
///     default "base-and-top"
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#operationType">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ToGeometry">
///     A point that defines the to location of the height measurement.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#toGeometry">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImageHeightParameters(
    MosaicRule MosaicRule,
    PixelSize PixelSize,
    Point? FromGeometry = null,
    LengthUnit? LinearUnit = null,
    OperationType? OperationType = null,
    Point? ToGeometry = null) : BaseImageMeasureParameters(
    MosaicRule,
    PixelSize)
{
    /// <summary>
    ///     A point that defines the from location of the height measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#fromGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Point? FromGeometry { get; set; } = FromGeometry;
    
    /// <summary>
    ///     Linear unit used for height calculation.
    ///     default "meters"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public LengthUnit? LinearUnit { get; set; } = LinearUnit;
    
    /// <summary>
    ///     Determines how the height will be measured when the sensor info is available.
    ///     default "base-and-top"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#operationType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public OperationType? OperationType { get; set; } = OperationType;
    
    /// <summary>
    ///     A point that defines the to location of the height measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#toGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Point? ToGeometry { get; set; } = ToGeometry;
    
}

