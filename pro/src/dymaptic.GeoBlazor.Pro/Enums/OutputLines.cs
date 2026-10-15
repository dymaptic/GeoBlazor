namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The type of route that is output by the <see cref="RouteService.Solve" /> method.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<OutputLines>))]
[CodeGenerationIgnore]
public enum OutputLines
{
    /// <summary>
    ///     Do not return any shapes for the routes.
    /// </summary>
    None,
    /// <summary>
    ///     Return a straight line between the stops.
    /// </summary>
    Straight,
    /// <summary>
    ///     Return the exact shape of the resulting route that is based on the underlying streets.
    /// </summary>
    TrueShape,
    /// <summary>
    ///     Return the exact shape of the resulting route that is based on the underlying streets and include route measurements that keep track of the cumulative travel time or travel distance along the route relative to the first stop.
    /// </summary>
    TrueShapeWithMeasure
}