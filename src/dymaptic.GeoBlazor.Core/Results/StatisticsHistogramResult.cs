namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a computation for statistics and histograms for a given extent or polygon.
/// </summary>
/// <param name="Histograms">
///     Result containing raster histograms.
/// </param>
/// <param name="Statistics">
///     Raster band statistics.
/// </param>
public record StatisticsHistogramResult(IReadOnlyList<RasterHistogram> Histograms, 
    IReadOnlyList<RasterStatistics> Statistics);