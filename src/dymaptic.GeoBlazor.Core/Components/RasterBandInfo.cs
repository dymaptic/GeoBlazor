namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     RasterBandInfo class provides additional information for each raster band in an image service referenced by ImageryLayer or ImageryTileLayer. A band is represented by a single matrix of pixel values, and a raster with multiple bands contains multiple spatially coincident matrices of pixel values representing the same spatial area. Image services can include information such as the band name, band index value, wavelength range, the radiance gain, radiance bias, and solar irradiance. All other raster datasets will only contain the band index value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterBandInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MaxWavelength">
///     The maximum wavelength of the band.
/// </param>
/// <param name="MinWavelength">
///     The minimum wavelength of the band.
/// </param>
/// <param name="Name">
///     The name of the band.
/// </param>
/// <param name="RadianceBias">
///     The radiance bias of the band.
/// </param>
/// <param name="RadianceGain">
///     The radiance gain of the band.
/// </param>
/// <param name="ReflectanceBias">
///     The reflectance bias of the band.
/// </param>
/// <param name="ReflectanceGain">
///     The reflectance gain of the band.
/// </param>
/// <param name="SolarIrradiance">
///     The solar irradiance of the band.
/// </param>
public record RasterBandInfo(double MaxWavelength, double MinWavelength, string Name, double RadianceBias,
    double RadianceGain, double ReflectanceBias, double ReflectanceGain, double SolarIrradiance);