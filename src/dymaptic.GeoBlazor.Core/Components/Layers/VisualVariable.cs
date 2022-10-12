using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The visual variable base class. See each of the subclasses that extend this class to learn how to create continuous data-driven thematic visualizations.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">ArcGIS JS API</a>
/// </summary>
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
}

/// <summary>
///     A collection of <see cref="VisualVariable"/> Types
/// </summary>
[JsonConverter(typeof(VisualVariableTypeConverter))]
public enum VisualVariableType
{
    /// <summary>
    ///     The Size Variable type marker
    /// </summary>
    Size
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