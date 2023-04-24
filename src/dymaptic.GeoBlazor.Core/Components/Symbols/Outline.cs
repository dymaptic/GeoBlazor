using dymaptic.GeoBlazor.Core.Objects;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     A convenience sub-class of <see cref="SimpleLineSymbol" /> for defining outlines of other symbols.
/// </summary>
public class Outline : SimpleLineSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public Outline()
    {
    }

    /// <summary>
    ///     Constructs a new Outline in code with parameters
    /// </summary>
    /// <param name="color">
    ///     The color of the outline.
    /// </param>
    /// <param name="width">
    ///     The width of the outline in points.
    /// </param>
    /// <param name="lineStyle">
    ///     The style of the outline.
    /// </param>
    public Outline(MapColor? color = null, double? width = null, LineStyle? lineStyle = null)
        : base(color, width, lineStyle)
    {
        AllowRender = false;
    }
}