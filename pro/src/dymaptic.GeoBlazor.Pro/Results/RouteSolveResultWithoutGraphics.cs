namespace dymaptic.GeoBlazor.Pro.Results;

internal record RouteSolveResultWithoutGraphics(
    NAMessage[] Messages,
    RouteResultWithoutGraphics[] RouteResults);