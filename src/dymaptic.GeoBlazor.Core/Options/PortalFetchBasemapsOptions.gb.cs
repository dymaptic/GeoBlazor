// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///    
/// </summary>
/// <param name="Include3d">
///     When `true` the basemaps based on <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#basemapGalleryGroupQuery3D">basemapGalleryGroupQuery3D</a> are also fetched, if no `basemapGalleryGroupQuery` is passed as an argument.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#fetchBasemaps">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Signal">
///     Signal object that can be used to abort the asynchronous task.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#fetchBasemaps">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record PortalFetchBasemapsOptions(
    bool? Include3d = null)
{
    /// <summary>
    ///     When `true` the basemaps based on <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#basemapGalleryGroupQuery3D">basemapGalleryGroupQuery3D</a> are also fetched, if no `basemapGalleryGroupQuery` is passed as an argument.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#fetchBasemaps">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public bool? Include3d { get; set; } = Include3d;
    
}

