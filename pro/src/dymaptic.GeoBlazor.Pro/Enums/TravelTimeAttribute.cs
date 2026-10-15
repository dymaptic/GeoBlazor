namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Indicates the time-based cost attribute for reporting directions.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TravelTimeAttribute>))]
public enum TravelTimeAttribute
{
#pragma warning disable CS1591
    Minutes,
    TravelTime,
    TruckMinutes,
    TruckTravelTime,
    WalkTime
#pragma warning restore CS1591
}