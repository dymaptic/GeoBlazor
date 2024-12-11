using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a query for an extent.
/// </summary>
/// <param name="Count">
///     The number of features that satisfy the input query.
/// </param>
/// <param name="Extent">
///     The extent of the features that satisfy the input query.
/// </param>
public record ExtentQueryResult(int Count, Extent? Extent);