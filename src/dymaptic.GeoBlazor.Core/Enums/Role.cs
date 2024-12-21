namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Indicates whether the table participating in the relationship is the origin or destination table.
/// </summary>
[JsonConverter(typeof(EnumRelationshipConverter<Role>))]
public enum Role
{
    /// <summary>
    ///     Origin
    /// </summary>
    Origin,
    /// <summary>
    ///     Destination
    /// </summary>
    Destination
}