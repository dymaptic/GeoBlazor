// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Options.PopupFetchFeaturesOptions.html">GeoBlazor Docs</a>
///     Optional properties to use with the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html#fetchFeatures">fetchFeatures</a> method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html#FetchFeaturesOptions">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Event">
///     The `click` event for either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html#FetchFeaturesOptions">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record PopupFetchFeaturesOptions(
    string? Event = null)
{
    /// <summary>
    ///     The `click` event for either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html#FetchFeaturesOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? Event { get; set; } = Event;
    
}
