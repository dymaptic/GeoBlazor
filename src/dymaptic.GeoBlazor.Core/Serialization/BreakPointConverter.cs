namespace dymaptic.GeoBlazor.Core.Serialization;

internal class BreakpointConverter : JsonConverter<Breakpoint>
{
    public override Breakpoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as Breakpoint;
    }

    public override void Write(Utf8JsonWriter writer, Breakpoint value, JsonSerializerOptions options)
    {
        if (value.BoolValue.HasValue)
        {
            JsonSerializer.Serialize(writer, value.BoolValue.Value, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}