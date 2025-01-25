// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///    Object returned when <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html#queryElevation">queryElevation()</a> promise resolves:
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html#ElevationQueryResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Geometry">
///     The geometry with sampled z-values.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html#ElevationQueryResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="NoDataValue">
///     The value used when there is no data available.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html#ElevationQueryResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SampleInfo">
///     Contains additional information about how the geometry was sampled.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html#ElevationQueryResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ElevationLayerElevationQueryResult(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Geometry? Geometry = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? NoDataValue = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<ElevationLayerElevationQueryResultSampleInfo>? SampleInfo = null);

