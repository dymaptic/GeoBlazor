namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///      Contains summary statistics about the data represented by the renderer.
/// </summary>
/// <param name = "Max">
///     The maximum data value of the attribute represented by the renderer. Legends displaying above-and-below themed data will not display values greater than this number.
/// </param>
/// <param name = "Min">
///     The minimum data value of the attribute represented by the renderer. Legends displaying above-and-below themed data will not display values smaller than this number.
/// </param>
public record AuthoringInfoStatistics(double Max, double Min);
