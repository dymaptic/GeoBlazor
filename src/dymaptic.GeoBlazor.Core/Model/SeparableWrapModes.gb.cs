// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.SeparableWrapModes.html">GeoBlazor Docs</a>
///     A separable wrap configuration for horizontal and vertical wrapping modes.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#SeparableWrapModes">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Horizontal">
///     Horizontal wrapping mode.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#SeparableWrapModes">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Vertical">
///     Vertical wrapping mode.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#SeparableWrapModes">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record SeparableWrapModes(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Horizontal? Horizontal = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Vertical? Vertical = null);
