namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IVersionAdapterVersionableItem.html">GeoBlazor Docs</a>
///     Contains items with the `gdbVersion` property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-versionManagement-VersionManagementService.html#VersionAdapter">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IVersionAdapterVersionableItem>))]
[CodeGenerationIgnore]
public interface IVersionAdapterVersionableItem
{
   // Add custom code to this file to override generated code
}
