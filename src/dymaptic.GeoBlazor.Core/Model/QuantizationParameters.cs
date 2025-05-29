namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Used to project the geometry onto a virtual grid, likely representing pixels on the screen. Geometry coordinates are converted to integers by building a grid with a resolution matching the quantizationParameters.tolerance. Each coordinate is then snapped to one pixel on the grid.
/// </summary>
public record QuantizationParameters
{
    /// <summary>
    ///     An extent defining the quantization grid bounds. Its SpatialReference matches the input geometry spatial reference if one is specified for the query. Otherwise, the extent will be in the layer's spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; init; }

    /// <summary>
    ///     Geometry coordinates are optimized for viewing and displaying of data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QuantizationMode? Mode { get; init; }

    /// <summary>
    ///     The integer's coordinates will be returned relative to the origin position defined by this property value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OriginPosition? OriginPosition { get; init; }

    /// <summary>
    ///     The size of one pixel in the units of the outSpatialReference. This number is used to convert coordinates to integers by building a grid with a resolution matching the tolerance. Each coordinate is then snapped to one pixel on the grid. Consecutive coordinates snapped to the same pixel are removed for reducing the overall response size.
    ///     The units of tolerance will match the units of outSpatialReference. If outSpatialReference is not specified, then
    ///     tolerance is assumed to be in the units of the spatial reference of the layer. If tolerance is not specified, the
    ///     maxAllowableOffset is used. If tolerance and maxAllowableOffset are not specified, a grid of 10,000 * 10,000 grid
    ///     is used by default.
    ///     Default Value: 1
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Tolerance { get; init; }
}