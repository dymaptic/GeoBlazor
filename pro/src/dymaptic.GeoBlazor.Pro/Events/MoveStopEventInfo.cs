namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record MoveStopEventInfo : MoveEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "move-stop";
}