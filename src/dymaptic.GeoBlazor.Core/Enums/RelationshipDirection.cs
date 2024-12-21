namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The direction of the relationship. Can either be forward (from origin to destination) or reverse (from destination to origin).
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RelationshipDirection>))]
public enum RelationshipDirection
{
    /// <summary>
    ///     Indicates that the relationship is from the origin to the destination.
    /// </summary>
    Forward,
    /// <summary>
    ///     Indicates that the relationship is from the destination to the origin.
    /// </summary>
    Reverse
}