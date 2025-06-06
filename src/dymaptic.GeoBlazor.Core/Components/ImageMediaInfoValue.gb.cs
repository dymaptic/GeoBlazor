// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.ImageMediaInfoValue.html">GeoBlazor Docs</a>
///     The `ImageMediaInfoValue` class contains information for popups regarding how images should be retrieved.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ImageMediaInfoValue.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ImageMediaInfoValue
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ImageMediaInfoValue()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="linkURL">
    ///     A string containing a URL to be launched in a browser when a user clicks the image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ImageMediaInfoValue.html#linkURL">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sourceURL">
    ///     A string containing the URL to the image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ImageMediaInfoValue.html#sourceURL">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ImageMediaInfoValue(
        string? linkURL = null,
        string? sourceURL = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        LinkURL = linkURL;
        SourceURL = sourceURL;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the LinkURL property.
    /// </summary>
    public async Task<string?> GetLinkURL()
    {
        if (CoreJsModule is null)
        {
            return LinkURL;
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
            return LinkURL;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "linkURL");
        if (result is not null)
        {
#pragma warning disable BL0005
             LinkURL = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LinkURL)] = LinkURL;
        }
         
        return LinkURL;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SourceURL property.
    /// </summary>
    public async Task<string?> GetSourceURL()
    {
        if (CoreJsModule is null)
        {
            return SourceURL;
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
            return SourceURL;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "sourceURL");
        if (result is not null)
        {
#pragma warning disable BL0005
             SourceURL = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SourceURL)] = SourceURL;
        }
         
        return SourceURL;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the LinkURL property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLinkURL(string? value)
    {
#pragma warning disable BL0005
        LinkURL = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LinkURL)] = value;
        
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
            JsComponentReference, "linkURL", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SourceURL property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSourceURL(string? value)
    {
#pragma warning disable BL0005
        SourceURL = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SourceURL)] = value;
        
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
            JsComponentReference, "sourceURL", value);
    }
    
#endregion

}
