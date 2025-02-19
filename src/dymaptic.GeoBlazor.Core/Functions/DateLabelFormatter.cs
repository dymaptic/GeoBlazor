namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     This function is used by the labelFormatFunction property to specify custom formatting and styling of the min, max and extent labels of the time slider widget.
/// </summary>/// <param name="value">
///    The date(s) that correspond to labels. When the label type is min or max a single date value will be parsed. When the type is extent value will be a date array with two values. The first and second date in the array correspond the time extent's start and end values.
/// </param>
/// <param name="type">
///    The label type that you want to format.
/// </param>
/// <param name="element">
///    The HTML element corresponding to the label type. You can add or modify the default style of individual labels by adding CSS classes to this element. You can also add custom behavior to labels by attaching event listeners to individual elements.
/// </param>
/// <param name="layout">
///    The TimeSlider layout.
/// </param>
public delegate Task DateLabelFormatter(DateTime value,
    DateLabelFormatterType type,
    ElementReference element,
    DateLabelFormatterLayout layout);

