namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     The event fired by the <see cref="TrackWidget"/>
/// </summary>
/// <param name="Position">
///     The position returned in the event.
/// </param>
public record TrackEvent(GeolocationPosition Position);