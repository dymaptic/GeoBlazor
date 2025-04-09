namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeolocationOptions.html">GeoBlazor Docs</a>
///     An object used for setting optional position parameters.
///     default null
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GeolocationPositioning.html#geolocationOptions">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class GeolocationOptions: MapComponent
{
    /// <summary>
    ///     The enableHighAccuracy member provides a hint that the application would like to receive the most accurate location data. The intended purpose of this member is to allow applications to inform the implementation that they do not require high accuracy geolocation fixes and, therefore, the implementation MAY avoid using geolocation providers that consume a significant amount of power (e.g., GPS).
    /// </summary>
    /// <remarks>
    ///     The enableHighAccuracy member can result in slower response times or increased power consumption. The user might also disable this capability, or the device might not be able to provide more accurate results than if the flag wasn't specified.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableHighAccuracy { get; set; }
    
    /// <summary>
    ///     The timeout member denotes the maximum length of time, expressed in milliseconds, before acquiring a position expires.
    /// </summary>
    /// <remarks>
    ///     The time spent waiting for the document to become visible and for obtaining permission to use the API is not included in the period covered by the timeout member. The timeout member only applies when acquiring a position begins.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? Timeout { get; set; }
    
    /// <summary>
    ///     The maximumAge member indicates that the web application is willing to accept a cached position whose age is no greater than the specified time in milliseconds.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? MaximumAge { get; set; }
}