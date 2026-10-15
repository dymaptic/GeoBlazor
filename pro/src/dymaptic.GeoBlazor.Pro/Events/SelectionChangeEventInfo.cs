namespace dymaptic.GeoBlazor.Pro.Events;

public partial record SelectionChangeEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "selection-change";
}