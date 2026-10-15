namespace dymaptic.GeoBlazor.Pro.Results;

/// <summary>
///     Internal usage serialization record
/// </summary>
public record RouteResultWithoutGraphics(
    FeatureSet? DirectionLines,
    FeatureSet? DirectionPoints,
    DirectionsFeatureSet? Directions,
    string? RouteName,
    FeatureSet? TraversedEdges,
    FeatureSet? TraversedJunctions,
    FeatureSet? TraversedTurns,
    int Index);