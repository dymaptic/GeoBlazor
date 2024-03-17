using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Defines a screen measurement in points or pixels. Supports implicit conversion from string, int, or double.
///     Dimensions can include `pt` or `px` units. If no units are specified, `pt` is assumed.
/// </summary>
[JsonConverter(typeof(DimensionConverter))]
public class Dimension
{
    /// <summary>
    ///     Constructs a new Dimension from a string. Supports `pt` or `px` units. If no units are specified, `pt` is assumed.
    /// </summary>
    public Dimension(string stringVal)
    {
        Points = StringToDimension(stringVal);
    }

    /// <summary>
    ///     Constructs a new Dimension from a double. Assumes units are `pt`.
    /// </summary>
    public Dimension(double pointVal)
    {
        Points = pointVal;
    }

    private Dimension()
    {
    }
    
    /// <summary>
    ///     The dimension in points.
    /// </summary>
    public double Points { get; init; }
    
    /// <summary>
    ///     The dimension in pixels.
    /// </summary>
    public double Pixels => Points / 0.75;
    
    /// <summary>
    ///     Implicit conversion from string to Dimension
    /// </summary>
    public static implicit operator Dimension(string stringVal)
    {
        return new Dimension(stringVal);
    }

    /// <summary>
    ///     Implicit conversion from double to Dimension
    /// </summary>
    public static implicit operator Dimension(double doubleVal)
    {
        return new Dimension(doubleVal);
    }

    /// <summary>
    ///     Explicit conversion for handling nullable doubles
    /// </summary>
    public static explicit operator Dimension?(double? nullableDoubleVal)
    {
        return nullableDoubleVal is null ? null : new Dimension(nullableDoubleVal.Value);
    }

    /// <summary>
    ///     Implicit conversion from int to Dimension
    /// </summary>
    public static implicit operator Dimension(int intVal)
    {
        return new Dimension(intVal);
    }

    /// <summary>
    ///     Implicit conversion from Dimension to double
    /// </summary>
    public static implicit operator double(Dimension dimension)
    {
        return dimension.Points;
    }
    
    /// <summary>
    ///     Explicit conversion for handling nullable Dimensions 
    /// </summary>
    public static explicit operator double?(Dimension? dimension)
    {
        return dimension?.Points;
    }

    private static double StringToDimension(string stringVal)
    {
        if (stringVal.EndsWith("pt"))
        {
            stringVal = stringVal.Replace("pt", "");
        }

        if (double.TryParse(stringVal.Trim(), out double doubleVal))
        {
            return doubleVal;
        }

        if (stringVal.EndsWith("px"))
        {
            stringVal = stringVal.Replace("px", "");

            if (double.TryParse(stringVal.Trim(), out doubleVal))
            {
                return doubleVal * 0.75;
            }
        }
        
        throw new FormatException("Invalid dimension string. Formats supported: 12pt, 12px, 12.0, 12.0px, 12.0pt");
    }
}

internal class DimensionConverter: JsonConverter<Dimension>
{
    public override Dimension? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new Dimension(reader.GetString()!);
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            return new Dimension(reader.GetDouble());
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Dimension value, JsonSerializerOptions options)
    {
        writer.WriteRawValue($"\"{value.Points}\"");
    }
}