namespace dymaptic.GeoBlazor.Core.Serialization;

internal class CultureConverter: JsonConverter<CultureInfo>
{
    public override CultureInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();

            if (value is null)
            {
                return null;
            }
            
            return new CultureInfo(value);
        }

        return CultureInfo.CurrentCulture;
    }

    public override void Write(Utf8JsonWriter writer, CultureInfo value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }
}