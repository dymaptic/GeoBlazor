using dymaptic.GeoBlazor.Core.Components.Geometries;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store vector data or continuous cells/pixels that store raster data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(LayerConverter))]
public abstract class Layer : MapComponent
{
    /// <summary>
    ///     Used internally to identify the sub type of Layer
    /// </summary>
    [JsonPropertyName("type")]
    public virtual string LayerType => default!;

    /// <summary>
    ///     The opacity of the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    /// <summary>
    ///     Used internally to identify multiple layers.
    /// </summary>
    [JsonIgnore]
    public int LayerIndex { get; set; }
}

internal class LayerConverter : JsonConverter<Layer>
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