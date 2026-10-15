namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Defines specific locations on the time slider where thumbs will snap to when manipulated.
///     If unspecified, ten evenly spaced stops will be added.
/// </summary>
[JsonConverter(typeof(TimeSliderStopsConverter))]
public abstract class TimeSliderStops: MapComponent
{
    /// <summary>
    /// A non-ESRI property to determine the type of stops to help with the serialization.
    /// </summary>
    public abstract TimeSliderStopsType Type { get; }
}