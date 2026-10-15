namespace dymaptic.GeoBlazor.Pro.Events;

public partial record MoveEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "move";
}