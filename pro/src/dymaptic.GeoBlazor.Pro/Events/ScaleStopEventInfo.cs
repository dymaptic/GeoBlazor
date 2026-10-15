namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record ScaleStopEventInfo : ScaleEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "scale-stop";
}