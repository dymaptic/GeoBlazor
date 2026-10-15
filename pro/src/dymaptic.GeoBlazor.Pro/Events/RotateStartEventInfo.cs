namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record RotateStartEventInfo : RotateEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "rotate-start";
}