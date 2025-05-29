namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Callback for formatting tick labels on a SliderWidget.
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: value, type, index.
/// </remarks>
public record SliderLabelFormatter(string JavaScriptFunction);

