using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(MapColorConverter))]
public class MapColor
{
    public MapColor(params double[] values)
    {
        Values.AddRange(values);
    }

    public MapColor(string hexValue)
    {
        HexValue = hexValue;
    }

    public List<double> Values { get; set; } = new();
    public string? HexValue { get; set; }
}

internal class MapColorConverter : JsonConverter<MapColor>
{
    public override MapColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, MapColor value, JsonSerializerOptions options)
    {
        if (value.Values.Any())
        {
            writer.WriteRawValue(JsonSerializer.Serialize(value.Values, options));
        }
        else if (value.HexValue is not null)
        {
            writer.WriteRawValue($"\"{value.HexValue}\"");
        }
    }
}