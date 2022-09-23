using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public class SimpleFillSymbol : FillSymbol
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("style")]
    [Parameter]
    public FillStyle? FillStyle { get; set; }

    public override string Type => "simple-fill";

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
    
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
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