using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     Creates a color ramp for use in a raster renderer. The algorithmic color ramp is defined by specifying two colors and the
///     algorithm used to traverse the intervening color spaces.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MultipartColorRamp.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class MultipartColorRamp : ColorRamp
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public MultipartColorRamp() { }

    public MultipartColorRamp(List<AlgorithmicColorRamp>? colorRamps)
    {
        ColorRamps = colorRamps;
    }
    /// <inheritdoc />
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    public override ColorRampType ColorRampType => ColorRampType.Multipart;

    /// <summary>
    ///     Define an array of algorithmic color ramps used to generate the multi part ramp.
    /// </summary>
    public List<AlgorithmicColorRamp>? ColorRamps { get; private set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AlgorithmicColorRamp colorRamps:
                ColorRamps ??= new List<AlgorithmicColorRamp>();
                if (!ColorRamps.Contains(colorRamps))
                {
                    ColorRamps.Add(colorRamps);
                }
                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AlgorithmicColorRamp colorRamps:
                ColorRamps?.Remove(colorRamps);

                if (ColorRamps is not null && !ColorRamps.Any())
                {
                    ColorRamps = null;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        if (ColorRamps is not null)
        {
            foreach (AlgorithmicColorRamp colorRamp in ColorRamps)
            {
                colorRamp.ValidateRequiredChildren();
            }
        }
    }
}
