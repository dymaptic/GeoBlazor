namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Indicates how the U-turns at junctions that could occur during network traversal are handled by the solver.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<UTurnAtJunctions>))]
public enum UTurnAtJunctions
{
#pragma warning disable CS1591
    AllowBacktrack,
    AtDeadEndsOnly,
    NoBacktrack,
    AtDeadEndsAndIntersections
#pragma warning restore CS1591
}