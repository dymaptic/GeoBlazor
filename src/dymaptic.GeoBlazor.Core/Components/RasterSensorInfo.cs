namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The RasterSensorInfo class provides additional information on the raster sensor associated with an image service referenced by ImageryLayer or ImageryTileLayer. This information includes sensor name, product name, imagery acquisition date, cloud coverage, sun and sensor elevation and azimuth angle.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AcquisitionDate">
///     The acquisition date.
/// </param>
/// <param name="CloudCover">
///     The cloud coverage (0-1).
/// </param>
/// <param name="ProductName">
///     The satellite product name.
/// </param>
/// <param name="SensorAzimuth">
///     The sensor azimuth.
/// </param>
/// <param name="SensorElevation">
///     The sensor elevation.
/// </param>
/// <param name="SensorName">
///     The sensor name.
/// </param>
/// <param name="SunAzimuth">
///     The sun azimuth.
/// </param>
/// <param name="SunElevation">
///     The sun elevation.
/// </param>
public record RasterSensorInfo(DateOnly AcquisitionDate, double CloudCover, string ProductName,
    double SensorAzimuth, double SensorElevation, string SensorName, double SunAzimuth, double SunElevation);