using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

[JsonConverter(typeof(WidgetConverter))]
public abstract class Widget : MapComponent, IEquatable<Widget>
{
    [Parameter]
    public OverlayPosition Position { get; set; }

    [JsonPropertyName("type")]
    public abstract string WidgetType { get; }

    public bool Equals(Widget? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return ((Object)this).Equals(other) && (Position == other.Position) && (WidgetType == other.WidgetType);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Widget)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), (int)Position, WidgetType);
    }
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