namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public record Effect
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="value">
    ///     The effect to be applied to a layer or layerView at the corresponding scale. Use only when setting a scale dependent effect.
    /// </param>
    /// <param name="scale">
    ///     The scale of the view for the effect to take place. Use only when setting a scale dependent effect.
    /// </param>
    public Effect(string value, double? scale = null)
    {
        Value = value;
        Scale = scale;
    }

    /// <summary>
    ///     Constructor
    /// </summary>
    public Effect()
    {
        
    }
    
    /// <summary>
    ///     Implicit conversion from string to Effect
    /// </summary>
    public static implicit operator Effect(string stringVal)
    {
        return new Effect(stringVal);
    }
    
    /// <summary>
    ///     The scale of the view for the effect to take place. Use only when setting a scale dependent effect.
    /// </summary>
    public double? Scale { get; set; }
    /// <summary>
    ///     The effect to be applied to a layer or layerView at the corresponding scale. Use only when setting a scale dependent effect.
    /// </summary>
    public string? Value { get; set; }
}