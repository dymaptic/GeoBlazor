namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IBasemapGalleryWidgetSource.html">GeoBlazor Docs</a>
///     The source for basemaps that the widget will display.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery.html#source">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
[JsonConverter(typeof(BasemapGallerySourceConverter))]
public interface IBasemapGalleryWidgetSource: IMapComponent
{
   
}