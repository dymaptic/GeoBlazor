using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     A convenience sub-class of <see cref="SimpleLineSymbol"/> for defining outlines of other symbols.
/// </summary>
public class Outline : SimpleLineSymbol
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => string.Empty;
}