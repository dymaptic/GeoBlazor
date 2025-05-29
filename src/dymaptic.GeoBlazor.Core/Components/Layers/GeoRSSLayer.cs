namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class GeoRSSLayer : Layer
{


    /// <inheritdoc />
    public override LayerType Type => LayerType.GeoRSS;

    /// <summary>
    ///     The url for the GeoRSS source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}