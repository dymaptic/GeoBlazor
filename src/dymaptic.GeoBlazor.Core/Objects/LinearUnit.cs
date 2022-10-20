using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A collection of units for measuring Linear distances.
/// </summary>
[JsonConverter(typeof(LinearUnitsConverter))]
public enum LinearUnit
{
#pragma warning disable CS1591
    Meters,
    Feet,
    Kilometers,
    Miles,
    NauticalMiles,
    Yards
#pragma warning restore CS1591
}

internal class LinearUnitsConverter : JsonConverter<LinearUnit>
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