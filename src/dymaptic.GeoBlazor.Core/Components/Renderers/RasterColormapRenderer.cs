using dymaptic.GeoBlazor.Core.Components.Layers;
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
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterColormapRenderer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// 
public class RasterColormapRenderer : LayerObject
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterColormapRenderer() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterColormapRenderer(List<ColormapInfo>? colormapInfos = null) 
    {
#pragma warning disable BL0005
        ColormapInfos = colormapInfos;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The type of renderer.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type => "raster-colormap";

    /// <summary>
    ///    A colormap info array containing mappings for pixel and RGB color values.
    /// </summary>
    public List<ColormapInfo>? ColormapInfos { get; set; }

}
