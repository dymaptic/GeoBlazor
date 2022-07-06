using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components;

public class Attributes : MapComponent
{
    [Parameter]
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [Parameter]
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}