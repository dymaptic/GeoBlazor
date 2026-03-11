using System.Drawing;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Creates a new color object by passing either a hex, rgb(a), hsl(a) or named color value. Hex, hsl(a) and named color values can be passed as a string: <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(MapColorConverter))]
[CodeGenerationIgnore]
[ProtobufSerializable]
public class MapColor : IEquatable<MapColor>, IEnumerable, IProtobufSerializable<MapColorSerializationRecord>
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
    public MapColor(params IReadOnlyList<double> values)
    {
        RgbaValues = values.ToArray();
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
    ///     Implicitly converts a color hex or name value to a GeoBlazor <see cref="MapColor" /> instance.
    /// </summary>
    public static implicit operator MapColor(string hexOrNameValue) => new(hexOrNameValue);

    /// <summary>
    ///     Implicitly converts a GeoBlazor <see cref="MapColor" /> instance to a hex or name value.
    /// </summary>
    public static implicit operator string?(MapColor color) => color.HexOrNameValue ?? color.ToHex();

    /// <summary>
    ///     Implicitly converts a numeric array to a GeoBlazor <see cref="MapColor" /> instance.
    /// </summary>
    public static implicit operator MapColor(double[] rgbaValues) => new(rgbaValues);

    /// <summary>
    ///     Implicitly converts a numeric array to a GeoBlazor <see cref="MapColor" /> instance.
    /// </summary>
    public static implicit operator MapColor(List<double> rgbaValues) => new(rgbaValues);

    /// <summary>
    ///     The numeric values for calculating a color (rgb/rgba).
    /// </summary>
    public double[]? RgbaValues
    {
        get
        {
            if (_rgbaValues is null)
            {
                Color? color = ToSystemColor();

                if (color is not null)
                {
                    _rgbaValues = [color.Value.R, color.Value.G, color.Value.B, color.Value.A / 255.0];
                }
            }

            return _rgbaValues;
        }
        private init
        {
            _rgbaValues = value;
            Color? color = ToSystemColor();

            if (color is not null && string.IsNullOrEmpty(HexOrNameValue))
            {
                _hexOrNameValue = ToHex();
            }
        }
    }

    /// <summary>
    ///     The name or hex value of the color.
    /// </summary>
    public string? HexOrNameValue
    {
        get
        {
            _hexOrNameValue ??= ToHex();

            return _hexOrNameValue;
        }
        private init
        {
            _hexOrNameValue = value;
            Color? color = ToSystemColor();

            if (color is not null && (RgbaValues is null || RgbaValues.Length == 0))
            {
                RgbaValues = [color.Value.R, color.Value.G, color.Value.B, color.Value.A / 255.0];
            }
        }
    }

    /// <summary>
    ///     Provides support for Collection Expressions.
    /// </summary>
    public IEnumerator GetEnumerator()
    {
        return _rgbaValues?.GetEnumerator() ?? Enumerable.Empty<double>().GetEnumerator();
    }

    /// <inheritdoc />
    public bool Equals(MapColor? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        if (RgbaValues is null && other.RgbaValues is null)
        {
            return HexOrNameValue == other.HexOrNameValue;
        }

        if (RgbaValues is null || other.RgbaValues is null)
        {
            return false;
        }

        return RgbaValues.SequenceEqual(other.RgbaValues) && (HexOrNameValue == other.HexOrNameValue);
    }

    /// <summary>
    ///     Converts the map color to a protobuf serialization record.
    /// </summary>
    public MapColorSerializationRecord ToProtobuf()
    {
        return new MapColorSerializationRecord(RgbaValues, HexOrNameValue);
    }

    /// <summary>
    ///     Creates a Color instance by blending two colors using a weight factor.
    /// </summary>
    /// <param name="start">
    ///     The start color.
    /// </param>
    /// <param name="end">
    ///     The end color.
    /// </param>
    /// <param name="weight">
    ///     The weight factor. 0 means the start color, 1 means the end color, 0.5 means a 50/50 blend.
    /// </param>
    /// <returns>
    ///     A new color instance representing the blended color, or null if the colors could not be blended.
    /// </returns>
    public static MapColor? BlendColors(MapColor start, MapColor end, double weight)
    {
        if (start.RgbaValues?.Any() == true && end.RgbaValues?.Any() == true)
        {
            double[] startValues = start.RgbaValues.ToArray();
            double[] endValues = end.RgbaValues.ToArray();

            double[] blendedValues = new double[4];

            for (int i = 0; i < 4; i++)
            {
                if (i > startValues.Length - 1 || i > endValues.Length - 1)
                {
                    break;
                }

                blendedValues[i] = startValues[i] + (endValues[i] - startValues[i]) * weight;
            }

            return new MapColor(blendedValues);
        }

        return null;
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
        return HashCode.Combine(RgbaValues, HexOrNameValue);
    }

    /// <summary>
    ///     For internal use only, used to support Collection Expressions and implicit conversions from arrays/lists.
    /// </summary>
    public void Add(double val)
    {
        _rgbaValues = _rgbaValues is null ? [val] : [.._rgbaValues, val];
    }

    /// <summary>
    ///     Clones the color object.
    /// </summary>
    public MapColor Clone()
    {
        return RgbaValues?.Any() == true ? new MapColor(RgbaValues.ToArray()) : new MapColor(HexOrNameValue!);
    }

    /// <summary>
    ///     Returns a CSS color string in rgba form representing the Color instance.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html#toCss">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? ToCss()
    {
        Color? color = ToSystemColor();

        return color is null
            ? null
            : $"rgba({color.Value.R}, {color.Value.G}, {color.Value.B}, {color.Value.A / 255.0})";
    }

    /// <summary>
    ///     Returns the color in hexadecimal format.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html#toHex">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? ToHex()
    {
        Color? color = ToSystemColor();

        return color is null ? null : $"#{color.Value.R:X2}{color.Value.G:X2}{color.Value.B:X2}{color.Value.A:X2}";
    }

    /// <summary>
    ///     Returns a <see cref="System.Drawing.Color" /> instance representing the Color instance.
    /// </summary>
    public Color? ToSystemColor()
    {
        if (RgbaValues?.Any() == true)
        {
            if (RgbaValues.Length == 4)
            {
                return Color.FromArgb((int)(RgbaValues[3] * 255),
                    (int)RgbaValues[0],
                    (int)RgbaValues[1],
                    (int)RgbaValues[2]);
            }

            return Color.FromArgb(255,
                (int)RgbaValues[0],
                (int)RgbaValues[1],
                (int)RgbaValues[2]);
        }

        if (HexOrNameValue is null)
        {
            return null;
        }

        if (HexOrNameValue.StartsWith("#"))
        {
            if (HexOrNameValue.Length == 9)
            {
                // Assume rgba format
                // The ColorTranslator.FromHtml method does not support rgba format, so we parse it manually first
                string alphaHex = HexOrNameValue.Substring(7, 2);

                if (int.TryParse(alphaHex, NumberStyles.HexNumber, null, out int alphaValue))
                {
                    return Color.FromArgb(alphaValue,
                        ColorTranslator.FromHtml(HexOrNameValue.Substring(0, 7)));
                }
            }

            return ColorTranslator.FromHtml(HexOrNameValue);
        }

        return Color.FromName(HexOrNameValue);
    }

    private double[]? _rgbaValues = [];
    private string? _hexOrNameValue;
}

internal class MapColorConverter : JsonConverter<MapColor>
{
    public override MapColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            double[] values = JsonSerializer.Deserialize<double[]>(ref reader, options)!;

            if (values is [_, _, _, > 1])
            {
                values[3] /= 255.0;
            }

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
        if (value.RgbaValues?.Any() == true)
        {
            writer.WriteRawValue(JsonSerializer.Serialize(value.RgbaValues, options));
        }
        else if (value.HexOrNameValue is not null)
        {
            writer.WriteRawValue($"\"{value.HexOrNameValue}\"");
        }
    }
}