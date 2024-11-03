using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Interval node sign.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-sql-WhereClause.html#IntervalNode">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(IntervalNodeSignConverter))]
public enum IntervalNodeSign
{
#pragma warning disable CS1591
    Positive,
    Negative,
    NoSign
#pragma warning restore CS1591
}

internal class IntervalNodeSignConverter : JsonConverter<IntervalNodeSign>
{
    public override IntervalNodeSign Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "+" => IntervalNodeSign.Positive,
            "-" => IntervalNodeSign.Negative,
            _ => IntervalNodeSign.NoSign
        };
    }

    public override void Write(Utf8JsonWriter writer, IntervalNodeSign value, JsonSerializerOptions options)
    {
        string sign = value switch
        {
            IntervalNodeSign.Positive => "+",
            IntervalNodeSign.Negative => "-",
            _ => string.Empty
        };

        writer.WriteStringValue(sign);
    }
}