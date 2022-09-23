using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

[JsonConverter(typeof(WidgetConverter))]
public abstract class Widget : MapComponent
{
    [Parameter]
    public OverlayPosition? Position { get; set; }
    
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContainerId { get; set; }

    [JsonPropertyName("type")]
    public abstract string WidgetType { get; }
}

public class WidgetConverter : JsonConverter<Widget>
{
    public override Widget Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Widget value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), options));
    }
}