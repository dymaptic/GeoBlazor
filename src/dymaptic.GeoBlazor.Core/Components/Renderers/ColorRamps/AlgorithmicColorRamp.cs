namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     Creates a color ramp for use in a raster renderer. The algorithmic color ramp is defined by specifying two colors and the
///     algorithm used to traverse the intervening color spaces.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AlgorithmicColorRamp.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class AlgorithmicColorRamp : ColorRamp
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public AlgorithmicColorRamp() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public AlgorithmicColorRamp(Algorithm algorithm, MapColor? fromColor = null, MapColor? toColor = null)
    {
#pragma warning disable BL0005
        Algorithm = algorithm;
        FromColor = fromColor;
        ToColor = toColor;
#pragma warning restore BL0005
    }
    /// <inheritdoc />
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    [JsonPropertyName("type")]
    public override ColorRampType ColorRampType => ColorRampType.Algorithmic;

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
