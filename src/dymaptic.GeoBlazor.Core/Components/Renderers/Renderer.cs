using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Serialization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Abstract base class, renderers define how to visually represent each feature in one of the following layer types:
///     FeatureLayer, SceneLayer, MapImageLayer, CSVLayer, GeoJSONLayer, OGCFeatureLayer, StreamLayer, WFSLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-Renderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(RendererConverter))]
public abstract class Renderer : LayerObject
{
    /// <summary>
    ///     The subclass Renderer type
    /// </summary>
    [JsonPropertyName("type")]
    public abstract RendererType RendererType { get; }
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

/// <summary>
///     A collection of renderer types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RendererType>))]
public enum RendererType
{
#pragma warning disable CS1591
    Simple,
    UniqueValue,
    [LookupType("dymaptic.GeoBlazor.Pro.Components.Renderers.PieChartRenderer")]
    PieChart
#pragma warning restore CS1591
}

public class LookupTypeAttribute : Attribute
{
    public LookupTypeAttribute(string typeName)
    {
        TypeName = typeName;
    }

    public string TypeName { get; set; }
}