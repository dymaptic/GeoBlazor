namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The status of the stop with respect to the underlying street network.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StopStatus>))]
public enum StopStatus
{
#pragma warning disable CS1591
    Ok,
    NotLocated,
    NetworkElementNotLocated,
    ElementNotTraversable,
    InvalidFieldValues,
    NotReached,
    TimeWindowViolation,
    NotLocatedOnClosest
#pragma warning restore CS1591
}