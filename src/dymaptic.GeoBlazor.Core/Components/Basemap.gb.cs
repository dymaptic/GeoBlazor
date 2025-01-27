// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A basemap is a collection of layers that provide geographic context to a map or scene with data such as topographic features, road networks, buildings, and labels.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class Basemap
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Basemap()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="baseLayers">
    ///     A collection of tile layers that make up the basemap's features.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="basemapId">
    ///     An identifier used to refer to the basemap when referencing it elsewhere.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="portalItem">
    ///     The portal item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#portalItem">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="referenceLayers">
    ///     A collection of reference layers which are displayed over the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">base layers</a> and can be used to display labels on top of terrain or streets.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#referenceLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the Basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     The style of the basemap from the <a target="_blank" href="https://developers.arcgis.com/rest/basemap-styles/">basemap styles service (v2)</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="thumbnailUrl">
    ///     The URL pointing to an image that represents the basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#thumbnailUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Basemap(
        IReadOnlyList<Layer>? baseLayers = null,
        string? basemapId = null,
        PortalItem? portalItem = null,
        IReadOnlyList<Layer>? referenceLayers = null,
        SpatialReference? spatialReference = null,
        BasemapStyle? style = null,
        string? thumbnailUrl = null,
        string? title = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        BaseLayers = baseLayers;
        BasemapId = basemapId;
        PortalItem = portalItem;
        ReferenceLayers = referenceLayers;
        SpatialReference = spatialReference;
        Style = style;
        ThumbnailUrl = thumbnailUrl;
        Title = title;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     A collection of tile layers that make up the basemap's features.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Layer>? BaseLayers { get; set; }
    
    /// <summary>
    ///     An identifier used to refer to the basemap when referencing it elsewhere.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BasemapId { get; set; }
    
    /// <summary>
    ///     Indicates whether the basemap instance has loaded.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#loaded">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Loaded { get; protected set; }
    
    /// <summary>
    ///     The portal item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#portalItem">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalItem? PortalItem { get; set; }
    
    /// <summary>
    ///     A collection of reference layers which are displayed over the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">base layers</a> and can be used to display labels on top of terrain or streets.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#referenceLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Layer>? ReferenceLayers { get; set; }
    
    /// <summary>
    ///     The spatial reference of the Basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }
    
    /// <summary>
    ///     The style of the basemap from the <a target="_blank" href="https://developers.arcgis.com/rest/basemap-styles/">basemap styles service (v2)</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BasemapStyle? Style { get; set; }
    
    /// <summary>
    ///     The URL pointing to an image that represents the basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#thumbnailUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ThumbnailUrl { get; set; }
    
    /// <summary>
    ///     The title of the basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the BasemapId property.
    /// </summary>
    public async Task<string?> GetBasemapId()
    {
        if (CoreJsModule is null)
        {
            return BasemapId;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return BasemapId;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "basemapId");
        if (result is not null)
        {
#pragma warning disable BL0005
             BasemapId = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(BasemapId)] = BasemapId;
        }
         
        return BasemapId;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Loaded property.
    /// </summary>
    public async Task<bool?> GetLoaded()
    {
        if (CoreJsModule is null)
        {
            return Loaded;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Loaded;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "loaded");
        if (result is not null)
        {
#pragma warning disable BL0005
             Loaded = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Loaded)] = Loaded;
        }
         
        return Loaded;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the PortalItem property.
    /// </summary>
    public async Task<PortalItem?> GetPortalItem()
    {
        if (CoreJsModule is null)
        {
            return PortalItem;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return PortalItem;
        }

        // get the JS object reference
        IJSObjectReference? refResult = (await CoreJsModule!.InvokeAsync<JsObjectRefWrapper?>(
            "getObjectRefForProperty", CancellationTokenSource.Token, JsComponentReference, 
            "portalItem"))?.Value;
            
        if (refResult is null)
        {
            return null;
        }
        
        PortalItem? result = null;
        
        // Try to deserialize the object. This might fail if we don't have the
        // all deserialization edge cases handled.
        try
        {
            result = await CoreJsModule.InvokeAsync<PortalItem?>(
                "createGeoBlazorObject", CancellationTokenSource.Token, refResult);
            if (result is not null)
            {
#pragma warning disable BL0005
                PortalItem = result;
#pragma warning restore BL0005
                ModifiedParameters[nameof(PortalItem)] = PortalItem;
            }
            
            if (PortalItem is not null)
            {
                PortalItem.Parent = this;
                PortalItem.View = View;
                PortalItem.JsComponentReference = refResult;
                await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
                    CancellationTokenSource.Token, refResult, PortalItem.Id);
                return PortalItem;
            }
        }
        catch
        {
            Console.WriteLine("Failed to deserialize PortalItem");
        }
#pragma warning disable BL0005
        PortalItem = new PortalItem();
