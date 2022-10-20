using dymaptic.GeoBlazor.Core.Components.Widgets;
using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A collection of possible positions for setting a <see cref="Widget"/> or <see cref="CustomOverlay"/>
/// </summary>
[JsonConverter(typeof(OverlayPositionConverter))]
public enum OverlayPosition
{
#pragma warning disable CS1591
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Manual
#pragma warning restore CS1591
}

internal class OverlayPositionConverter : JsonConverter<OverlayPosition>
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