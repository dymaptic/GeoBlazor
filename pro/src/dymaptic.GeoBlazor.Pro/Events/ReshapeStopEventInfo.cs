namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record ReshapeStopEventInfo : ReshapeEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "reshape-stop";
}