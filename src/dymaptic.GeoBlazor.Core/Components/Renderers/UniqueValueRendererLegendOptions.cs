namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     An object providing options for displaying the renderer in the Legend.
/// </summary>
public class UniqueValueRendererLegendOptions : MapComponent
{
    /// <summary>
    ///     The title to display in the legend for the renderer
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}