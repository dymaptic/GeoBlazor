namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     RasterStretchRenderer defines the symbology with a gradual ramp of colors for each pixel in a ImageryLayer, ImageryTileLayer,
///     and WCSLayer based on the pixel value. The RasterStretchRenderer works well when you have a large range of values to display,
///     such as in imagery, aerial photographs, or elevation models. Important to note that RasterStretchRenderer does not inherit from
///     Renderer class.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterStretchRenderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// 
public class RasterStretchRenderer : MapComponent, IImageryRenderer
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RasterStretchRenderer() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="colorRamp">
    ///     The stretched values are mapped to this specified color ramp.
    /// </param>
    /// <param name="computeGamma">
    ///     The computeGamma automatically calculates best gamma value to render exported image based on empirical model. This is applicable to any stretch type when useGamma is true.
    /// </param>
    /// <param name="dynamicRangeAdjustment">
    ///     When Dynamic Range Adjustment is true, the statistics based on the current display extent are calculated as you zoom and pan around the image. This property only applies
    /// </param>
    /// <param name="gamma">
    ///     The gamma values to be used if useGamma is set to true. Gamma refers to the degree of contrast between the mid-level gray values of a raster dataset. Gamma does not
    /// </param>
    /// <param name="outputMax">
    ///     The outputMax denotes the output maximum, which is the highest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast
    /// </param>
    /// <param name="outputMin">
    ///     The outputMin denotes the output minimum, which is the lowest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast
    /// </param>
    /// <param name="stretchType">
    ///     The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the
    /// </param>
    /// <param name="statistics">
    ///     The input statistics can be specified through the statistics property.
    /// </param>
    /// <param name="useGamma">
    ///     Denotes whether the gamma value should be used.
    /// </param>
    /// <param name="numberOfStandardDeviations">
    ///     Applicable when stretchType is standard-deviation. Specifies the number of standard deviations to use. The values beyond the number of standard deviations become the outputMin
    /// </param>
    public RasterStretchRenderer(ColorRamp? colorRamp = null, bool? computeGamma = null, 
        bool? dynamicRangeAdjustment = null, List<int>? gamma = null, int? outputMax = null, int? outputMin = null,
        StretchType? stretchType = null, RasterBandStatistics[]? statistics = null, bool? useGamma = null, 
        int? numberOfStandardDeviations = null)
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
    public ImageryRendererType Type => ImageryRendererType.RasterStretch;

    /// <summary>
    ///     The stretched values are mapped to this specified color ramp.
    /// </summary>
    public ColorRamp? ColorRamp { get; private set; }

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
    public RasterBandStatistics[]? Statistics { get;  set; }

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

    /// <summary>
    ///     Updates the <see cref="StretchType"/> of the renderer after initial rendering.
    /// </summary>
    public async Task SetStretchType(StretchType stretchType)
    {
#pragma warning disable BL0005
        StretchType = stretchType;
#pragma warning restore BL0005
        if (CoreJsModule is null) return;
        
        await CoreJsModule.InvokeVoidAsync("setStretchTypeForRenderer", Id, stretchType);
    }

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
///     The input statistics for rasters
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterStretchRenderer.html#statistics">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Min">
///     The minimum pixel value.
/// </param>
/// <param name="Max">
///     The maximum pixel value.
/// </param>
/// <param name="Avg">
///     The average pixel value.
/// </param>
/// <param name="Stddev">
///     The standard deviation of the pixel value.
/// </param>
public record RasterStatistics(double Min, double Max, double? Avg = null, double? Stddev = null);