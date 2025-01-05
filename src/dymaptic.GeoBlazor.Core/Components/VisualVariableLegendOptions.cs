namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     An object providing options for displaying the visual variable in the Legend.
/// </summary>
public class VisualVariableLegendOptions : MapComponent
{
    /// <summary>
    ///     Indicates whether to show the visual variable in the legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowLegend { get; set; }

    /// <summary>
    ///     The title describing the visualization of the visual variable in the Legend. This takes precedence over a field
    ///     alias or valueExpressionTitle.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}