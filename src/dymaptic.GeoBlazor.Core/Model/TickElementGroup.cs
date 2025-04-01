namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The HTML Element nodes representing a single slider tick and its associated label.
/// </summary>
/// <param name = "TickElement">
///     The HTMLElement representing a tick. You can add or modify the style of a tick by adding CSS classes to this element. You can also attach event listeners to this element.
/// </param>
/// <param name = "LabelElement">
///     The HTMLElement representing the label associated with the tick element. You can add or modify the style of a tick label by adding CSS classes to this element. You can also attach event listeners to this element.
/// </param>
public record TickElementGroup(ElementReference? TickElement, ElementReference? LabelElement);
