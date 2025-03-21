namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///   For reading GroupLayer layers from GeoBlazor Pro.
/// </summary>
public interface IGroupLayer
{
    /// <summary>
    ///     A collection of operational <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">layers</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-LayersMixin.html#layers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    IReadOnlyList<Layer>? Layers { get; set; }
}