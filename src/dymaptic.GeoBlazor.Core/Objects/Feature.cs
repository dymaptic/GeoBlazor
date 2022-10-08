using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Symbols;

namespace dymaptic.GeoBlazor.Core.Objects;

public class Feature
{
    public Dictionary<string, object> Attributes { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? Symbol { get; set; }
}