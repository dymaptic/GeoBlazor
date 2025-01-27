// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///    Raster statistics information returned that meets the specified <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html">ImageHistogramParameters</a> from the `computeStatisticsHistograms()` method on <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeStatisticsHistograms">ImageryLayer</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#computeStatisticsHistograms">ImageryTileLayer</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Avg">
///     Average of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Count">
///     Count of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Max">
///     Maximum value of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Median">
///     Median value of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Min">
///     Minimum value of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Mode">
///     Mode value of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Stddev">
///     Standard deviation of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Sum">
///     Sum of the statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record RasterBandStatistics(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Avg = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? Count = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Max = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Median = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Min = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Mode = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Stddev = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Sum = null);

