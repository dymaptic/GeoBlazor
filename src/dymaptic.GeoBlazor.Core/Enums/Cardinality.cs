using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The cardinality which specifies the number of objects in the origin FeatureLayer related to the number of objects
///     in the destination FeatureLayer. Please see the Desktop help for additional information on cardinality.
/// </summary>
[JsonConverter(typeof(EnumRelationshipConverter<Cardinality>))]
public enum Cardinality
{
    /// <summary>
    ///     One-to-one
    /// </summary>
    OneToOne,
    /// <summary>
    ///     One-to-many
    /// </summary>
    OneToMany,
    /// <summary>
    ///     Many-to-one
    /// </summary>
    ManyToMany
}