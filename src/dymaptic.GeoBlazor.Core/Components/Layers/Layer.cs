using dymaptic.GeoBlazor.Core.Components.Geometries;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

[JsonConverter(typeof(LayerConverter))]
public abstract class Layer : MapComponent
{
    [JsonPropertyName("type")]
    public virtual string LayerType => default!;

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    [JsonIgnore]
    public int LayerIndex { get; set; }

    public async Task<Extent?> QueryExtent()
    {
        if (JsModule is null) return null;

        return await JsModule!.InvokeAsync<Extent?>("queryExtent", Id);
    }
}

public class LayerConverter : JsonConverter<Layer>
{
    public override Layer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as Layer;
    }

    public override void Write(Utf8JsonWriter writer, Layer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}