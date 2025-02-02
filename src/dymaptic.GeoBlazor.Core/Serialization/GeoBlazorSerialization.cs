namespace dymaptic.GeoBlazor.Core.Serialization;

internal static class GeoBlazorSerialization
{
    static GeoBlazorSerialization()
    {
        JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new NullableDateTimeConverter()
            }
        };
    }
    
    public static JsonSerializerOptions JsonSerializerOptions { get; private set; }
}