namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Possible stop types along a route.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StopLocationType>))]
public enum StopLocationType
{
#pragma warning disable CS1591
    Stop,
    Waypoint,
    Break
#pragma warning restore CS1591
}