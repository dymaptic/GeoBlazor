// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.RasterInfoDataType.html">GeoBlazor Docs</a>
///     Raster data type controls how the data is rendered by default.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#dataType">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RasterInfoDataType>))]
public enum RasterInfoDataType
{
#pragma warning disable CS1591
    Generic,
    Elevation,
    Thematic,
    Processed,
    Scientific,
    VectorUv,
    VectorU,
    VectorV,
    VectorMagdir,
    VectorMagnitude,
    VectorDirection,
    StandardTime
#pragma warning restore CS1591
}
