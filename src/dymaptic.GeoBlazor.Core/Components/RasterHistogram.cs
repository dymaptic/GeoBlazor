namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Raster histogram information returned that meets the specified ImageHistogramParameters from the computeHistograms() or computeStatisticsHistograms() method.
/// </summary>
/// <param name="Size">
///     Number of bins.
/// </param>
/// <param name="Min">
///     The minimum pixel value of the histogram. Matches the minimum bound of the first bin.
/// </param>
/// <param name="Max">
///     The maximum pixel value of the histogram. Matches the maximum bound of the last bin.
/// </param>
/// <param name="Counts">
///     Count of pixels that fall into each bin.
/// </param>
public record RasterHistogram(int Size, double Min, double Max, int[] Counts);