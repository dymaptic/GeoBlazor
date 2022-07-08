using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public abstract class LineSymbol : Symbol
{
    [Parameter]
    public double? Width { get; set; }

    [JsonPropertyName("style")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public LineStyle? LineStyle { get; set; }
}

[JsonConverter(typeof(LineStyleConverter))]
public enum LineStyle
{
    Solid,
    ShortDot,
    Dash
}

public class LineStyleConverter : JsonConverter<LineStyle>
{
    public override LineStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, LineStyle value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(LineStyle), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}