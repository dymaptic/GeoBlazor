namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     A base class for barriers to restrict travel along a street network when using a RouteLayer.
/// </summary>
public abstract record Barrier
{
    /// <summary>
    ///     The type of barrier
    /// </summary>
    public abstract string Type { get; }
}