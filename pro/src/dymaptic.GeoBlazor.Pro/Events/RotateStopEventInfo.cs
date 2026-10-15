namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record RotateStopEventInfo : RotateEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "rotate-stop";
}