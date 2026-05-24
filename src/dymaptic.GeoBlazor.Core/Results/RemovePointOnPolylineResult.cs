namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Result of the <see cref="GeometryEngine.RemovePointOnPolyline" /> method.
/// </summary>
/// <param name="Polyline">
///     The resulting <see cref="Polyline" /> after the point has been removed.
/// </param>
/// <param name="Point">
///     The point that was removed from the polyline.
/// </param>
[CodeGenerationIgnore]
public record RemovePointOnPolylineResult(Polyline Polyline, Point Point);