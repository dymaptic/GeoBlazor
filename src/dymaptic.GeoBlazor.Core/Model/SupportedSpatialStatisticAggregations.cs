namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     List of supported aggregated geometries returned for each distinct group when groupByFieldsForStatistics is used.
/// </summary>
/// <param name="Centroid">
///     Indicates if the layer can return centroid for each distinct group for groupByFieldsForStatistics.
/// </param>
/// <param name="Envelope">
///     Indicates if the layer can return extent for each distinct group for groupByFieldsForStatistics.
/// </param>
/// <param name="ConvexHull">
///     Indicates if the layer can return convex hull for each distinct group for groupByFieldsForStatistics.
/// </param>
public record SupportedSpatialStatisticAggregations(bool Centroid, bool Envelope, bool ConvexHull);