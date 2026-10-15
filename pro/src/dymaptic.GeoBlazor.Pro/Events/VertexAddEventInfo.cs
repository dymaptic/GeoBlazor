namespace dymaptic.GeoBlazor.Pro.Events;

public partial record VertexAddEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "vertex-add";
}