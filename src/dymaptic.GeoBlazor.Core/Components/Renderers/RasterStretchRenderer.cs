using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;
using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     RasterStretchRenderer defines the symbology with a gradual ramp of colors for each pixel in a ImageryLayer, ImageryTileLayer,
///     and WCSLayer based on the pixel value. The RasterStretchRenderer works well when you have a large range of values to display,
///     such as in imagery, aerial photographs, or elevation models. Important to note that RasterStretchRenderer does not inherit from
///     Renderer class.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterStretchRenderer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// 
public class RasterStretchRenderer : LayerObject
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterStretchRenderer() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public RasterStretchRenderer(MultipartColorRamp? colorRamp = null, bool? computeGamma = null, bool? dynamicRangeAdjustment = null, List<int>? gamma = null, int? outputMax = null, int? outputMin = null,
        StretchType? stretchType = null, List<List<int>>? statistics = null, bool? useGamma = null, int? numberOfStandardDeviations = null)
    {
#pragma warning disable BL0005
        ColorRamp = colorRamp;
        ComputeGamma = computeGamma;
        DynamicRangeAdjustment = dynamicRangeAdjustment;
        Gamma = gamma;
        OutputMax = outputMax;
        OutputMin = outputMin;
        StretchType = stretchType;
        Statistics = statistics;
        UseGamma = useGamma;
        NumberOfStandardDeviations = numberOfStandardDeviations;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public string Type => "raster-stretch";

    /// <summary>
    ///     The stretched values are mapped to this specified color ramp.
    /// </summary>
    public MultipartColorRamp? ColorRamp { get; private set; }

    /// <summary>
    ///     The computeGamma automatically calculates best gamma value to render exported image based on empirical model. This is applicable to any stretch type when useGamma is true.
    /// </summary>
    [Parameter]
    public bool? ComputeGamma { get; set; }

    /// <summary>
    ///    When Dynamic Range Adjustment is true, the statistics based on the current display extent are calculated as you zoom and pan around the image. This property only applies
    ///    to images in 2D MapView.
    /// </summary>
    [Parameter]
    public bool? DynamicRangeAdjustment { get; set; } = false;

    /// <summary>
    ///     The gamma values to be used if useGamma is set to true. Gamma refers to the degree of contrast between the mid-level gray values of a raster dataset. Gamma does not
    ///     affect the black or white values in a raster dataset, only the middle values. By applying a gamma correction, you can control the overall brightness of a layer. 
    ///     Gamma stretching is only valid with the none, standard-deviation, and min-max stretch
    /// </summary>
    [Parameter]
    public List<int>? Gamma { get; set; }

    /// <summary>
    ///     The outputMax denotes the output maximum, which is the highest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast
    ///     stretched. The outputMax value ranges from 0-255.
    /// </summary>
    [Parameter]
    public int? OutputMax { get;  set; }

    /// <summary>
    ///     The outputMin denotes the output minimum, which is the lowest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast
    ///     stretched. The outputMin value ranges from 0-255.
    /// </summary>
    [Parameter]
    public int? OutputMin { get;  set; }

    /// <summary>
    ///     The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the
    ///     pixel values along a histogram from the minimum and maximum values defined by their bit depth.
    /// </summary>
    [Parameter]
    public StretchType? StretchType { get; set; }

    /// <summary>
    ///     The input statistics can be specified through the statistics property.
    /// </summary>
    [Parameter]
    public List<List<int>>? Statistics { get;  set; }

    /// <summary>
    ///     Denotes whether the gamma value should be used.
    /// </summary>
    [Parameter]
    public bool? UseGamma { get; set; }

    /// <summary>
    ///     Applicable when stretchType is standard-deviation. Specifies the number of standard deviations to use. The values beyond the number of standard deviations become the outputMin
    ///     and outputMax. The remaining values are linearly stretched between outputMin and outputMax.
    /// </summary>
    [Parameter]
    public int? NumberOfStandardDeviations { get; set; }

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

/// <summary>
/// The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the
/// pixel values along a histogram from the minimum and maximum values defined by their bit depth. 
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StretchType>))]
public enum StretchType
{
#pragma warning disable CS1591
    None,
    StandardDeviation,
    HistogramEqualization,
    MinMax,
    PercentClip,
    Sigmoid
#pragma warning restore CS1591
}

