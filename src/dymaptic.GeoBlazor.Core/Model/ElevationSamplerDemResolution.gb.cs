// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    The minimum and maximum resolution of the data in the sampler.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-ElevationSampler.html#demResolution">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Max">
///     The maximum resolution.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-ElevationSampler.html#demResolution">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Min">
///     The minimum resolution.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-ElevationSampler.html#demResolution">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ElevationSamplerDemResolution(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Max = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Min = null);

