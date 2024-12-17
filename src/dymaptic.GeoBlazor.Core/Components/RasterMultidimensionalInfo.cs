namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     RasterMultidimensionalInfo contains dimensions for each variable in the service describing information about the images collected at multiple times, depths, or heights.
/// </summary>
/// <param name="Variables">
///     The multi dimensional variables. It stores information such as name, unit and dimensions. For example, a temperature variable can store temperature data and the salinity variable can store the salinity data measured daily at different depths.
/// </param>
public record RasterMultidimensionalInfo(RasterMultidimensionalVariable[] Variables);