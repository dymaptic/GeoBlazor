using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a computation request for histograms.
/// </summary>
/// <param name="Histograms">
///     Result containing raster histograms.
/// </param>
public record HistogramsResult(IReadOnlyList<RasterHistogram> Histograms);