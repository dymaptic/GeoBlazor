using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public class VisualVariable : MapComponent
{
    [JsonPropertyName("type")]
    [Parameter]
    public VisualVariableType VariableType { get; set; } = VisualVariableType.Size;

    [Parameter, EditorRequired]
    public string Field { get; set; } = default!;

    [Parameter]
    public double MinDataValue { get; set; }

    [Parameter]
    public double MaxDataValue { get; set; }

    [Parameter]
    public string? MinSize { get; set; }

    [Parameter]
    public string? MaxSize { get; set; }
}

[JsonConverter(typeof(VisualVariableTypeConverter))]
public enum VisualVariableType
{
    Size
}

public class VisualVariableTypeConverter : JsonConverter<VisualVariableType>
{
    public override VisualVariableType Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, VisualVariableType value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(VisualVariableType), value);
        string resultString = stringVal!.ToLowerFirstChar();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}