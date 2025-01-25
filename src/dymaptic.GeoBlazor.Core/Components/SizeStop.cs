namespace dymaptic.GeoBlazor.Core.Components;

public partial class SizeStop : MapComponent
{


    /// <summary>
    ///     A string value used to label the stop in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     The size value in points (between 0 and 90) used to render features with the given value. This value may also be autocast from a string in points or pixels.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given size.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}