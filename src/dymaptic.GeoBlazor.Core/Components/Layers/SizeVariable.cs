using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The size visual variable defines the size of individual features in a layer based on a numeric (often thematic) value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html">ArcGIS JS API</a>
/// </summary>
public class SizeVariable : VisualVariable
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override VisualVariableType VariableType => VisualVariableType.Size;
    
    /// <summary>
    ///     The minimum data value used in the size ramp.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinDataValue { get; set; }

    /// <summary>
    ///     The maximum data value used in the size ramp.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxDataValue { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the minimum data value
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinSize { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the maximum data value
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxSize { get; set; }
}