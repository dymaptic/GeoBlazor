namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class PrintLayoutConverter : EnumToKebabCaseStringConverter<PrintLayout>
{
    // custom converter to match expected string values in ArcGIS Maps SDK for JavaScript
    // this doesn't match what EnumToKebabCaseStringConverter does by default
    public override void Write(Utf8JsonWriter writer, PrintLayout value, JsonSerializerOptions options)
    {
        string stringVal = Convert(value);
        writer.WriteStringValue(stringVal);
    }
    
    public static string Convert(PrintLayout value)
    {
        // custom conversion to match expected string values in ArcGIS Maps SDK for JavaScript
        // this doesn't match what EnumToKebabCaseStringConverter does by default
        return value switch
        {
            PrintLayout.A3Landscape => A3Landscape,
            PrintLayout.A3Portrait => A3Portrait,
            PrintLayout.A4Landscape => A4Landscape,
            PrintLayout.A4Portrait => A4Portrait,
            _ => value.ToString().ToKebabCase()
        };
    }
    
    public static PrintLayout Parse(string? value)
    {
        // custom parsing to match expected string values in ArcGIS Maps SDK for JavaScript
        // this doesn't match what EnumToKebabCaseStringConverter does by default
        return value switch
        {
            A3Landscape => PrintLayout.A3Landscape,
            A4Landscape => PrintLayout.A4Landscape,
            A3Portrait => PrintLayout.A3Portrait,
            A4Portrait => PrintLayout.A4Portrait,
            null => PrintLayout.All,
            _ => (PrintLayout)Enum.Parse(typeof(PrintLayout), 
                value.Replace("esri", string.Empty, StringComparison.OrdinalIgnoreCase)
                    .Replace("PrintLayout", string.Empty, StringComparison.OrdinalIgnoreCase)
                    .KebabToPascalCase(), true)
        };
    }
    
    private const string A3Landscape = "a3-landscape";
    private const string A3Portrait = "a3-portrait";
    private const string A4Landscape = "a4-landscape";
    private const string A4Portrait = "a4-portrait";
}

internal class PrintLayoutReadOnlyListConverter : JsonConverter<IReadOnlyList<PrintLayout>>
{
    public override IReadOnlyList<PrintLayout> Read(ref Utf8JsonReader reader, Type typeToConvert, 
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            // check if the value is a single string
            if (reader.TokenType == JsonTokenType.String)
            {
                string? value = reader.GetString();
                return [PrintLayoutConverter.Parse(value!)];
            }
            
            throw new JsonException("Expected start of array or a single string value.");
        }

        List<PrintLayout> values = [];

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string? value = reader.GetString();
                if (value is not null)
                {
                    values.Add(PrintLayoutConverter.Parse(value));
                }
            }
            else
            {
                throw new JsonException("Expected string value in array.");
            }
        }
        
        if (!values.Any())
        {
            // if no values were read, return an empty list
            values.Add(PrintLayout.All);
        }

        return values;
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<PrintLayout>? value, JsonSerializerOptions options)
    {
        if (value is null || !value.Any())
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartArray();
        foreach (PrintLayout item in value)
        {
            string stringVal = PrintLayoutConverter.Convert(item);
            writer.WriteStringValue(stringVal);
        }
        writer.WriteEndArray();
    }
}