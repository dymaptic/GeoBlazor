namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The type of event in a <see cref="DirectionsString"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DirectionEventType>))]
public enum DirectionEventType
{
#pragma warning disable CS1591
    AltName,
    Arrive,
    Branch,
    CrossStreet,
    CumulativeLength,
    Depart,
    EstimatedArrivalTime,
    Exit,
    General,
    Length,
    ServiceTime,
    StreetName,
    Summary,
    Time,
    TimeWindow,
    Toward,
    ViolationTime,
    WaitTime
#pragma warning restore CS1591
}