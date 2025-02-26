namespace dymaptic.GeoBlazor.Core.Functions;/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: coordinate.
/// </remarks>
public record ReverseConvertFunction(string JavaScriptFunction);

