namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Tries to deserialize a property. If it fails, it returns null.
/// </summary>
internal class NullablePropertyConverter<T> : JsonConverter<T?>
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }
        catch
        {
            return default(T?); // Ignore errors and set to null
        }
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}