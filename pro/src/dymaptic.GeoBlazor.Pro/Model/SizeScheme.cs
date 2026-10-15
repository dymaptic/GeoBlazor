namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Properties defining the symbology scheme used to visualize features with attribute data-driven size.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-symbology-size.html#SizeScheme">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(SizeSchemeConverter))]
public abstract record SizeScheme;