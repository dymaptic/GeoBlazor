using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

public class ScaleBarWidget : Widget
{
    public override string WidgetType => "scaleBar";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public ScaleUnit? Unit { get; set; }
}

[JsonConverter(typeof(ScaleUnitConverter))]
public enum ScaleUnit
{
    NonMetric,
    Metric,
    Dual
}

public class ScaleUnitConverter : JsonConverter<ScaleUnit>
{
    public override ScaleUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ScaleUnit value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(ScaleUnit), value);
        string kebabString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{kebabString}\"");
    }
}