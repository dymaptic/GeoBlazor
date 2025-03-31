

namespace dymaptic.GeoBlazor.Core.Components;

public partial class MultipartColorRamp : ColorRamp, IMapComponent
{

    /// <inheritdoc />
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    public override ColorRampType Type => ColorRampType.Multipart;


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AlgorithmicColorRamp colorRamps:
                ColorRamps ??= [];
                if (!ColorRamps.Contains(colorRamps))
                {
                    ColorRamps = [..ColorRamps, colorRamps];
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
                ColorRamps = ColorRamps?.Except([colorRamps]).ToList();

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

}
