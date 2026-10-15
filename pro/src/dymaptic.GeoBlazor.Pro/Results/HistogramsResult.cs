namespace dymaptic.GeoBlazor.Pro.Results;

/// <summary>
///     Represents the result of a computation request for histograms.
/// </summary>
/// <param name="Histograms">
///     Result containing raster histograms.
/// </param>
public record HistogramsResult(IReadOnlyList<RasterHistogram> Histograms);