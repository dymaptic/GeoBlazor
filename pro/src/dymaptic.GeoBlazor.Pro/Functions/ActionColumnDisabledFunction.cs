namespace dymaptic.GeoBlazor.Pro.Functions;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Functions.ActionColumnDisabledFunction.html">GeoBlazor Docs</a>
///     Indicates if the action should appear disabled.
///     default null
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTable-ActionColumn.html#disabled">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: parameters.
/// </remarks>
public record ActionColumnDisabledFunction(string JavaScriptFunction);

