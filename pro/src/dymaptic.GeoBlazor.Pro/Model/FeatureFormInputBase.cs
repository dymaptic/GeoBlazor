namespace dymaptic.GeoBlazor.Pro.Model;

[JsonConverter(typeof(FeatureFormInputBaseConverter))]
public abstract partial record FeatureFormInputBase
{
    // Add custom code to this file to override generated code
    /// <summary>
    ///   Identifies the type of input.
    /// </summary>
    public abstract FeatureFormInputType Type { get; }
}