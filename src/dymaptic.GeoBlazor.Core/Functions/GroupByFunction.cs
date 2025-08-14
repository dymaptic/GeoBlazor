namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     The function used when setting the groupBy property. It is used to customize the grouping of template items. This can aid in managing various template items and how they display within the widget. This takes an object containing a template and a layer property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTemplates.html#GroupByFunction">GroupByFunction</a>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: grouping.
/// </remarks>
public record GroupByFunction(string JavaScriptFunction);

