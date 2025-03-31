namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The linear units to use for calculating a query buffer distance.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<QueryUnits>))]
public enum QueryUnits
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Feet,
    Miles,
    NauticalMiles,
    UsNauticalMiles,
    Meters,
    Kilometers
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}