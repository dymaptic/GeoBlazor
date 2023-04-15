using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Symbol is the abstract base class for all symbols. Symbols represent point, line, polygon, and mesh geometries as
///     vector graphics within a View. Symbols can only be set directly on individual graphics in a GraphicsLayer or in
///     View.graphics. Otherwise they are assigned to a Renderer that is applied to a Layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html">
///         ArcGIS
///         JS API
///     </a>
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

    internal abstract SymbolSerializationRecord ToSerializationRecord();
}

internal class SymbolJsonConverter : JsonConverter<Symbol>
{
    public override Symbol? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // deserialize based on the subclass type
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

        if (temp.ContainsKey("type"))
        {
            switch (temp["type"]?.ToString())
            {
                case "simple-marker":
                    return JsonSerializer.Deserialize<SimpleMarkerSymbol>(ref cloneReader, newOptions);
                case "simple-line":
                    return JsonSerializer.Deserialize<SimpleLineSymbol>(ref cloneReader, newOptions);
                case "simple-fill":
                    return JsonSerializer.Deserialize<SimpleFillSymbol>(ref cloneReader, newOptions);
                case "picture-marker":
                    return JsonSerializer.Deserialize<PictureMarkerSymbol>(ref cloneReader, newOptions);
                case "text":
                    return JsonSerializer.Deserialize<TextSymbol>(ref cloneReader, newOptions);
            }
        }

        return null;
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

[ProtoContract(Name = "Symbol")]
internal record SymbolSerializationRecord([property: ProtoMember(1)] string Type,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(2)]
        MapColor? Color)
    : MapComponentSerializationRecord
{
    [ProtoMember(3)]
    public SymbolSerializationRecord? Outline { get; init; }
    
    [ProtoMember(4)]
    public double? Size { get; init; }
    
    [ProtoMember(5)]
    public string? Style { get; init; }
    
    [ProtoMember(6)]
    public double? Angle { get; init; }
    
    [ProtoMember(7)]
    public double? XOffset { get; init; }
    
    [ProtoMember(8)]
    public double? YOffset { get; init; }
    
    [ProtoMember(9)]
    public double? Width { get; init; }
    
    [ProtoMember(10)]
    public string? LineStyle { get; init; }
    
    [ProtoMember(11)]
    public string? Text { get; init; }
    
    [ProtoMember(12)]
    public MapColor? HaloColor { get; init; }
    
    [ProtoMember(13)]
    public double? HaloSize { get; init; }
    
    [ProtoMember(14)]
    public MapFont? MapFont { get; init; }
    
    [ProtoMember(15)]
    public double? Height { get; init; }
    
    [ProtoMember(16)]
    public string? Url { get; init; }
}