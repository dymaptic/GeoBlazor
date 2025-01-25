namespace dymaptic.GeoBlazor.Core.Results;

[CodeGenerationIgnore]
public partial record FeatureEditResult;

/// <summary>
///     The error object in a <see cref="FeatureEditResult"/>
/// </summary>
/// <param name="Name">
///     Error name.
/// </param>
/// <param name="Message">
///     Message describing the error.
/// </param>
public record EditError(string? Name, string? Message);