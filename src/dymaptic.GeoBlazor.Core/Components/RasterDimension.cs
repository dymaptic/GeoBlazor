namespace dymaptic.GeoBlazor.Core.Components;

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