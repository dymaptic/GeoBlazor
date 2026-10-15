namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record MoveStartEventInfo : MoveEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "move-start";
}