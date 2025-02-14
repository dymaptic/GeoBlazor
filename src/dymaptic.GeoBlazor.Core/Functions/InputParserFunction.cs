namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Function used to parse slider inputs formatted by the <see cref="SliderWidget.InputFormatFunction"/>.
/// </summary>
/// <param name="Value">
///     The formatted input value of the thumb to be parsed.
/// </param>
/// <param name="Type">
///     The label type.
/// </param>
/// <param name="Index">
///     The index of the thumb (or value).
/// </param>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string. Reference the other parameters with lowercase first letters inside the JS function. Function should return a number value.
/// </param>
public record InputParserFunction(string Value, SliderInputParserType? Type, int? Index, string JavaScriptFunction);