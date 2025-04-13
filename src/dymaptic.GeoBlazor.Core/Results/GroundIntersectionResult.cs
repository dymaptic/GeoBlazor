namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Ground intersection result, only applies to SceneViews. The ground hit result will always be returned, even if the ground was excluded from the hitTest.
/// </summary>
public record GroundIntersectionResult(Point MapPoint, double Distance);