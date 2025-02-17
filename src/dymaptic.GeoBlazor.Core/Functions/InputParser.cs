namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Value">
///    
/// </param>
/// <param name="Type">
///    
/// </param>
/// <param name="Index">
///    
/// </param>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string. Reference the other parameters with lowercase first letters inside the JS function. Function should return number value.
/// </param>
public record InputParser(string Value,
    InputParserType Type,
    int Index,
    string JavaScriptFunction);

