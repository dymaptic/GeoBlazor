namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for GeolocationCoordinates
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IGeolocationCoordinates>))]
public interface IGeolocationCoordinates
{
    /// <summary name="Accuracy">
    ///     The accuracy attribute denotes the accuracy level of the latitude and longitude coordinates in meters (e.g., 65 meters).
    /// </summary>
    double Accuracy { get; }

    /// <summary name="Latitude">
    ///     Latitude specified in decimal degrees.
    /// </summary>
    double Latitude { get; }

    /// <summary name="Longitude">
    ///     Longitude specified in decimal degrees.
    /// </summary>
    double Longitude { get; }

    /// <summary name="Altitude">
    ///     The altitude attribute denotes the height of the position, specified in meters above the [WGS84] ellipsoid.
    /// </summary>
    double? Altitude { get; }

    /// <summary name="AltitudeAccuracy">
    ///     The altitudeAccuracy attribute represents the altitude accuracy in meters (e.g., 10 meters).
    /// </summary>
    double? AltitudeAccuracy { get; }

    /// <summary name="Heading">
    ///     The heading attribute denotes the direction of travel of the hosting device and is specified in degrees, where 0° ≤ heading &lt; 360°, counting clockwise relative to the true north.
    /// </summary>
    double? Heading { get; }

    /// <summary name="Speed">
    ///     The speed attribute denotes the magnitude of the horizontal component of the hosting device's current velocity in meters per second.
    /// </summary>
    double? Speed { get; }
}