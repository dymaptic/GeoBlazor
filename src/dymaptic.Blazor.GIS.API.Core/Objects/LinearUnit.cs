using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

[JsonConverter(typeof(LinearUnitsConverter))]
public enum LinearUnit
{
    Meters,
    Feet,
    Kilometers,
    Miles,
    NauticalMiles,
    Yards
}

public class LinearUnitsConverter : JsonConverter<LinearUnit>
{
    public override LinearUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, LinearUnit value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(LinearUnit), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}