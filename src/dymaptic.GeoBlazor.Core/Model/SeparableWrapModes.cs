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
[CodeGenerationIgnore]
public record SeparableWrapModes(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    WrapMode? Horizontal = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    WrapMode? Vertical = null)
{
    /// <summary>
    ///     A separable wrap configuration for horizontal and vertical wrapping modes.
    /// </summary>
    /// <param name="mode">
    ///     A wrapping mode to be used for both horizontal and vertical directions.
    /// </param>
    public SeparableWrapModes(WrapMode? mode):this(mode, mode)
    {
    }
}
