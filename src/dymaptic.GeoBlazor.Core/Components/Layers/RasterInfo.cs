using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

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

/// <summary>
///     RasterMultidimensionalInfo contains dimensions for each variable in the service describing information about the images collected at multiple times, depths, or heights.
/// </summary>
/// <param name="Variables">
///     The multi dimensional variables. It stores information such as name, unit and dimensions. For example, a temperature variable can store temperature data and the salinity variable can store the salinity data measured daily at different depths.
/// </param>
public record RasterMultidimensionalInfo(RasterMultidimensionalVariable[] Variables);

/// <summary>
///     The multi dimensional variables. It stores information such as name, unit and dimensions. For example, a temperature variable can store temperature data and the salinity variable can store the salinity data measured daily at different depths.
/// </summary>
/// <param name="Name">
///     Variable name.
/// </param>
/// <param name="Description">
///     Variable description.
/// </param>
/// <param name="Unit">
///     Unit of the variable measured in.
/// </param>
/// <param name="Dimensions">
///     A dimension may be used to represent real physical dimensions such as time or depth/height. It may also be used to represent more abstract quantities such as station id or station-time pair. For example, if your temperature data has a corresponding Date dimension field representing the day it was captured, and your salinity data has a Depth dimension field representing the depth at which it was measured, the Dimensions field for that variable would be Date and Depth.
/// </param>
/// <param name="Statistics">
///     Variable statistics.
/// </param>
/// <param name="Histograms">
///     Variable histograms.
/// </param>
public record RasterMultidimensionalVariable(
    string Name,
    string? Description,
    string? Unit,
    RasterDimension[] Dimensions,
    RasterBandStatistics[]? Statistics,
    RasterHistogram[]? Histograms);

/// <summary>
///     A dimension may be used to represent real physical dimensions such as time or depth/height. It may also be used to represent more abstract quantities such as station id or station-time pair. For example, if your temperature data has a corresponding Date dimension field representing the day it was captured, and your salinity data has a Depth dimension field representing the depth at which it was measured, the Dimensions field for that variable would be Date and Depth.
/// </summary>
/// <param name="Name">
///     Dimension name.
/// </param>
/// <param name="Description">
///     Dimension description.
/// </param>
/// <param name="Unit">
///     Dimension unit.
/// </param>
/// <param name="Values">
///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
/// </param>
/// <param name="HasRegularIntervals">
///     Indicates if the dimension is recorded at regular intervals.
/// </param>
/// <param name="Interval">
///     Dimension interval.
/// </param>
/// <param name="IntervalUnit">
///     Dimension interval unit.
/// </param>
/// <param name="Extent">
///     The extent of dimension values.
/// </param>
public record RasterDimension(
    string Name,
    string? Description,
    string? Unit,
    object[]? Values,
    bool? HasRegularIntervals,
    double? Interval,
    string? IntervalUnit,
    double[]? Extent);
    
/// <summary>
///     Raster pixel size.
/// </summary>
/// <param name="X">
///     Pixel size along the X axis.
/// </param>
/// <param name="Y">
///     Pixel size along the Y axis.
/// </param>
public record PixelSize(double X, double Y);

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

/// <summary>
///     Raster statistics information returned that meets the specified ImageHistogramParameters from the computeStatisticsHistograms() method on ImageryLayer or ImageryTileLayer.
/// </summary>
/// <param name="Min">
///     Minimum value of the statistics.
/// </param>
/// <param name="Max">
///     Maximum value of the statistics.
/// </param>
/// <param name="Avg">
///     Average of the statistics.
/// </param>
/// <param name="Stddev">
///     Standard deviation of the statistics.
/// </param>
/// <param name="Count">
///     Count of the statistics.
/// </param>
/// <param name="Mode">
///     Mode value of the statistics.
/// </param>
/// <param name="Median">
///     Median value of the statistics.
/// </param>
/// <param name="Sum">
///     Sum of the statistics.
/// </param>
public record RasterBandStatistics(double Min, double Max, double Avg, double Stddev,
    int? Count, double? Mode, double? Median, double? Sum);

/// <summary>
///     Raster histogram information returned that meets the specified ImageHistogramParameters from the computeHistograms() or computeStatisticsHistograms() method.
/// </summary>
/// <param name="Size">
///     Number of bins.
/// </param>
/// <param name="Min">
///     The minimum pixel value of the histogram. Matches the minimum bound of the first bin.
/// </param>
/// <param name="Max">
///     The maximum pixel value of the histogram. Matches the maximum bound of the last bin.
/// </param>
/// <param name="Counts">
///     Count of pixels that fall into each bin.
/// </param>
public record RasterHistogram(int Size, double Min, double Max, int[] Counts);