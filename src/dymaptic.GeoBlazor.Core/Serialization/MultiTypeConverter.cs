namespace dymaptic.GeoBlazor.Core.Serialization;

internal class MultiTypeConverter<T> : JsonConverter<T>
{
    static MultiTypeConverter()
    {
        allTypes = Assembly.Load("dymaptic.GeoBlazor.Core").GetTypes();

        try
        {
            allTypes = allTypes
                .Concat(Assembly.Load("dymaptic.GeoBlazor.Pro").GetTypes())
                .ToArray();
        }
        catch (Exception)
        {
            // ignored, Pro is not available
        }
    }
    
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Type[] possibleTypes = allTypes
            .Where(t => t.IsAssignableTo(typeof(T)) && t.IsClass)
            .ToArray();

        if (possibleTypes.Length == 0)
        {
            return default;
        }
        if (possibleTypes.Length == 1)
        {
            // Deserialize using the found type
            return (T?)JsonSerializer.Deserialize(ref reader, possibleTypes[0], options);
        }
        
        // find the closest match based on the properties
        Dictionary<string, object>? properties = JsonSerializer.Deserialize<Dictionary<string, object>>(ref reader, options);

        if (properties is null)
        {
            return default;
        }
        
        var bestMatch = possibleTypes
            .Select(t => new
            {
                Type = t,
                MatchCount = t.GetProperties().Count(p => properties.ContainsKey(p.Name))
            })
            .OrderByDescending(m => m.MatchCount)
            .FirstOrDefault();
        
        if (bestMatch?.MatchCount > 0)
        {
            // Deserialize using the closest type
            return (T?)JsonSerializer.Deserialize(ref reader, bestMatch.Type, options);
        }

        // Return null if the type is not available
        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), GeoBlazorSerialization.JsonSerializerOptions));
    }
    
    // ReSharper disable once StaticMemberInGenericType
    private static readonly Type[] allTypes;
}