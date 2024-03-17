using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     The IImageryRenderer is an interface for a group of renderers used for Imagery Layers
/// </summary>
[JsonConverter(typeof(ImageryRendererConverter))]
public interface IImageryRenderer
{
    /// <summary>
    ///     The type of renderer.
    /// </summary>
    [JsonPropertyName("type")]
    public string ImageryRendererType { get; }
}

internal class ImageryRendererConverter : JsonConverter<IImageryRenderer>
{
    public override IImageryRenderer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "raster-stretch":
                    return JsonSerializer.Deserialize<RasterStretchRenderer>(ref cloneReader, newOptions);
                case "unique-value":
                    return JsonSerializer.Deserialize<UniqueValueRenderer>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, IImageryRenderer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}