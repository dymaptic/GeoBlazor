﻿namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Creates a new color object by passing either a hex, rgb(a), hsl(a) or named color value. Hex, hsl(a) and named
///     color values can be passed as a string:
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(MapColorConverter))]
[ProtoContract]
public class MapColor : IEquatable<MapColor>
{
    /// <summary>
    ///     Parameterless constructor for Protobuf deserialization.
    ///     Not intended for public use.
    /// </summary>
    public MapColor()
    {
    }
    
    /// <summary>
    ///     Creates a new color with a collection of numeric values in rgb or rgba format.
    /// </summary>
    /// <param name="values">
    ///     Requires 3 or 4 values, in the order R(0-255), G(0-255), B(0-255), A(0-1). A is optional.
    /// </param>
    public MapColor(params double[] values)
    {
        Values.AddRange(values);
    }

    /// <summary>
    ///     Creates a new color with a common color name, or a hex value starting with the # sign.
    /// </summary>
    /// <param name="hexOrNameValue">
    ///     The value of the hex or name.
    /// </param>
    public MapColor(string hexOrNameValue)
    {
        HexOrNameValue = hexOrNameValue;
    }

    /// <summary>
    ///     Compares two <see cref="MapColor" /> objects for equality.
    /// </summary>
    public static bool operator ==(MapColor? left, MapColor? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two <see cref="MapColor" /> objects for inequality.
    /// </summary>
    public static bool operator !=(MapColor? left, MapColor? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    ///     The numeric values for calculating a color (rgb/rgba).
    /// </summary>
    [ProtoMember(1)]
    public List<double> Values { get; set; } = new();

    /// <summary>
    ///     The name or hex value of the color.
    /// </summary>
    [ProtoMember(2)]
    public string? HexOrNameValue { get; set; }

    /// <inheritdoc />
    public bool Equals(MapColor? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Values.SequenceEqual(other.Values) && (HexOrNameValue == other.HexOrNameValue);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapColor)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Values, HexOrNameValue);
    }

    /// <summary>
    ///     Clones the color object.
    /// </summary>
    public MapColor Clone()
    {
        return Values.Any() ? new MapColor(Values.ToArray()) : new MapColor(HexOrNameValue!);
    }
}

internal class MapColorConverter : JsonConverter<MapColor>
{
    public override MapColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            double[] values = JsonSerializer.Deserialize<double[]>(ref reader, options)!;

            return new MapColor(values);
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            string hexOrNameValue = reader.GetString()!;

            return new MapColor(hexOrNameValue);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, MapColor value, JsonSerializerOptions options)
    {
        if (value.Values.Any())
        {
            writer.WriteRawValue(JsonSerializer.Serialize(value.Values, options));
        }
        else if (value.HexOrNameValue is not null)
        {
            writer.WriteRawValue($"\"{value.HexOrNameValue}\"");
        }
    }
}