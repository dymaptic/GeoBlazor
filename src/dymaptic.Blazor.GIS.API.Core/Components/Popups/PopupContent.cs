using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.Blazor.GIS.API.Core.Components.Popups;

[JsonConverter(typeof(PopupContentConverter))]
public abstract class PopupContent : MapComponent
{
    [JsonPropertyName("type")]
    public abstract string Type { get; }
}

public class PopupContentConverter : JsonConverter<PopupContent>
{
    public override PopupContent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, PopupContent value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}