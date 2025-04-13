namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(ColorRampConverter))]
public abstract partial class ColorRamp : MapComponent
{
    /// <summary>
    ///     A string value representing the color ramp type. Possible Values:"algorithmic"|"multipart"
    /// </summary>
    public abstract ColorRampType Type { get; }
}