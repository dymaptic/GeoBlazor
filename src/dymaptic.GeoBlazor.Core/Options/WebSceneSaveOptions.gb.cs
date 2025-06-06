// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Options.WebSceneSaveOptions.html">GeoBlazor Docs</a>
///     
/// </summary>
/// <param name="IgnoreUnsupported">
///     When `true`, the scene will save even if it contains unsupported content (layers, renderers, symbols).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#save">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record WebSceneSaveOptions(
    bool? IgnoreUnsupported = null)
{
    /// <summary>
    ///     When `true`, the scene will save even if it contains unsupported content (layers, renderers, symbols).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public bool? IgnoreUnsupported { get; set; } = IgnoreUnsupported;
    
}
