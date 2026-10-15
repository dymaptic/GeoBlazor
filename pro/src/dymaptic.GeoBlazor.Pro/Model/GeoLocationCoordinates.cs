namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     <a target="_blank" href="https://www.w3.org/TR/geolocation/#position_options_interface">W3 GeoLocation Spec</a>
/// </summary>
/// <param name="Accuracy">
///     The accuracy attribute denotes the accuracy level of the latitude and longitude coordinates in meters (e.g., 65 meters).
/// </param>
/// <param name="Latitude">
///     Latitude specified in decimal degrees.
/// </param>
/// <param name="Longitude">
///     Longitude specified in decimal degrees.
/// </param>
/// <param name="Altitude">
///     The altitude attribute denotes the height of the position, specified in meters above the [WGS84] ellipsoid.
/// </param>
/// <param name="AltitudeAccuracy">
///     The altitudeAccuracy attribute represents the altitude accuracy in meters (e.g., 10 meters).
/// </param>
/// <param name="Heading">
///     The heading attribute denotes the direction of travel of the hosting device and is specified in degrees, where 0° ≤ heading &lt; 360°, counting clockwise relative to the true north.
/// </param>
/// <param name="Speed">
///     The speed attribute denotes the magnitude of the horizontal component of the hosting device's current velocity in meters per second.
/// </param>
public record GeolocationCoordinates(double Accuracy, double Latitude, double Longitude, double? Altitude,
    double? AltitudeAccuracy, double? Heading, double? Speed): IGeolocationCoordinates;