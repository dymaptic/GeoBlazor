using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

[JsonConverter(typeof(RendererConverter))]
public abstract class Renderer : LayerObject
{
    [JsonPropertyName("type")]
    public abstract RendererType RendererType { get; }
}

public class RendererConverter : JsonConverter<Renderer>
{
    public override Renderer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Renderer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}

[JsonConverter(typeof(RendererTypeConverter))]
public enum RendererType
{
    Simple,
    UniqueValue
}

public class RendererTypeConverter : JsonConverter<RendererType>
{
    public override RendererType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, RendererType value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(RendererType), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}