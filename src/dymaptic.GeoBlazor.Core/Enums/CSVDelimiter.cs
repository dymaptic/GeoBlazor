using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible Column Delimiters for CSVLayer
/// </summary>
[JsonConverter(typeof(CSVDelimiterConverter))]
public enum CSVDelimiter
{
#pragma warning disable CS1591
    Comma,
    Space,
    Semicolon,
    Pipe,
    TabDelimited
#pragma warning restore CS1591
}

internal class CSVDelimiterConverter : JsonConverter<CSVDelimiter>
{
    public override CSVDelimiter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, CSVDelimiter value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case CSVDelimiter.Comma:
                writer.WriteStringValue(",");

                break;
            case CSVDelimiter.Space:
                writer.WriteStringValue(" ");

                break;
            case CSVDelimiter.Semicolon:
                writer.WriteStringValue(";");

                break;
            case CSVDelimiter.Pipe:
                writer.WriteStringValue("|");

                break;
            case CSVDelimiter.TabDelimited:
                writer.WriteStringValue("\t");

                break;
        }
    }
}