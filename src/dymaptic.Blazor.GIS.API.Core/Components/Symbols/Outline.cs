using System.Text.Json.Serialization;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public class Outline : SimpleLineSymbol
{
    [JsonIgnore]
    public override string Type => string.Empty;
}