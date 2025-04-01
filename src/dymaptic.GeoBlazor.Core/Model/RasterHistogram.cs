namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.RasterHistogram.html">GeoBlazor Docs</a>
///     Raster histogram information returned that meets the specified <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html">ImageHistogramParameters</a> from the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeHistograms">computeHistograms()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeStatisticsHistograms">computeStatisticsHistograms()</a> method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Counts">
///     Count of pixels that fall into each bin using numbers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ByteCounts">
///     Count of pixels that fall into each bin using a byte array.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Max">
///     The maximum pixel value of the histogram.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Min">
///     The minimum pixel value of the histogram.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Size">
///     Number of bins.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">ArcGIS Maps SDK for JavaScript</a>
/// </param>
[CodeGenerationIgnore]
public record RasterHistogram(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<double>? Counts = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    byte[]? ByteCounts = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Max = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Min = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? Size = null);