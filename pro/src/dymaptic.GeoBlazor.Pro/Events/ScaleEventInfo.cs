namespace dymaptic.GeoBlazor.Pro.Events;

public partial record ScaleEventInfo : ToolEventInfo
{
    /// <inheritdoc/>
    public override string InfoType => "scale";
}