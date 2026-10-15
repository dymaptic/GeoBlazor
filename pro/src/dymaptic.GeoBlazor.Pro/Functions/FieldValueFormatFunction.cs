namespace dymaptic.GeoBlazor.Pro.Functions;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Functions.FieldValueFormatFunction.html">GeoBlazor Docs</a>
///     Custom function for rendering cell content that is called when the column is rendered in the table.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTable-FieldColumn.html#formatFunction">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: parameters.
/// </remarks>
public record FieldValueFormatFunction(string JavaScriptFunction);

