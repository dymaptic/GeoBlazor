namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Specifies a layer to display in the legend.
/// </summary>
public class LayerInfo : MapComponent
{
    /// <summary>
    ///     Specifies a title for the layer to display above its symbols and descriptions. If no title is specified the service
    ///     name is used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     A layer to display in the legend.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public Layer Layer { get; set; } = default !;

    /// <summary>
    ///     Only applicable if the layer is a MapImageLayer. The IDs of the MapImageLayer sublayers for which to display legend
    ///     information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[]? SublayerIds { get; set; }
}

