using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Text symbols are used to define the graphic for displaying labels on a FeatureLayer, CSVLayer, Sublayer, and StreamLayer in a 2D MapView. Text symbols can also be used to define the symbol property of Graphic if the geometry type is Point or Multipoint. With this class, you may alter the color, font, halo, and other properties of the label graphic.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-TextSymbol.html">ArcGIS JS API</a>
/// </summary>
public class TextSymbol : Symbol
{
    /// <inheritdoc />
    public override string Type => "text";

    /// <summary>
    ///     The color of the text symbol's halo.
    /// </summary>
    [Parameter]
    public MapColor? HaloColor { get; set; }

    /// <summary>
    ///     The size in points of the text symbol's halo.
    /// </summary>
    [Parameter]
    public string? HaloSize { get; set; }

    /// <summary>
    ///     The <see cref="MapFont"/> used to style the text.
    /// </summary>
    public MapFont? Font { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MapFont mapFont:
                if (!((Object)mapFont).Equals(Font))
                {
                    Font = mapFont;
                    await UpdateComponent();
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
            case MapFont _:
                Font = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Font?.ValidateRequiredChildren();
    }
}