// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.ImageMediaInfo.html">GeoBlazor Docs</a>
///     An `ImageMediaInfo` is a type of media element that represents images to display within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ImageMediaInfo
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ImageMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     The title of the media element.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="caption">
    ///     Defines a caption for the media.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#caption">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="altText">
    ///     Provides an alternate text for an image if the image cannot be displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#altText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="value">
    ///     Defines the value format of the image media element and how the images should be retrieved.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html#refreshInterval">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ImageMediaInfo(
        string? title = null,
        string? caption = null,
        string? altText = null,
        ImageMediaInfoValue? value = null,
        double? refreshInterval = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        Caption = caption;
        AltText = altText;
        Value = value;
        RefreshInterval = refreshInterval;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.ImageMediaInfo.html#imagemediainfovalue-property">GeoBlazor Docs</a>
    ///     Defines the value format of the image media element and how the images should be retrieved.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageMediaInfoValue? Value { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the RefreshInterval property.
    /// </summary>
    public async Task<double?> GetRefreshInterval()
    {
        if (CoreJsModule is null)
        {
            return RefreshInterval;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return RefreshInterval;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "refreshInterval");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             RefreshInterval = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(RefreshInterval)] = RefreshInterval;
        }
         
        return RefreshInterval;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Value property.
    /// </summary>
    public async Task<ImageMediaInfoValue?> GetValue()
    {
        if (CoreJsModule is null)
        {
            return Value;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Value;
        }

        ImageMediaInfoValue? result = await JsComponentReference.InvokeAsync<ImageMediaInfoValue?>(
            "getValue", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Value = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Value)] = Value;
        }
        
        return Value;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the RefreshInterval property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetRefreshInterval(double? value)
    {
#pragma warning disable BL0005
        RefreshInterval = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(RefreshInterval)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "refreshInterval", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Value property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValue(ImageMediaInfoValue? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Value = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Value)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "value", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ImageMediaInfoValue value:
                if (value != Value)
                {
                    Value = value;
                    ModifiedParameters[nameof(Value)] = Value;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    /// <inheritdoc />
    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ImageMediaInfoValue _:
                Value = null;
                ModifiedParameters[nameof(Value)] = Value;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Value?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
