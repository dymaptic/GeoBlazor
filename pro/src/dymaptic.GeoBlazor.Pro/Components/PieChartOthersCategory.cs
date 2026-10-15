namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Defines the rules for how to aggregate small categories to a generic "others" category.
/// </summary>
public class PieChartOthersCategory : MapComponent
{
    /// <summary>
    ///     Defines the color used to represent all categories whose pie slices are smaller than the percentage defined by threshold. This is typically used to represent a generic "others" category where slices would otherwise be too small to read.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }
    
    /// <summary>
    ///     Describes the color grouping categories smaller than the threshold in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Represents the minimum size of individual slices as a percentage of the entire pie. Accepted values are between 0 and 1. All slices that make up a smaller percentage than the threshold will automatically be aggregated to an "others" category represented by the color specified in color. For example, if the threshold is 0.05, then all slices that make up less than 5% of the total pie will be represented with the color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Threshold { get; set; }
}