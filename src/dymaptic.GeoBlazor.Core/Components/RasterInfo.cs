using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Describes general raster data information exposed by the ArcGIS REST API for ImageryLayer, ImageryTileLayer and WCSLayer. RasterInfo contains information such band count, statistics, data type, dimensions and key properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AttributeTable">
///     The raster attribute table associated with an imagery layer. It returns categorical mapping of pixel values such as class, group, or category, or membership.
/// </param>
/// <param name="BandCount">
///     Raster band count.
/// </param>
/// <param name="BandInfos">
///     This property provides additional information for each band in the raster. Raster products will include information such as the color name, wavelength range, the radiance gain, radiance bias, and solar irradiance. All other raster datasets will only contain the band index value.
/// </param>
/// <param name="Colormap">
///     Raster colormap that can be used to display the imagery layer. Each element in the array defines the pixel value and the red, green, and blue color values.
/// </param>
/// <param name="DataType">
///     Raster data type controls how the data is rendered by default.
/// </param>
/// <param name="Extent">
///     The minimum and maximum X and Y coordinates of a bounding box containing all the raster data.
/// </param>
/// <param name="HasMultidimensionalTranspose">
///     Indicates whether the source multidimensional data has been transposed. This only applies to ImageryTileLayer that references multidimensional image service.
/// </param>
/// <param name="Height">
///     Raster height (row count) in pixels.
/// </param>
/// <param name="Histograms">
///     Raster histograms return basic name-value pairs for number of bins, min and max bounding values, counts of pixels in each bin.
/// </param>
/// <param name="KeyProperties">
///     Raster key properties.
/// </param>
/// <param name="MultidimensionalInfo">
///     Returns the multidimensional information associated with the raster service referenced in an imagery layer. If defined, it contains an information on variables and dimensions associated with the service. Multidimensional data is stored as variables where each variable is a multidimensional array represents data captured in multiple dimensions like times and depths/heights.
///     You can filter the multidimensional data with one or multiple dimensional slices by setting the mosaicRule.multidimensionalDefinition property on an ImageryLayer or by setting the multidimensionalDefinition property on an ImageryTileLayer or a WCSLayer.
/// </param>
/// <param name="NoDataValue">
///     The pixel value representing no available information. Can be a single number (same value for all bands) or array (specific value for each band).
/// </param>
/// <param name="PixelSize">
///     Raster pixel size. Specifies the pixel size being identified on the x and y axis. Defaults to the base resolution of the dataset when not specified.
/// </param>
/// <param name="PixelType">
///     Pixel type for the raster data source.
/// </param>
/// <param name="SensorInfo">
///     The sensor information associated with an image service referenced by a layer.
/// </param>
/// <param name="SpatialReference">
///     The spatial reference of the raster.
/// </param>
/// <param name="Statistics">
///     Raster band statistics. These include the minimum value in the raster, maximum value, mean of all values, and standard deviation.
/// </param>
/// <param name="Width">
///     Raster width (column count) in pixels.
/// </param>
public record RasterInfo(FeatureSet AttributeTable, int BandCount, RasterBandInfo[] BandInfos,
    double[][] Colormap, RasterDataType DataType, Extent Extent, bool HasMultidimensionalTranspose,
    double Height, Dictionary<string, object>[] Histograms, Dictionary<string, object> KeyProperties,
    RasterMultidimensionalInfo MultidimensionalInfo, double[] NoDataValue, PixelSize PixelSize,
    PixelType PixelType, RasterSensorInfo SensorInfo, SpatialReference SpatialReference,
    RasterStatistics[] Statistics, double Width);