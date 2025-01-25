namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public partial class UniqueValueRendererLegendOptions : MapComponent
{
    /// <summary>
    ///     The title to display in the legend for the renderer
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}