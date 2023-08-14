using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Objects;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     The ColormapInfo describes pixel value, RGB colors and labels to color the raster. It is used with RasterColormapRenderer to color pixels in ImageryLayer and ImageryTileLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-ColormapInfo.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// 
public class ColormapInfo : LayerObject
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public ColormapInfo() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public ColormapInfo(MapColor? color = null, string? label = null, int? value = null) 
    {
#pragma warning disable BL0005
        Color = color;
        Label = label;
        Value = value;
#pragma warning restore BL0005
    }

    /// <summary>
    ///    The color of a given pixel.
    /// </summary>
    public MapColor? Color { get; set; }

    /// <summary>
    ///    The label for a given pixel value and color mapping.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    ///    The raster pixel value.
    /// </summary>
    public int? Value { get; set; }
}
