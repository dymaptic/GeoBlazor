// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///    Interface for types CSVLayer, FeatureLayer, GeoJSONLayer, WFSLayer
/// </summary>
public partial interface IFeatureEffectLayer 
{
#region Properties

    /// <summary>
    ///     The featureEffect can be used to draw attention features of interest.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureEffectLayer.html#featureEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    FeatureEffect? FeatureEffect { get; set; }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the FeatureEffect property after render.
    /// </summary>
    Task SetFeatureEffect(FeatureEffect value);
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the FeatureEffect property.
    /// </summary>
    Task<FeatureEffect?> GetFeatureEffect();

#endregion

}
