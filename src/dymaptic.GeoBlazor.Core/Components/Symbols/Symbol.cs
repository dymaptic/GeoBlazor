using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Symbol is the abstract base class for all symbols. Symbols represent point, line, polygon, and mesh geometries as vector graphics within a View. Symbols can only be set directly on individual graphics in a GraphicsLayer or in View.graphics. Otherwise they are assigned to a Renderer that is applied to a Layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html">ArcGIS JS API</a<
/// </summary>
[JsonConverter(typeof(SymbolJsonConverter))]
public abstract class Symbol : MapComponent
{
    /// <summary>
    ///     The color of the symbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The symbol type
    /// </summary>
    public virtual string Type => default!;
}

internal class SymbolJsonConverter : JsonConverter<Symbol>
{
    public override Symbol? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as Symbol;
    }

    public override void Write(Utf8JsonWriter writer, Symbol value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}