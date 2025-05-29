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