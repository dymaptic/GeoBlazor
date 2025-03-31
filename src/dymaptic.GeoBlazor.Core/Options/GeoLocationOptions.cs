namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     <a target="_blank" href="https://www.w3.org/TR/geolocation/#position_options_interface">W3 GeoLocation Spec</a>
/// </summary>
public record GeoLocationOptions
{
    /// <summary>
    ///     The enableHighAccuracy member provides a hint that the application would like to receive the most accurate location data.
    /// </summary>
    public bool? EnableHighAccuracy { get; set; }
    
    /// <summary>
    ///     The timeout member denotes the maximum length of time, expressed in milliseconds, before acquiring a position expires.
    /// </summary>
    public long? Timeout { get; set; }
    
    /// <summary>
    ///     The maximumAge member indicates that the web application is willing to accept a cached position whose age is no greater than the specified time in milliseconds.
    /// </summary>
    public long? MaximumAge { get; set; }
}