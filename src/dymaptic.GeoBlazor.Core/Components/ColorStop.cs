namespace dymaptic.GeoBlazor.Core.Components;

public partial class ColorStop: MapComponent
{

    
    /// <summary>
    ///     A string value used to label the stop along the color ramp in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }
}