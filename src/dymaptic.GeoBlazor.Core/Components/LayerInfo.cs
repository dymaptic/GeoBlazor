namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerInfo : MapComponent
{
    /// <summary>
    ///     Specifies a title for the layer to display above its symbols and descriptions. If no title is specified the service
    ///     name is used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     The ID for a layer to display in the legend.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     Only applicable if the layer is a MapImageLayer. The IDs of the MapImageLayer sublayers for which to display legend
    ///     information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[]? SublayerIds { get; set; }
}

