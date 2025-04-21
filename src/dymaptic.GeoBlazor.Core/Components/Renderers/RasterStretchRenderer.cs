namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public partial class RasterStretchRenderer : MapComponent, IImageryRenderer
{
    /// <inheritdoc />
    public ImageryRendererType Type => ImageryRendererType.RasterStretch;


    /// <summary>
    ///     The computeGamma automatically calculates best gamma value to render exported image based on empirical model. This is applicable to any stretch type when useGamma is true.
    /// </summary>
    [Parameter]
    public bool? ComputeGamma { get; set; }

    /// <summary>
    ///     When Dynamic Range Adjustment is true, the statistics based on the current display extent are calculated as you zoom and pan around the image. This property only applies to images in 2D MapView.
    /// </summary>
    [Parameter]
    public bool? DynamicRangeAdjustment { get; set; } = false;


    /// <summary>
    ///     The outputMax denotes the output maximum, which is the highest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast stretched. The outputMax value ranges from 0-255.
    /// </summary>
    [Parameter]
    public int? OutputMax { get;  set; }

    /// <summary>
    ///     The outputMin denotes the output minimum, which is the lowest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast stretched. The outputMin value ranges from 0-255.
    /// </summary>
    [Parameter]
    public int? OutputMin { get;  set; }

    /// <summary>
    ///     The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the pixel values along a histogram from the minimum and maximum values defined by their bit depth.
    /// </summary>
    [Parameter]
    public StretchType? StretchType { get; set; }


    /// <summary>
    ///     Denotes whether the gamma value should be used.
    /// </summary>
    [Parameter]
    public bool? UseGamma { get; set; }

    /// <summary>
    ///     Applicable when stretchType is standard-deviation. Specifies the number of standard deviations to use. The values beyond the number of standard deviations become the outputMin and outputMax. The remaining values are linearly stretched between outputMin and outputMax.
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


}