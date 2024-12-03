namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Defines a layer that supports Feature Reduction clusters and binning in GeoBlazor Pro
/// </summary>
public interface IFeatureReductionLayer
{
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary> 
    public IFeatureReduction? FeatureReduction { get; set; }

    /// <summary>  
    ///    Asynchronously set the value of the FeatureReduction property after render.  
    /// </summary>  
    /// <param name="value">  
    ///     The value to set.  
    /// </param>  
    public Task SetFeatureReduction(IFeatureReduction value);

    /// <summary>  
    ///     Asynchronously retrieve the current value of the FeatureReduction property.  
    /// </summary>  
    public Task<IFeatureReduction?> GetFeatureReduction();
}