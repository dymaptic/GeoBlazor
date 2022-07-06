using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Components.Geometries;
using dymaptic.Blazor.GIS.API.Core.Components.Symbols;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

public class Feature
{
    public Dictionary<string, object> Attributes { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? Symbol { get; set; }
}