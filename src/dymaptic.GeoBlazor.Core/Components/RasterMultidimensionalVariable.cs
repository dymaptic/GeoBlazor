namespace dymaptic.GeoBlazor.Core.Components;

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