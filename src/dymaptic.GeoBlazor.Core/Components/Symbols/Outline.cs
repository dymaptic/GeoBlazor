using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

public class Outline : SimpleLineSymbol
{
    [JsonIgnore]
    public override string Type => string.Empty;
}