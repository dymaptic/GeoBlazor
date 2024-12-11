namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a request for printing the current MapView.
/// </summary>
/// <param name="Url">
///     The URL to the exported MapView.
/// </param>
public record PrintResult(string Url);