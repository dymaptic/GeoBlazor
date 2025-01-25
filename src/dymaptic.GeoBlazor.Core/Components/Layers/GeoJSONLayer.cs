namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class GeoJSONLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer
{


    /// <inheritdoc />
    public override LayerType Type => LayerType.GeoJSON;


    /// <summary>
    ///     A copyright string to identify ownership of the data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [Parameter]  
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  
    [CodeGenerationIgnore]
    public IFeatureReduction? FeatureReduction { get; set; }

}