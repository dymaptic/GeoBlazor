namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Defines a suggested PopupTemplate with a given name and title describing the content and purpose of the PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-popup-templates.html#Template">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Name">
///     The name of the auto-generated PopupTemplate. This can be used in the UI of web map authoring apps.
/// </param>
/// <param name="Title">
///     The title of the PopupTemplate.
/// </param>
/// <param name="Value">
///     The suggested PopupTemplate.
/// </param>
public record PopupTemplateResult(string Name, string Title, PopupTemplate Value);