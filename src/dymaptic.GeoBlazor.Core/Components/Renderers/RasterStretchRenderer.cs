namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     RasterStretchRenderer defines the symbology with a gradual ramp of colors for each pixel in a ImageryLayer, ImageryTileLayer,
///     and WCSLayer based on the pixel value. The RasterStretchRenderer works well when you have a large range of values to display,
///     such as in imagery, aerial photographs, or elevation models. Important to note that RasterStretchRenderer does not inherit from
///     Renderer class.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-RasterStretchRenderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// 
public partial class RasterStretchRenderer : MapComponent, IImageryRenderer
{
    /// <inheritdoc />
    public ImageryRendererType Type => ImageryRendererType.RasterStretch;

    /// <summary>
    ///     The stretched values are mapped to this specified color ramp.
    /// </summary>
    public ColorRamp? ColorRamp { get; set; }

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
    ///     The input statistics can be specified through the Statistics property.
    /// </summary>
    [Parameter]
    [Obsolete("Deprecated since version 4.31. Use CustomStatistics instead.")]
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
public override void ValidateRequiredChildren()
    {
        ColorRamp?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }

}