// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.CoverageDescriptionV100RangeSetAxis.html">GeoBlazor Docs</a>
///     Provides additional information on compound valued range set.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV100">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Label">
///     Range axis label.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV100">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Name">
///     Range axis name.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV100">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Values">
///     Range axis values.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV100">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record CoverageDescriptionV100RangeSetAxis(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Label = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<string>? Values = null);
