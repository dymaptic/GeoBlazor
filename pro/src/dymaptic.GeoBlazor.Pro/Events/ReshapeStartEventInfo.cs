namespace dymaptic.GeoBlazor.Pro.Events;

/// <inheritdoc />
public record ReshapeStartEventInfo : ReshapeEventInfo
{
    /// <inheritdoc />
    public override string InfoType => "reshape-start";
}