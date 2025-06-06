// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Results.DeleteItemsResult.html">GeoBlazor Docs</a>
///     The result of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#deleteItems">`deleteItems()`</a> method containing the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html">item</a>, if deletion is successful, and error, if any.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#DeleteItemsResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Error">
///     The error if the item was not deleted.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#DeleteItemsResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Item">
///     An item from the `items` parameter of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#deleteItems">`deleteItems()`</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#DeleteItemsResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Success">
///     Indicates whether the item was successfully deleted.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalUser.html#DeleteItemsResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record DeleteItemsResult(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Error? Error = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    PortalItem? Item = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? Success = null);
