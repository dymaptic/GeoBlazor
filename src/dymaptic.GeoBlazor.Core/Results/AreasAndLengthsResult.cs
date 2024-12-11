namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a computation request for areas and lengths for input polygons.
/// </summary>
/// <param name="Areas">
///     The areas of the input polygons.
/// </param>
/// <param name="Lengths">
///     The lengths of the input polygons.
/// </param>
public record AreasAndLengthsResult(IReadOnlyList<double> Areas, IReadOnlyList<double> Lengths);