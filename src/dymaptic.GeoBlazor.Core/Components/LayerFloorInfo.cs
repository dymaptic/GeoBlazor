namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerFloorInfo : MapComponent
{


    /// <summary>
    ///     The field name derived from a floor-aware layer and used to filter features by floor level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FloorField { get; set; }
}