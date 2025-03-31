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

        Utf8JsonReader cloneReader = reader;
        
        // find the closest match based on the properties
        Dictionary<string, object>? properties = JsonSerializer.Deserialize<Dictionary<string, object>>(ref reader, options);

        if (properties is null || properties.Count == 0)
        {
            // No properties found, return null
            return default;
        }

        if (properties.TryGetValue("type", out object? typeSerializedValue))
        {
            string typeString = typeSerializedValue.ToString()!;
            foreach (Type t in possibleTypes)
            {
                if (t.GetProperty("Type") is { SetMethod: null } typeProp)
                {
                    string? typeVal = typeProp.GetValue(Activator.CreateInstance(t)) as string;

                    if (typeVal == typeString || typeVal?.ToKebabCase() == typeString)
                    {
                        return (T?)JsonSerializer.Deserialize(ref cloneReader, t, options);
                    }
                }
            }
                
        }
        
        var bestMatch = possibleTypes
            .Select(t => new
            {
                Type = t,
                MatchCount = t.GetProperties().Count(p => properties.ContainsKey(p.Name.ToLowerFirstChar()))
            })
            .OrderByDescending(m => m.MatchCount)
            .FirstOrDefault();
        
        if (bestMatch?.MatchCount > 0)
        {
            // Deserialize using the closest type
            return (T?)JsonSerializer.Deserialize(ref cloneReader, bestMatch.Type, options);
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