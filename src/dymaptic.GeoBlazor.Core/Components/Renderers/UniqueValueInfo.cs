using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Defines the symbols to use in a UniqueValueRenderer. Each unique value info defines a symbol that should be used to
///     represent features with a specific value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-UniqueValueInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class UniqueValueInfo : LayerObject
{
    /// <summary>
    ///     Features with this value will be rendered with the given symbol.
    /// </summary>
    [JsonPropertyName("value")]
    [Parameter]
    public string? Value { get; set; }

    /// <summary>
    ///     Describes the value represented by the symbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
}