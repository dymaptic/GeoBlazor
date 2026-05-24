namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Result of the <see cref="GeometryEngine.RemovePointOnPolygon" /> method.
/// </summary>
/// <param name="Polygon">
///     The resulting <see cref="Polygon" /> after the point has been removed.
/// </param>
/// <param name="Point">
///     The point that was removed from the polygon.
/// </param>
[CodeGenerationIgnore]
public record RemovePointOnPolygonResult(Polygon Polygon, Point Point);