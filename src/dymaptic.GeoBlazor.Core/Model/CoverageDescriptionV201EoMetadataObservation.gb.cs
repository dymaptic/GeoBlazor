// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.CoverageDescriptionV201EoMetadataObservation.html">GeoBlazor Docs</a>
///     Earth observation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AcquisitionType">
///     Earth observation acquisition type.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Footprint">
///     Earth observation footprint.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Identifier">
///     Earth observation identifier.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="PhenomenonTime">
///     Earth observation phenomenon time.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ResultTime">
///     Earth observation resultTime.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Status">
///     Earth observation status.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageDescriptionV201">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record CoverageDescriptionV201EoMetadataObservation(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? AcquisitionType = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Polygon? Footprint = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Identifier = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    TemporalDomain? PhenomenonTime = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    TemporalDomain? ResultTime = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Status = null);
