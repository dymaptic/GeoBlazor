namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Function can be defined to help filter template items within the widget. A custom function can be used to aid when searching for templates. It takes a function which passes in an object containing a name property of the template item.
///     The function should take in a single parameter, `filterName`, and return a boolean value.
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: filterName.
/// </remarks>
public record FilterFunction(string JavaScriptFunction);

