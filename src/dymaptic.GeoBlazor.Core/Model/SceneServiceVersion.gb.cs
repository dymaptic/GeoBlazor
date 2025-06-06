// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.SceneServiceVersion.html">GeoBlazor Docs</a>
///     The version of the scene service specification used for this service.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-SceneService.html#version">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Major">
///     The major version of the scene layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-SceneService.html#version">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Minor">
///     The minor version of the scene layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-SceneService.html#version">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="VersionString">
///     The complete version string of the scene layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-SceneService.html#version">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record SceneServiceVersion(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Major = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    double? Minor = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? VersionString = null);
