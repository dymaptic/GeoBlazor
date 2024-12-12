using dymaptic.GeoBlazor.Pro.Model;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     The return object of the <see cref="PopupTemplateCreator.GetTemplates"/> or <see cref="PopupTemplateCreator.GetClusterTemplates"/> method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-popup-templates.html#Templates">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="PrimaryTemplate">
///     Includes the primary PopupTemplate suggested for the input layer.
/// </param>
/// <param name="SecondaryTemplates">
///     Includes secondary PopupTemplates that may be applied to the input layer.
/// </param>
public record PopupTemplateResults(PopupTemplateResult PrimaryTemplate, IReadOnlyCollection<PopupTemplateResult> SecondaryTemplates);