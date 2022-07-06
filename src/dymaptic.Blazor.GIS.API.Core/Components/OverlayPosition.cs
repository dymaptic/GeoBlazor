using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;

namespace dymaptic.Blazor.GIS.API.Core.Components;

[JsonConverter(typeof(OverlayPositionConverter))]
public enum OverlayPosition
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Manual
}

public class OverlayPositionConverter : JsonConverter<OverlayPosition>
{
    public override OverlayPosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, OverlayPosition value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(OverlayPosition), value);
        string kebabString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{kebabString}\"");
    }
}