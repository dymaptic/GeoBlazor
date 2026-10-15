namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Possible restrictions on route travel in <see cref="RouteParameters"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RestrictionAttribute>))]
public enum RestrictionAttribute
{
#pragma warning disable CS1591
    AnyHazmatProhibited,
    AvoidCarpoolRoads,
    AvoidExpressLanes,
    AvoidFerries,
    AvoidGates,
    AvoidLimitedAccessRoads,
    AvoidPrivateRoads,
    AvoidRoadsUnsuitableForPedestrians,
    AvoidStairways,
    AvoidTollRoads,
    AvoidTollRoadsForTrucks,
    AvoidTollRestrictedRoads,
    AvoidUnpavedRoads,
    AxleCountRestriction,
    DrivingABus,
    DrivingATaxi,
    DrivingATruck,
    DrivingAnAutomobile,
    DrivingAnEmergencyVehicle,
    HeightRestriction,
    KingpinToRearAxleLengthRestriction,
    LengthRestriction,
    PreferredForPedestrians,
    RidingAMotorcycle,
    RoadsUnderConstructionProhibited,
    SemiOrTractorWithOneOrMoreTrailersProhibited,
    SingleAxleVehiclesProhibited,
    TandemAxleVehiclesProhibited,
    ThroughTrafficProhibited,
    TruckWithTrailersRestriction,
    UsePreferredHazmatRoutes,
    UsePreferredTruckRoutes,
    Walking,
    WeightRestriction,
    String
#pragma warning restore CS1591
}