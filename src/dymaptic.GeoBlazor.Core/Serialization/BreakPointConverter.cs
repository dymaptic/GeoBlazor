namespace dymaptic.GeoBlazor.Core.Serialization;

internal class BreakPointConverter : JsonConverter<BreakPoint>
{
    public override BreakPoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as BreakPoint;
    }

    public override void Write(Utf8JsonWriter writer, BreakPoint value, JsonSerializerOptions options)
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