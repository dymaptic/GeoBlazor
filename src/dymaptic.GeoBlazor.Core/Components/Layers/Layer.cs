using dymaptic.GeoBlazor.Core.Objects;
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
    
    /// <summary>
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    
    /// <summary>
    ///    Represents the view for a single layer after it has been added to either a MapView or a SceneView.
    /// </summary>
    [JsonIgnore]
    public LayerView? LayerView { get; set; }
    
    /// <summary>
    ///    The JavaScript object that represents the layer.
    /// </summary>
    [JsonIgnore]
    public IJSObjectReference? JsObjectReference { get; set; }
    
    /// <inheritdoc />
    public override async ValueTask DisposeAsync()
    {
        await AbortManager.DisposeAsync();
        await base.DisposeAsync();
    }
    
    /// <summary>
    ///     Handles conversion from .NET CancellationToken to JavaScript AbortController
    /// </summary>
    public AbortManager AbortManager { get; set; }
}

internal class LayerConverter : JsonConverter<Layer>
{
    public override Layer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;
        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.ContainsKey("type"))
        {
            switch (temp["type"]?.ToString())
            {
                case "feature":
                    return JsonSerializer.Deserialize<FeatureLayer>(ref cloneReader, newOptions);
                case "graphics":
                    return JsonSerializer.Deserialize<GraphicsLayer>(ref cloneReader, newOptions);
                case "geo-json":
                    return JsonSerializer.Deserialize<GeoJSONLayer>(ref cloneReader, newOptions);
                case "geo-rss":
                    return JsonSerializer.Deserialize<GeoRSSLayer>(ref cloneReader, newOptions);
                case "tile":
                    return JsonSerializer.Deserialize<TileLayer>(ref cloneReader, newOptions);
                case "vector-tile":
                    return JsonSerializer.Deserialize<VectorTileLayer>(ref cloneReader, newOptions);
            }
        }

        return null;
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