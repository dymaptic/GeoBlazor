using dymaptic.GeoBlazor.Core.Enums;
using System.Reflection;
using dymaptic.GeoBlazor.Core.Objects;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Abstract base class, renderers define how to visually represent each feature in one of the following layer types:
///     FeatureLayer, SceneLayer, MapImageLayer, CSVLayer, GeoJSONLayer, OGCFeatureLayer, StreamLayer, WFSLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-Renderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(RendererConverter))]
public abstract class Renderer: MapComponent
{
    /// <summary>
    ///     The subclass Renderer type
    /// </summary>
    [JsonPropertyName("type")]
    // TODO: Setting this as an enum was a mistake that caused much more work when using this for reflection and deserialization
    // in a future version, we should replace with a string.
    public abstract RendererType RendererType { get; }
    
    /// <summary>
    ///     Authoring metadata only included in renderers generated from one of the Smart Mapping creator methods, such as sizeRendererCreator.createContinuousRenderer() or colorRendererCreator.createContinuousRenderer(). This includes information from UI elements such as sliders and selected classification methods and themes. This allows the authoring clients to save specific overridable settings so that next time it is accessed via the UI, their selections can be remembered.
    /// </summary>
    [JsonInclude]
    public AuthoringInfo? AuthoringInfo { get; private init; }
}

internal class RendererConverter : JsonConverter<Renderer>
{
    public override Renderer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case "simple":
                    return JsonSerializer.Deserialize<SimpleRenderer>(ref cloneReader, newOptions);
                case "unique-value":
                    return JsonSerializer.Deserialize<UniqueValueRenderer>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // try to turn the typeValue into a Type
                    try
                    {
                        string typeName = typeof(RendererType).GetMember(typeValue.ToString()!).First()
                            .GetCustomAttribute<LookupTypeAttribute>()!.TypeName;
                        Type? type = Type.GetType(typeName);
                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as Renderer;
                        }
                    }
                    catch
                    {
                        // ignored
                    }

                    break;
            }
        }

        return null;
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