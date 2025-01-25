// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    An object that provides the user access to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#pixels">pixels</a> and their values in the layer.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#PixelData">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class PixelData : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PixelData()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="extent">
    ///     The extent of the `pixelBlock`.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#PixelData">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelBlock">
    ///     An object representing the pixels in the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#PixelData">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public PixelData(
        Extent? extent = null,
        PixelBlock? pixelBlock = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Extent = extent;
        PixelBlock = pixelBlock;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The extent of the `pixelBlock`.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#PixelData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }
    
    /// <summary>
    ///     An object representing the pixels in the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#PixelData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PixelBlock? PixelBlock { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Extent property.
    /// </summary>
    public async Task<Extent?> GetExtent()
    {
        if (CoreJsModule is null)
        {
            return Extent;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Extent;
        }

        // get the property value
#pragma warning disable BL0005
        Extent = await CoreJsModule!.InvokeAsync<Extent?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "extent");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Extent)] = Extent;
        return Extent;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the PixelBlock property.
    /// </summary>
    public async Task<PixelBlock?> GetPixelBlock()
    {
        if (CoreJsModule is null)
        {
            return PixelBlock;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return PixelBlock;
        }

        // get the JS object reference
        IJSObjectReference? refResult = (await CoreJsModule!.InvokeAsync<JsObjectRefWrapper?>(
            "getObjectRefForProperty", CancellationTokenSource.Token, JsComponentReference, 
            "pixelBlock"))?.Value;
            
        if (refResult is null)
        {
            return null;
        }
        
        // Try to deserialize the object. This might fail if we don't have the
        // all deserialization edge cases handled.
        try
        {
#pragma warning disable BL0005
            PixelBlock = await CoreJsModule.InvokeAsync<PixelBlock?>(
                "createGeoBlazorObject", CancellationTokenSource.Token, refResult);
#pragma warning restore BL0005
            ModifiedParameters[nameof(PixelBlock)] = PixelBlock;
            if (PixelBlock is not null)
            {
                PixelBlock.Parent = this;
                PixelBlock.View = View;
                PixelBlock.JsComponentReference = refResult;
                await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
                    CancellationTokenSource.Token, refResult, PixelBlock.Id);
                return PixelBlock;
            }
        }
        catch
        {
            Console.WriteLine("Failed to deserialize PixelBlock");
        }
#pragma warning disable BL0005
        PixelBlock = new PixelBlock();
#pragma warning restore BL0005
         ModifiedParameters[nameof(PixelBlock)] = PixelBlock;
        PixelBlock.Parent = this;
        PixelBlock.View = View;
        PixelBlock.JsComponentReference = refResult;
        // register this type in JS
        await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
            CancellationTokenSource.Token, refResult, PixelBlock.Id);
        await PixelBlock.GetProperty<int>(nameof(PixelBlock.Height));
        await PixelBlock.GetProperty<Stream>(nameof(PixelBlock.Mask));
        await PixelBlock.GetProperty<bool>(nameof(PixelBlock.MaskIsAlpha));
        await PixelBlock.GetProperty<Stream>(nameof(PixelBlock.Pixels));
        await PixelBlock.GetProperty<PixelType>(nameof(PixelBlock.PixelType));
        await PixelBlock.GetProperty<IReadOnlyList<PixelBlockStatistics>>(nameof(PixelBlock.Statistics));
        await PixelBlock.GetProperty<int>(nameof(PixelBlock.ValidPixelCount));
        await PixelBlock.GetProperty<int>(nameof(PixelBlock.Width));
        return PixelBlock;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Extent property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExtent(Extent value)
    {
#pragma warning disable BL0005
        Extent = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Extent)] = value;
        
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
            JsComponentReference, "extent", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the PixelBlock property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPixelBlock(PixelBlock value)
    {
#pragma warning disable BL0005
        PixelBlock = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PixelBlock)] = value;
        
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
        
        PixelBlock.Parent = this;
        PixelBlock.View = View;
        
        if (PixelBlock.JsComponentReference is null)
        {
            // new MapComponent, needs to be built and registered in JS
            // this also calls back to OnJsComponentCreated
            IJSObjectReference jsObjectReference = await CoreJsModule.InvokeAsync<IJSObjectReference>(
                $"buildJsPixelBlock", CancellationTokenSource.Token, 
                    PixelBlock, View?.Id);
            // in case the fallback failed, set this here.
            PixelBlock.JsComponentReference ??= jsObjectReference;
            
            await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                JsComponentReference, "pixelBlock", jsObjectReference);
        }
        else
        {
            // this component has already been registered, but we'll call setProperty to make sure
            // it is attached to the parent
            await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                JsComponentReference,
                "pixelBlock", PixelBlock.JsComponentReference);
        }
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PixelBlock pixelBlock:
                if (pixelBlock != PixelBlock)
                {
                    PixelBlock = pixelBlock;
                    
                    ModifiedParameters[nameof(PixelBlock)] = PixelBlock;
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
            case PixelBlock _:
                PixelBlock = null;
                
                ModifiedParameters[nameof(PixelBlock)] = PixelBlock;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        PixelBlock?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
