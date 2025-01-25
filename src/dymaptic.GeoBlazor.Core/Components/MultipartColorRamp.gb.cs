// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Creates a multipart color ramp to combine multiple continuous color ramps for use in raster renderers.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MultipartColorRamp.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class MultipartColorRamp : IClassBreaksCreateRendererParamsColorRamp,
    IColorRampsCreateColorRamp,
    IRasterColormapByRampParametersColorRamp,
    IShadedReliefCreateRendererParamsColorRamp,
    IStretchCreateRendererParamsColorRamp,
    IUniqueValueCreateRendererParamsColorRamp
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MultipartColorRamp()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="colorRamps">
    ///     Define an array of algorithmic color ramps used to generate the multi part ramp.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MultipartColorRamp.html#colorRamps">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public MultipartColorRamp(
        IReadOnlyList<AlgorithmicColorRamp>? colorRamps = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        ColorRamps = colorRamps;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Define an array of algorithmic color ramps used to generate the multi part ramp.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MultipartColorRamp.html#colorRamps">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<AlgorithmicColorRamp>? ColorRamps { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the ColorRamps property.
    /// </summary>
    public async Task<IReadOnlyList<AlgorithmicColorRamp>?> GetColorRamps()
    {
        if (CoreJsModule is null)
        {
            return ColorRamps;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ColorRamps;
        }

        // get the property value
#pragma warning disable BL0005
        ColorRamps = await CoreJsModule!.InvokeAsync<IReadOnlyList<AlgorithmicColorRamp>?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "colorRamps");
#pragma warning restore BL0005
         ModifiedParameters[nameof(ColorRamps)] = ColorRamps;
        return ColorRamps;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the ColorRamps property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetColorRamps(IReadOnlyList<AlgorithmicColorRamp> value)
    {
#pragma warning disable BL0005
        ColorRamps = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ColorRamps)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "colorRamps", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the ColorRamps property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToColorRamps(params AlgorithmicColorRamp[] values)
    {
        AlgorithmicColorRamp[] join = ColorRamps is null
            ? values
            : [..ColorRamps, ..values];
        await SetColorRamps(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the ColorRamps property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromColorRamps(params AlgorithmicColorRamp[] values)
    {
        if (ColorRamps is null)
        {
            return;
        }
        await SetColorRamps(ColorRamps.Except(values).ToArray());
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AlgorithmicColorRamp colorRamps:
                ColorRamps ??= [];
                if (!ColorRamps.Contains(colorRamps))
                {
                    ColorRamps = [..ColorRamps, colorRamps];
                    
                    ModifiedParameters[nameof(ColorRamps)] = ColorRamps;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AlgorithmicColorRamp colorRamps:
                ColorRamps = ColorRamps?.Where(c => c != colorRamps).ToList();
                
                ModifiedParameters[nameof(ColorRamps)] = ColorRamps;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        if (ColorRamps is not null)
        {
            foreach (AlgorithmicColorRamp child in ColorRamps)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
