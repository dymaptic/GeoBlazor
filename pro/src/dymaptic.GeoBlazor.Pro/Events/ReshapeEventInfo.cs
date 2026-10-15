namespace dymaptic.GeoBlazor.Pro.Events;

public partial record ReshapeEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "reshape";
}