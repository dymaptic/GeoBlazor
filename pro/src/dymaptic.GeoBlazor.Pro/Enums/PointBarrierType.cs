namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Point Barrier restriction types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PointBarrierType>))]
public enum PointBarrierType
{
#pragma warning disable CS1591
    Restriction,
    AddedCost
#pragma warning restore CS1591
}