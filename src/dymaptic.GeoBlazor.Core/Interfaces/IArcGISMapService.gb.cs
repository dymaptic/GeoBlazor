// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///    Interface for types MapImageLayer, TileLayer
/// </summary>
public partial interface IArcGISMapService 
{
#region Properties

    /// <summary>
    ///     The copyright text as defined by the service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#copyright">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    string? Copyright { get; set; }
    
    /// <summary>
    ///     The full extent of the layer as defined by the map service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    Extent? FullExtent { get; set; }
    
    /// <summary>
    ///     Indicates whether the layer will be included in the legend.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#legendEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    bool? LegendEnabled { get; set; }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Copyright property after render.
    /// </summary>
    Task SetCopyright(string value);
    
    /// <summary>
    ///    Asynchronously set the value of the FullExtent property after render.
    /// </summary>
    Task SetFullExtent(Extent value);
    
    /// <summary>
    ///    Asynchronously set the value of the LegendEnabled property after render.
    /// </summary>
    Task SetLegendEnabled(bool value);
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Capabilities property.
    /// </summary>
    Task<ArcGISMapServiceCapabilities?> GetCapabilities();

    /// <summary>
    ///     Asynchronously retrieve the current value of the Copyright property.
    /// </summary>
    Task<string?> GetCopyright();

    /// <summary>
    ///     Asynchronously retrieve the current value of the FullExtent property.
    /// </summary>
    Task<Extent?> GetFullExtent();

    /// <summary>
    ///     Asynchronously retrieve the current value of the LegendEnabled property.
    /// </summary>
    Task<bool?> GetLegendEnabled();

    /// <summary>
    ///     Asynchronously retrieve the current value of the SpatialReference property.
    /// </summary>
    Task<SpatialReference?> GetSpatialReference();

    /// <summary>
    ///     Asynchronously retrieve the current value of the Version property.
    /// </summary>
    Task<double?> GetVersion();

#endregion

}
