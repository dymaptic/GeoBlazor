using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     RasterStretchRenderer defines the symbology with a gradual ramp of colors for each pixel in a ImageryLayer, ImageryTileLayer,
///     and WCSLayer based on the pixel value. The RasterStretchRenderer works well when you have a large range of values to display,
///     such as in imagery, aerial photographs, or elevation models. Important to note that RasterStretchRenderer does not inherit from
///     Renderer class.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterShadedReliefRenderer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// 
public class RasterShadedReliefRenderer : LayerObject
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterShadedReliefRenderer() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterShadedReliefRenderer(MultipartColorRamp? colorRamp= null, int? azimuth = null, int? altitude = null, string? hillshadeType = null, 
        int? pixelSizeFactor = null, int? pixelSizePower = null, string? scalingType = null, int? zFactor = null)
    {
#pragma warning disable BL0005
        Altitude = altitude;
        Azimuth = azimuth;
        ColorRamp = colorRamp;
        HillshadeType = hillshadeType;
        PixelSizeFactor = pixelSizeFactor;
        PixelSizePower = pixelSizePower;
        ScalingType = scalingType;
        ZFactor = zFactor;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The type of renderer.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type => "raster-shaded-relief";

    /// <summary>
    ///     The sun's angle of elevation above the horizon, ranging from 0 to 90 degrees.
    /// </summary>
    public int? Altitude { get; set; }

    /// <summary>
    ///     The sun's relative position along the horizon, ranging from 0 to 360 degrees.
    /// </summary>
    public int? Azimuth { get; set; }

    /// <summary>
    ///     The color ramp to display the shaded relief.
    /// </summary>
    public MultipartColorRamp? ColorRamp { get; private set; }

    /// <summary>
    ///     The type of hillshading being applied on the elevation surface.
    /// </summary>
    public string? HillshadeType { get; set; }

    /// <summary>
    ///     Pixel size factor accounts for changes in scale as the viewer zooms in and out on the map display.
    /// </summary>
    public int? PixelSizeFactor { get; set; }

    /// <summary>
    ///     Pixel Size Power accounts for the altitude changes (or scale) as the viewer zooms in and out on the map display.
    /// </summary>
    public int? PixelSizePower { get; set; }

    /// <summary>
    ///     Applies a constant or adjusted z-factor based on resolution changes.
    /// </summary>
    public string? ScalingType { get; set; }

    /// <summary>
    ///     A ratio of z unit / xy unit, with optional exaggeration factored in.
    /// </summary>
    public int? ZFactor { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MultipartColorRamp colorRamp:
                if (!colorRamp.Equals(ColorRamp))
                {
                    ColorRamp = colorRamp;
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
            case MultipartColorRamp _:
                ColorRamp = null;
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        ColorRamp?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }

}
