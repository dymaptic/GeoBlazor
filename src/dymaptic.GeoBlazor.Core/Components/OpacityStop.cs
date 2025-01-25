namespace dymaptic.GeoBlazor.Core.Components;

public partial class OpacityStop : MapComponent
{

    
    /// <summary>
    ///     A string value used to label the stop in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     The opacity value in points (between 0.0 and 1.0) used to render features with the given value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given opacity.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}