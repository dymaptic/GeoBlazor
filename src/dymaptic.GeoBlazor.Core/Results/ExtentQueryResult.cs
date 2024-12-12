using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     The return type for <see cref="FeatureLayer.QueryExtent" />.
/// </summary>
/// <param name="Count">
///     The number of features that satisfy the input query.
/// </param>
/// <param name="Extent">
///     The extent of features that satisfy the query.
/// </param>
public record ExtentQueryResult(int Count, Extent Extent);