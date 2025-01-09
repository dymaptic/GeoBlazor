namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A convenience method for pulling navigation directions from a Graphic in a RouteResult
/// </summary>
public record Direction
{
    /// <summary>
    ///     The navigation directions in human readable text.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    ///     The distance of the current leg of directions.
    /// </summary>
    public double Length { get; set; }
}