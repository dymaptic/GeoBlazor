namespace dymaptic.GeoBlazor.Core.Components;

public partial class Portal : MapComponent
{
    /// <summary>
    ///     The URL to the portal instance.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}