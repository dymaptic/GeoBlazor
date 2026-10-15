namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Point Barrier restriction types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PolygonBarrierType>))]
public enum PolygonBarrierType
{
#pragma warning disable CS1591
    Restriction,
    ScaledCost
#pragma warning restore CS1591
}