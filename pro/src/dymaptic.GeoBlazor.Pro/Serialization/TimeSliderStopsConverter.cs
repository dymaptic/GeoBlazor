namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class TimeSliderStopsConverter : JsonConverter<TimeSliderStops>
{
    public override TimeSliderStops? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "stops-by-dates":
                    return JsonSerializer.Deserialize<StopsByDates>(ref cloneReader, newOptions);
                case "stops-by-interval":
                    return JsonSerializer.Deserialize<StopsByInterval>(ref cloneReader, newOptions);
                case "stops-by-count":
                    return JsonSerializer.Deserialize<StopsByCount>(ref cloneReader, newOptions);
                default:
                    throw new NotSupportedException($"Unsupported type: {typeValue}");
            }
        }
        if (temp.TryGetValue("count", out object? _))
        {
            // If 'count' is present, we assume it's StopsByCount
            return JsonSerializer.Deserialize<StopsByCount>(ref cloneReader, newOptions);
        }
        
        if (temp.TryGetValue("dates", out object? _))
        {
            // If 'dates' is present, we assume it's StopsByDates
            return JsonSerializer.Deserialize<StopsByDates>(ref cloneReader, newOptions);
        }
        
        if (temp.TryGetValue("interval", out object? _))
        {
            // If 'interval' is present, we assume it's StopsByInterval
            return JsonSerializer.Deserialize<StopsByInterval>(ref cloneReader, newOptions);
        }

        throw new NotSupportedException($"Unsupported type: {typeValue}");
    }

    public override void Write(Utf8JsonWriter writer, TimeSliderStops value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}