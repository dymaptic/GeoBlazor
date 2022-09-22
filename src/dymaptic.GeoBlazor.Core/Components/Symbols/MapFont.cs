using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public class MapFont : MapComponent
{
    [Parameter]
    public string? Size { get; set; }
    [Parameter]
    public string? Family { get; set; }
    [Parameter]
    [JsonPropertyName("style")]
    public string? FontStyle { get; set; }
    [Parameter]
    public string? Weight { get; set; }
}