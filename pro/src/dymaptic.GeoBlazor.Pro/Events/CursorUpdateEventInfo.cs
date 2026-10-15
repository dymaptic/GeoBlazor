namespace dymaptic.GeoBlazor.Pro.Events;

public partial record CursorUpdateEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "cursor-update";
}