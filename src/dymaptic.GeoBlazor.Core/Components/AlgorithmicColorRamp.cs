namespace dymaptic.GeoBlazor.Core.Components;

public partial class AlgorithmicColorRamp : ColorRamp
{

    /// <inheritdoc />
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    public override ColorRampType Type => ColorRampType.Algorithmic;

    /// <summary>
    ///     The algorithm used to generate the colors between the fromColor and toColor.
    /// </summary>
    [Parameter]
    public Algorithm Algorithm { get; set; }

    /// <summary>
    ///     The first color in the color ramp.
    /// </summary>
    [Parameter]
    public MapColor? FromColor { get; set; }

    /// <summary>
    ///     The last color in the color ramp.
    /// </summary>
    [Parameter]
    public MapColor? ToColor { get; set; }

}