#pragma warning restore BL0005
        ModifiedParameters[nameof(PortalItem)] = PortalItem;
        PortalItem.Parent = this;
        PortalItem.View = View;
        PortalItem.JsComponentReference = refResult;
        // register this type in JS
        await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
            CancellationTokenSource.Token, refResult, PortalItem.Id);
        await PortalItem.GetProperty<PortalItemAccess>(nameof(PortalItem.Access));
        await PortalItem.GetProperty<string>(nameof(PortalItem.AccessInformation));
        await PortalItem.GetProperty<string>(nameof(PortalItem.ApiKey));
        await PortalItem.GetProperty<IReadOnlyList<PortalItemApplicationProxies>>(nameof(PortalItem.ApplicationProxies));
        await PortalItem.GetProperty<double>(nameof(PortalItem.AvgRating));
        await PortalItem.GetProperty<IReadOnlyList<string>>(nameof(PortalItem.Categories));
        await PortalItem.GetProperty<DateTime>(nameof(PortalItem.Created));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Culture));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Description));
        await PortalItem.GetProperty<Extent>(nameof(PortalItem.Extent));
        await PortalItem.GetProperty<IReadOnlyList<string>>(nameof(PortalItem.GroupCategories));
        await PortalItem.GetProperty<bool>(nameof(PortalItem.IsLayer));
        await PortalItem.GetProperty<bool>(nameof(PortalItem.IsOrgItem));
        await PortalItem.GetProperty<ItemControl>(nameof(PortalItem.ItemControl));
        await PortalItem.GetProperty<string>(nameof(PortalItem.ItemPageUrl));
        await PortalItem.GetProperty<string>(nameof(PortalItem.ItemUrl));
        await PortalItem.GetProperty<string>(nameof(PortalItem.LicenseInfo));
        await PortalItem.GetProperty<bool>(nameof(PortalItem.Loaded));
        await PortalItem.GetProperty<DateTime>(nameof(PortalItem.Modified));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Name));
        await PortalItem.GetProperty<double>(nameof(PortalItem.NumComments));
        await PortalItem.GetProperty<double>(nameof(PortalItem.NumRatings));
        await PortalItem.GetProperty<double>(nameof(PortalItem.NumViews));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Owner));
        await PortalItem.GetProperty<string>(nameof(PortalItem.OwnerFolder));
        await PortalItem.GetProperty<Portal>(nameof(PortalItem.Portal));
        await PortalItem.GetProperty<string>(nameof(PortalItem.PortalItemId));
        await PortalItem.GetProperty<IReadOnlyList<string>>(nameof(PortalItem.Screenshots));
        await PortalItem.GetProperty<int>(nameof(PortalItem.Size));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Snippet));
        await PortalItem.GetProperty<string>(nameof(PortalItem.SourceJSON));
        await PortalItem.GetProperty<IReadOnlyList<string>>(nameof(PortalItem.Tags));
        await PortalItem.GetProperty<string>(nameof(PortalItem.ThumbnailUrl));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Title));
        await PortalItem.GetProperty<IReadOnlyList<string>>(nameof(PortalItem.TypeKeywords));
        await PortalItem.GetProperty<string>(nameof(PortalItem.Url));
        return PortalItem;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SpatialReference property.
    /// </summary>
    public async Task<SpatialReference?> GetSpatialReference()
    {
        if (CoreJsModule is null)
        {
            return SpatialReference;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SpatialReference;
        }

        // get the property value
        SpatialReference? result = await CoreJsModule!.InvokeAsync<SpatialReference?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "spatialReference");
        if (result is not null)
        {
#pragma warning disable BL0005
             SpatialReference = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SpatialReference)] = SpatialReference;
        }
         
        return SpatialReference;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Style property.
    /// </summary>
    public async Task<BasemapStyle?> GetStyle()
    {
        if (CoreJsModule is null)
        {
            return Style;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Style;
        }

        // get the property value
        BasemapStyle? result = await CoreJsModule!.InvokeAsync<BasemapStyle?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "style");
        if (result is not null)
        {
#pragma warning disable BL0005
             Style = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Style)] = Style;
        }
         
        return Style;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ThumbnailUrl property.
    /// </summary>
    public async Task<string?> GetThumbnailUrl()
    {
        if (CoreJsModule is null)
        {
            return ThumbnailUrl;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ThumbnailUrl;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "thumbnailUrl");
        if (result is not null)
        {
#pragma warning disable BL0005
             ThumbnailUrl = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ThumbnailUrl)] = ThumbnailUrl;
        }
         
        return ThumbnailUrl;
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
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "title");
        if (result is not null)
        {
#pragma warning disable BL0005
             Title = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Title)] = Title;
        }
         
        return Title;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the BaseLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetBaseLayers(IReadOnlyList<Layer> value)
    {
#pragma warning disable BL0005
        BaseLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(BaseLayers)] = value;
        
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
        
        foreach (Layer item in value)
        {
            item.Parent = this;
            item.View = View;
            
            if (item.JsComponentReference is null)
            {
                // new MapComponent, needs to be built and registered in JS
                // this also calls back to OnJsComponentCreated
                IJSObjectReference jsObjectReference = await CoreJsModule.InvokeAsync<IJSObjectReference>(
                    $"buildJsLayer", CancellationTokenSource.Token, 
                        item, View?.Id);
                // in case the fallback failed, set this here.
                item.JsComponentReference ??= jsObjectReference;
                
                await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                    JsComponentReference, "baseLayers", jsObjectReference);
            }
            else
            {
                // this component has already been registered, but we'll call setProperty to make sure
                // it is attached to the parent
                await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                    JsComponentReference,
                    "baseLayers", item.JsComponentReference);

            }
        }
    }
    
    /// <summary>
    ///    Asynchronously set the value of the BasemapId property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetBasemapId(string value)
    {
#pragma warning disable BL0005
        BasemapId = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(BasemapId)] = value;
        
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
            JsComponentReference, "basemapId", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the PortalItem property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPortalItem(PortalItem value)
    {
#pragma warning disable BL0005
        PortalItem = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PortalItem)] = value;
        
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
        
        PortalItem.Parent = this;
        PortalItem.View = View;
        
        if (PortalItem.JsComponentReference is null)
        {
            // new MapComponent, needs to be built and registered in JS
            // this also calls back to OnJsComponentCreated
            IJSObjectReference jsObjectReference = await CoreJsModule.InvokeAsync<IJSObjectReference>(
                $"buildJsPortalItem", CancellationTokenSource.Token, 
                    PortalItem, View?.Id);
            // in case the fallback failed, set this here.
            PortalItem.JsComponentReference ??= jsObjectReference;
            
            await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                JsComponentReference, "portalItem", jsObjectReference);
        }
        else
        {
            // this component has already been registered, but we'll call setProperty to make sure
            // it is attached to the parent
            await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                JsComponentReference,
                "portalItem", PortalItem.JsComponentReference);
        }
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ReferenceLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetReferenceLayers(IReadOnlyList<Layer> value)
    {
#pragma warning disable BL0005
        ReferenceLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ReferenceLayers)] = value;
        
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
        
        foreach (Layer item in value)
        {
            item.Parent = this;
            item.View = View;
            
            if (item.JsComponentReference is null)
            {
                // new MapComponent, needs to be built and registered in JS
                // this also calls back to OnJsComponentCreated
                IJSObjectReference jsObjectReference = await CoreJsModule.InvokeAsync<IJSObjectReference>(
                    $"buildJsLayer", CancellationTokenSource.Token, 
                        item, View?.Id);
                // in case the fallback failed, set this here.
                item.JsComponentReference ??= jsObjectReference;
                
                await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                    JsComponentReference, "referenceLayers", jsObjectReference);
            }
            else
            {
                // this component has already been registered, but we'll call setProperty to make sure
                // it is attached to the parent
                await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                    JsComponentReference,
                    "referenceLayers", item.JsComponentReference);

            }
        }
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SpatialReference property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSpatialReference(SpatialReference value)
    {
#pragma warning disable BL0005
        SpatialReference = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SpatialReference)] = value;
        
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
            JsComponentReference, "spatialReference", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Style property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStyle(BasemapStyle value)
    {
#pragma warning disable BL0005
        Style = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Style)] = value;
        
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
            JsComponentReference, "style", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ThumbnailUrl property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetThumbnailUrl(string value)
    {
#pragma warning disable BL0005
        ThumbnailUrl = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ThumbnailUrl)] = value;
        
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
            JsComponentReference, "thumbnailUrl", value);
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

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the BaseLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToBaseLayers(params Layer[] values)
    {
        Layer[] join = BaseLayers is null
            ? values
            : [..BaseLayers, ..values];
        await SetBaseLayers(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the ReferenceLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToReferenceLayers(params Layer[] values)
    {
        Layer[] join = ReferenceLayers is null
            ? values
            : [..ReferenceLayers, ..values];
        await SetReferenceLayers(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the BaseLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromBaseLayers(params Layer[] values)
    {
        if (BaseLayers is null)
        {
            return;
        }
        await SetBaseLayers(BaseLayers.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the ReferenceLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromReferenceLayers(params Layer[] values)
    {
        if (ReferenceLayers is null)
        {
            return;
        }
        await SetReferenceLayers(ReferenceLayers.Except(values).ToArray());
    }
    
#endregion


#region Public Methods

    /// <summary>
    ///     Loads all the externally loadable resources associated with the basemap.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#loadAll">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    public async Task<Basemap?> LoadAll()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<Basemap?>(
            "loadAll", 
            CancellationTokenSource.Token);
    }
    
#endregion




    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (portalItem != PortalItem)
                {
                    PortalItem = portalItem;
                    
                    ModifiedParameters[nameof(PortalItem)] = PortalItem;
                }
                
                return true;
            case BasemapStyle style:
                if (style != Style)
                {
                    Style = style;
                    
                    ModifiedParameters[nameof(Style)] = Style;
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
            case PortalItem _:
                PortalItem = null;
                
                ModifiedParameters[nameof(PortalItem)] = PortalItem;
                return true;
            case BasemapStyle _:
                Style = null;
                
                ModifiedParameters[nameof(Style)] = Style;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        PortalItem?.ValidateRequiredGeneratedChildren();
        Style?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
