namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Geoblazor layer that contains sublayers
/// </summary>
public partial interface ISublayersLayer
{
    /// <summary>
    ///     The sublayers of this layer
    /// </summary>
    IReadOnlyList<Sublayer>? Sublayers { get; }
}