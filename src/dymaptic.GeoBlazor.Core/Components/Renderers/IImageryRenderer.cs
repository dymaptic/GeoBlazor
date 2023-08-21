using dymaptic.GeoBlazor.Core.Components.Layers;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     This interface is to bridge . 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public interface IImageryRenderer
{

    /// <summary>
    ///     The method to enable the Renderer to validate.
    /// </summary>
    void ValidateRequiredChildren();
}