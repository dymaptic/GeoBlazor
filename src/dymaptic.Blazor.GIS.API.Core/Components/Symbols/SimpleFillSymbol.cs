using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public class SimpleFillSymbol : FillSymbol, IEquatable<SimpleFillSymbol>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("style")]
    [Parameter]
    public FillStyle? FillStyle { get; set; }

    public override string Type => "simple-fill";

    public bool Equals(SimpleFillSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && (FillStyle == other.FillStyle);
    }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                    await UpdateComponent();
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((SimpleFillSymbol)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), FillStyle);
    }
}

[JsonConverter(typeof(FillStyleConverter))]
public enum FillStyle
{
    BackwardDiagonal,
    Cross,
    DiagonalCross,
    ForwardDiagonal,
    Horizontal,
    None,
    Solid,
    Vertical
}

public class FillStyleConverter : JsonConverter<FillStyle>
{
    public override FillStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, FillStyle value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(FillStyle), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}