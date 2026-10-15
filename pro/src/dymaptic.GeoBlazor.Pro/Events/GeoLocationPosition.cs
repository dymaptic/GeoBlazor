namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     <a target="_blank" href="https://www.w3.org/TR/geolocation/#position_options_interface">W3 GeoLocation Spec</a>
/// </summary>
/// <param name="Coords">
///     The coordinates of the position.
/// </param>
/// <param name="Timestamp">
///     The timestamp of when the coordinates were read.
/// </param>
public record GeolocationPosition(IGeolocationCoordinates Coords, long Timestamp): IGeolocationPosition;