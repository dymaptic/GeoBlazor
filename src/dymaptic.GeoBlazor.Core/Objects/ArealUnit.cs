using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Objects;

[JsonConverter(typeof(ArealUnitsConverter))]
public enum ArealUnit
{
    Acres,
    Ares,
    Hectares,
    SquareFeet,
    SquareMeters,
    SquareYards,
    SquareKilometers
}

public class ArealUnitsConverter : JsonConverter<ArealUnit>
{
    public override ArealUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ArealUnit value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(ArealUnit), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}