// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Popups;


/// <summary>
///    An `AttachmentsContent` popup element represents an attachment element associated with a feature.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class AttachmentsPopupContent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public AttachmentsPopupContent()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     A heading indicating what the attachment's content represents.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="description">
    ///     Describes the attachment's content in detail.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html#description">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="displayType">
    ///     A string value indicating how to display an attachment.
    ///     default "auto"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html#displayType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public AttachmentsPopupContent(
        string? title = null,
        string? description = null,
        AttachmentsPopupContentDisplayType? displayType = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        Description = description;
        DisplayType = displayType;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Description property.
    /// </summary>
    public async Task<string?> GetDescription()
    {
        if (CoreJsModule is null)
        {
            return Description;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Description;
        }

        // get the property value
#pragma warning disable BL0005
        Description = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "description");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Description)] = Description;
        return Description;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Title property.
    /// </summary>
    public async Task<string?> GetTitle()
    {
        if (CoreJsModule is null)
        {
            return Title;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Title;
        }

        // get the property value
#pragma warning disable BL0005
        Title = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "title");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Title)] = Title;
        return Title;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Description property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDescription(string value)
    {
#pragma warning disable BL0005
        Description = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Description)] = value;
        
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
            JsComponentReference, "description", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Title property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTitle(string value)
    {
#pragma warning disable BL0005
        Title = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Title)] = value;
        
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
            JsComponentReference, "title", value);
    }
    
#endregion




}
