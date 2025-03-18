namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     The delegate for the GoToOverride function.
/// </summary>
[CodeGenerationIgnore]
public delegate Task GoToOverride(GoToOverrideParameters goToParameters);

/// <summary>
///     The parameters for the GoToOverride function.
/// </summary>
public record GoToJsParameters(GoToTarget Target, GoToOptions Options);

