using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view against the input geometry. The spatial relationships discover how features are spatially related to each other.
///     <a target="_blank" href="The list of fields included in the returned result set. This list is a comma delimited list of field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection candidate fields.">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(SpatialRelationshipConverter))]
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

internal class SpatialRelationshipConverter : JsonConverter<SpatialRelationship>
{
    public override SpatialRelationship Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, SpatialRelationship value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(SpatialRelationship), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}