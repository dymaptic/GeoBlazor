namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Raster statistics information returned that meets the specified ImageHistogramParameters from the computeStatisticsHistograms() method on ImageryLayer or ImageryTileLayer.
/// </summary>
/// <param name="Min">
///     Minimum value of the statistics.
/// </param>
/// <param name="Max">
///     Maximum value of the statistics.
/// </param>
/// <param name="Avg">
///     Average of the statistics.
/// </param>
/// <param name="Stddev">
///     Standard deviation of the statistics.
/// </param>
/// <param name="Count">
///     Count of the statistics.
/// </param>
/// <param name="Mode">
///     Mode value of the statistics.
/// </param>
/// <param name="Median">
///     Median value of the statistics.
/// </param>
/// <param name="Sum">
///     Sum of the statistics.
/// </param>
public record RasterBandStatistics(double Min, double Max, double Avg, double Stddev,
    int? Count, double? Mode, double? Median, double? Sum);