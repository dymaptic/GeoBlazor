namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record ScaleStartEventInfo : ScaleEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "scale-start";
}