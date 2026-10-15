namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Directions a vehicle may arrive at and depart a stop.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StopCurbApproach>))]
public enum StopCurbApproach
{
#pragma warning disable CS1591
    EitherSideOfVehicle,
    RightSideOfVehicle,
    LeftSideOfVehicle,
    NoUTurn
#pragma warning restore CS1591
}