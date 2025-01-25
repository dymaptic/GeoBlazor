// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Only for renderers of type `univariate-color-size` with an `above-and-below` <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfo.html#univariateTheme">univariateTheme</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfo.html#statistics">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Max">
///     The maximum data value of the attribute represented by the renderer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfo.html#statistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Min">
///     The minimum data value of the attribute represented by the renderer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfo.html#statistics">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record AuthoringInfoStatistics(
    double Max,
    double Min);

