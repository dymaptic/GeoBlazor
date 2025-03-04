namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class CSVLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer
{


    /// <inheritdoc />
    public override LayerType Type => LayerType.CSV;


    /// <summary>
    ///     A copyright string to identify ownership of the data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
    ///     seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     The column delimiter. Default is comma (,).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CSVDelimiter? Delimiter { get; set; }
    
    /// <summary>
    ///     The name of the layer's primary display field. The value of this property matches the name of one of the fields of the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayField { get; set; }
    
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [Parameter]  
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IFeatureReduction? FeatureReduction { get; set; }  
}