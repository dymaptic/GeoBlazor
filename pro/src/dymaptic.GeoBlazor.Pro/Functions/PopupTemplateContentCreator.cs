namespace dymaptic.GeoBlazor.Pro.Functions;
/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Functions.PopupTemplateContentCreator.html">GeoBlazor Docs</a>
///     Creates custom content for a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-PopupTemplate.html">PopupTemplate</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-CustomContent.html#PopupTemplateContent">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="creatorEvent">
///     The event that contains the feature that was clicked to open the popup.
/// </param>
public delegate Task<string> PopupTemplateContentCreator(PopupTemplateCreatorEvent creatorEvent);

