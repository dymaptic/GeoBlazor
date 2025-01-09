namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Describes the class breaks generated for an <see cref="AuthoringInfoField"/>
/// </summary>
/// <param name="MaxValue">
///     The maximum bound of values to visualize in the given field. If a feature's value is greater than this value, then it will be assigned the default symbol of the renderer.
/// </param>
/// <param name="MinValue">
///     The minimum bound of values to visualize in the given field. If a feature's value is less than this value, then it will be assigned the default symbol of the renderer.
/// </param>
public record ClassBreakInfo(double MaxValue, double MinValue);