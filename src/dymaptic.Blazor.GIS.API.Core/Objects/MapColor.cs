using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

[JsonConverter(typeof(MapColorConverter))]
public class MapColor : IEquatable<MapColor>
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

    public bool Equals(MapColor? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Values.Equals(other.Values) && (HexValue == other.HexValue);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapColor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Values, HexValue);
    }
}

public class MapColorConverter : JsonConverter<MapColor>
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