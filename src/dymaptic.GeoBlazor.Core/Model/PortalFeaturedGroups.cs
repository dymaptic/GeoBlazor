namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.PortalFeaturedGroups.html">GeoBlazor Docs</a>
///     The featured groups for the portal.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#featuredGroups">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Owner">
///     Name of the group owner.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#featuredGroups">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Title">
///     Group title.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#featuredGroups">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public record PortalFeaturedGroups(string Owner, string Title);