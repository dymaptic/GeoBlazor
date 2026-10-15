namespace dymaptic.GeoBlazor.Pro.Functions;

/// <summary>
///    <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Functions.PopupTemplateContentDestroyer.html">GeoBlazor Docs</a>
///    A delegate to destroy the content of a popup template.
/// </summary>
/// <param name="destroyerEvent">
///     The event that contains the graphic feature that was clicked on to trigger the popup.
/// </param>
public delegate Task PopupTemplateContentDestroyer(PopupTemplateCreatorEvent destroyerEvent);

