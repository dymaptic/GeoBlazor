using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public abstract class LineSymbol : Symbol, IEquatable<LineSymbol>
{
    [Parameter]
    public double? Width { get; set; }

    [JsonPropertyName("style")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public LineStyle? LineStyle { get; set; }

    public bool Equals(LineSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Nullable.Equals(Width, other.Width) && (LineStyle == other.LineStyle);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((LineSymbol)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Width, LineStyle);
    }
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