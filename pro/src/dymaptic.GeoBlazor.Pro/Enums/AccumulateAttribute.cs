namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Accumulated units for <see cref="RouteParameters.AccumulateAttributes"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AccumulateAttribute>))]
public enum AccumulateAttribute
{
#pragma warning disable CS1591
    Kilometers,
    Miles,
    Minutes,
    TravelTime,
    TruckMinutes,
    TruckTravelTime,
    WalkTime,
    String
#pragma warning restore CS1591
}