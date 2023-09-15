using dymaptic.GeoBlazor.Core.Components.Layers;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     This interface is to bridge implementing the various imagery renderers. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#renderer">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// 
/// <summary>
///     The ImageryRenderer is an abstract class to aide understanding that a number of different "renderers"
///     inherit from the MapComponent class vs the Renderer class.
/// </summary>
public abstract class ImageryRenderer: MapComponent
{

}