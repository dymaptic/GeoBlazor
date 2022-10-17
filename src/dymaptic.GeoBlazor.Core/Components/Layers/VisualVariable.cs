using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The visual variable base class. See each of the subclasses that extend this class to learn how to create continuous data-driven thematic visualizations.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(VisualVariableConverter))]
public abstract class VisualVariable : MapComponent
{
    /// <summary>
    ///     The visual variable type.
    /// </summary>
    [JsonPropertyName("type")]
    public virtual VisualVariableType VariableType { get; } = default!;

    /// <summary>
    ///     The name of the numeric attribute field that contains the data values used to determine the color/opacity/size/rotation of each feature.
    /// </summary>
    [Parameter, EditorRequired]
    [RequiredProperty]
    public string Field { get; set; } = default!;
    
    /// <summary>
    ///     An object providing options for displaying the visual variable in the Legend.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LegendOptions? LegendOptions { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LegendOptions options:
                if (!options.Equals(LegendOptions))
                {
                    LegendOptions = options;
                    await UpdateComponent();
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LegendOptions _:
                LegendOptions = null;
                await UpdateComponent();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}

/// <summary>
///     An object providing options for displaying the visual variable in the Legend.
/// </summary>
public class LegendOptions : MapComponent
{
    /// <summary>
    ///     Indicates whether to show the visual variable in the legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ShowLegend { get; set; }
    
    /// <summary>
    ///     The title describing the visualization of the visual variable in the Legend. This takes precedence over a field alias or valueExpressionTitle.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}

/// <summary>
///     A collection of <see cref="VisualVariable"/> Types
/// </summary>
[JsonConverter(typeof(VisualVariableTypeConverter))]
public enum VisualVariableType
{
#pragma warning disable CS1591
    Size,
    Rotation
#pragma warning restore CS1591
}

internal class VisualVariableTypeConverter : JsonConverter<VisualVariableType>
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

internal class VisualVariableConverter : JsonConverter<VisualVariable>
{
    public override VisualVariable? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as VisualVariable;
    }

    public override void Write(Utf8JsonWriter writer, VisualVariable value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}