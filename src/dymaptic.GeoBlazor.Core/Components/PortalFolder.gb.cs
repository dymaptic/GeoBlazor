// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Provides information about folders used to organize content in a portal.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class PortalFolder : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PortalFolder()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="created">
    ///     The date the folder was created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#created">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="portalFolderId">
    ///     The unique id of the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public PortalFolder(
        DateTime? created = null,
        string? portalFolderId = null,
        string? title = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Created = created;
        PortalFolderId = portalFolderId;
        Title = title;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The date the folder was created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#created">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Created { get; set; }
    
    /// <summary>
    ///     The portal associated with the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#portal">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [AncestorPropertyReference]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Portal? Portal { get; set; }
    
    /// <summary>
    ///     The unique id of the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PortalFolderId { get; set; }
    
    /// <summary>
    ///     The title of the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    
    /// <summary>
    ///     The URL to the folder.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalFolder.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; protected set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Created property.
    /// </summary>
    public async Task<DateTime?> GetCreated()
    {
        if (CoreJsModule is null)
        {
            return Created;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Created;
        }

        // get the property value
        JsNullableDateTimeWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDateTimeWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "created");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Created = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Created)] = Created;
        }
         
        return Created;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the PortalFolderId property.
    /// </summary>
    public async Task<string?> GetPortalFolderId()
    {
        if (CoreJsModule is null)
        {
            return PortalFolderId;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return PortalFolderId;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "portalFolderId");
        if (result is not null)
        {
#pragma warning disable BL0005
             PortalFolderId = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(PortalFolderId)] = PortalFolderId;
        }
         
        return PortalFolderId;
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
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "title");
        if (result is not null)
        {
#pragma warning disable BL0005
             Title = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Title)] = Title;
        }
         
        return Title;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Url property.
    /// </summary>
    public async Task<string?> GetUrl()
    {
        if (CoreJsModule is null)
        {
            return Url;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Url;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "url");
        if (result is not null)
        {
#pragma warning disable BL0005
             Url = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Url)] = Url;
        }
         
        return Url;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Created property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCreated(DateTime value)
    {
#pragma warning disable BL0005
        Created = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Created)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "created", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the PortalFolderId property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPortalFolderId(string value)
    {
#pragma warning disable BL0005
        PortalFolderId = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PortalFolderId)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "portalFolderId", value);
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
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "title", value);
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Portal portal:
                if (portal != Portal)
                {
                    Portal = portal;
                    
                    ModifiedParameters[nameof(Portal)] = Portal;
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
            case Portal _:
                Portal = null;
                
                ModifiedParameters[nameof(Portal)] = Portal;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        Portal?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
