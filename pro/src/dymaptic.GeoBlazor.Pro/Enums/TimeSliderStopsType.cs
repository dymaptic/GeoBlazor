namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
/// Defines specific locations on the time slider where thumbs will snap to when manipulated. If unspecified, ten evenly spaced stops will be added.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TimeSliderStopsType>))]
public enum TimeSliderStopsType
{
#pragma warning disable CS1591
    StopsByDates,
    StopsByCount,
    StopsByInterval
#pragma warning restore CS1591
}