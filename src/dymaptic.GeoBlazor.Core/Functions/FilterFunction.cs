namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="FilterName">
///    The name of the template item to filter.
/// </param>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string. Reference the other parameters with lowercase first letters inside the JS function. Function should return a boolean value.
/// </param>
public record FilterFunction(string FilterName,
    string JavaScriptFunction);

