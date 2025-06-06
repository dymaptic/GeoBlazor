// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IBlendLayer.html">GeoBlazor Docs</a>
///     Interface for types BaseTileLayer, BingMapsLayer, CatalogDynamicGroupLayer, CatalogFootprintLayer, CatalogLayer, CSVLayer, FeatureLayer, GeoJSONLayer, GeoRSSLayer, GraphicsLayer, GroupLayer, ImageryLayer, ImageryTileLayer, KMLLayer, MapImageLayer, OpenStreetMapLayer, TileLayer, VectorTileLayer, WCSLayer, WebTileLayer, WFSLayer, WMSLayer, WMTSLayer
/// </summary>
public partial interface IBlendLayer : IMapComponent
{
#region Properties

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IBlendLayer.html#iblendlayerblendmode-property">GeoBlazor Docs</a>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#blendMode">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IBlendLayer.html#iblendlayereffect-property">GeoBlazor Docs</a>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#effect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    Effect? Effect { get; set; }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the BlendMode property after render.
    /// </summary>
    Task SetBlendMode(BlendMode? value);
    
    /// <summary>
    ///    Asynchronously set the value of the Effect property after render.
    /// </summary>
    Task SetEffect(Effect? value);
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the BlendMode property.
    /// </summary>
    Task<BlendMode?> GetBlendMode();

    /// <summary>
    ///     Asynchronously retrieve the current value of the Effect property.
    /// </summary>
    Task<Effect?> GetEffect();

#endregion

}
