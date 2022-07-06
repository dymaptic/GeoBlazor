using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Components.Geometries;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

public class SelectResult
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Feature? Feature { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}