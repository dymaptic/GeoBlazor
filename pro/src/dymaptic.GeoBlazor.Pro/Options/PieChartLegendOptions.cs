namespace dymaptic.GeoBlazor.Pro.Options;

/// <summary>
///     An object providing options for describing the renderer in the Legend.
/// </summary>
public class PieChartLegendOptions : MapComponent
{
    /// <summary>
    ///     Describes the data used by the renderer. This is displayed as the title of the renderer in the Legend and overrides the layer's title.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}