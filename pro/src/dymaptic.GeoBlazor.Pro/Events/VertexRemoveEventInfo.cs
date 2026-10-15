namespace dymaptic.GeoBlazor.Pro.Events;

public partial record VertexRemoveEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "vertex-remove";
}