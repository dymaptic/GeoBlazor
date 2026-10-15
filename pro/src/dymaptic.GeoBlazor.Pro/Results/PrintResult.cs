namespace dymaptic.GeoBlazor.Pro.Results;

/// <summary>
///     The result of a print operation.
/// </summary>
/// <param name="Url">URL to the exported printout.</param>
[CodeGenerationIgnore]
public record PrintResult(string Url);