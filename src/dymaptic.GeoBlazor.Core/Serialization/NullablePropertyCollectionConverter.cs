namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Tries to deserialize an IReadOnlyList of properties. If it fails, it returns null.
/// </summary>
internal class NullablePropertyCollectionConverter<T>: JsonConverter<IReadOnlyList<T>?>

{
    public override IReadOnlyList<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return JsonSerializer.Deserialize<IReadOnlyList<T>>(ref reader, options);
        }
        catch
        {
            return null; // Ignore errors and set to null
        }
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<T>? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }

}

/// <summary>
///     Attempts to deserialize an IReadOnlyList of properties. Any items that are null will be skipped.
/// </summary>
internal class NonNullablePropertyCollectionConverter<T> : JsonConverter<IReadOnlyList<T>>
{
    public override IReadOnlyList<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            // Deserialize the list, ignoring null values
            IReadOnlyList<T>? list = JsonSerializer.Deserialize<IReadOnlyList<T>>(ref reader, options);
            return list?.Where(item => item is not null).ToList() ?? [];
        }
        catch
        {
            return []; // Ignore errors and return an empty list
        }
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<T> value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}