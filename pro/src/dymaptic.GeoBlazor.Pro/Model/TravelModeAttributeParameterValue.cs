namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Lists the parameterized attributes used by the travel mode.
/// </summary>
/// <param name="AttributeName">
///     The name of the attribute.
/// </param>
/// <param name="ParameterName">
///     The parameter name.
/// </param>
/// <param name="Value">
///     The parameter value.
/// </param>
public record TravelModeAttributeParameterValue(string AttributeName, string ParameterName, string Value);