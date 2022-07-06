using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

[JsonConverter(typeof(SpatialRelationshipConverter))]
public enum SpatialRelationship
{
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
}

public class SpatialRelationshipConverter : JsonConverter<SpatialRelationship>
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