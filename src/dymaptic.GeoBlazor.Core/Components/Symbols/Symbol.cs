using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[JsonConverter(typeof(SymbolJsonConverter))]
public abstract class Symbol : MapComponent
{
    [Parameter]
    public MapColor? Color { get; set; }

    public virtual string Type => default!;
}

public class SymbolJsonConverter : JsonConverter<Symbol>
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