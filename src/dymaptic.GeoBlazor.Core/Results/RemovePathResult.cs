namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Result of the <see cref="GeometryEngine.RemovePath" /> method.
/// </summary>
/// <param name="Polyline">
///     The resulting <see cref="Polyline" /> after the path has been removed.
/// </param>
/// <param name="Path">
///     The path that was removed from the polyline.
/// </param>
[CodeGenerationIgnore]
public record RemovePathResult(Polyline Polyline, Point[] Path);