namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Functions.EasingFunction.html">GeoBlazor Docs</a>
///     JavaScript function with the signature (t: number, duration: number) => number
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: t, duration.
/// </remarks>
public record EasingFunction(string JavaScriptFunction);

