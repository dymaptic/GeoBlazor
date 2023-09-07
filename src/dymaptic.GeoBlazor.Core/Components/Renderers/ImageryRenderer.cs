using dymaptic.GeoBlazor.Core.Components.Layers;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     This interface is to bridge implementing the various imagery renderers. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#renderer">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public abstract class ImageryRenderer: MapComponent
{

    /// <summary>
    ///     The method to enable the Renderer to validate.
    /// </summary>
    //void ValidateRequiredChildren();
}