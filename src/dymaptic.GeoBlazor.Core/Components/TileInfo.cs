namespace dymaptic.GeoBlazor.Core.Components;

public partial class TileInfo : MapComponent
{
    /// <summary>
    ///     The dots per inch (DPI) of the tiling scheme.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Dpi { get; set; }

    /// <summary>
    ///     Image format of the cached tiles.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfoFormat? Format { get; set; }

    /// <summary>
    ///     Indicates if the tiling scheme supports wrap around.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsWrappable { get; set; }


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Point point:
                if (!point.Equals(Origin))
                {
                    Origin = point;
                }

                break;

            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Point _:
                Origin = null;
                break;

            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

}