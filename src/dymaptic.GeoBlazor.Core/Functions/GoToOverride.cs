namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     This function provides the ability to override a goTo() method with your own implementation.
/// </summary>
[CodeGenerationIgnore]
public delegate Task GoToOverride(GoToOverrideParameters goToOverrideParams);

