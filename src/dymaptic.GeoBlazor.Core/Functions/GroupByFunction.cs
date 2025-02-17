namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Grouping">
///    
/// </param>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string. Reference the other parameters with lowercase first letters inside the JS function. Function should return string | any value.
/// </param>
public record GroupByFunction(string Grouping,
    string JavaScriptFunction);

