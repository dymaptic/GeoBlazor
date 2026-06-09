namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Result of the <see cref="GeometryEngine.RemoveRing" /> method.
/// </summary>
/// <param name="Polygon">
///     The resulting <see cref="Polygon" /> after the ring has been removed.
/// </param>
/// <param name="Ring">
///    The ring that was removed from the polygon.
/// </param>
[CodeGenerationIgnore]
public record RemoveRingResult(Polygon Polygon, Point[] Ring);