namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view
///     against the input geometry. The spatial relationships discover how features are spatially related to each other.
///     <a target="_blank" href="The list of fields included in the returned result set. This list is a comma delimited list of field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection candidate fields.">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SpatialRelationship>))]
public enum SpatialRelationship
{
#pragma warning disable CS1591
    Intersects,
    Contains,
    Crosses,
    EnvelopeIntersects,
    Overlaps,
    Touches,
    Within,
    Disjoint,
    Relation,
    IndexIntersects,
    EqualTo
#pragma warning restore CS1591
}