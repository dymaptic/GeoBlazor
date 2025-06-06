// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarkOptionsScreenshotSettings.html">GeoBlazor Docs</a>
///     An object that specifies the settings of the screenshot that will be used to create the bookmark's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webmap-Bookmark.html#thumbnail">thumbnail</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class BookmarkOptionsScreenshotSettings
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public BookmarkOptionsScreenshotSettings()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="area">
    ///     Used to take a screenshot of a subregion of the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="height">
    ///     The height (in pixels) of the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="layers">
    ///     An optional list of layers to be included in the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="width">
    ///     The width (in pixels) of the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public BookmarkOptionsScreenshotSettings(
        BookmarkOptionsScreenshotSettingsArea? area = null,
        int? height = null,
        IReadOnlyList<Layer>? layers = null,
        int? width = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Area = area;
        Height = height;
        Layers = layers;
        Width = width;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarkOptionsScreenshotSettings.html#bookmarkoptionsscreenshotsettingsarea-property">GeoBlazor Docs</a>
    ///     Used to take a screenshot of a subregion of the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BookmarkOptionsScreenshotSettingsArea? Area { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarkOptionsScreenshotSettings.html#bookmarkoptionsscreenshotsettingsheight-property">GeoBlazor Docs</a>
    ///     The height (in pixels) of the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarkOptionsScreenshotSettings.html#bookmarkoptionsscreenshotsettingslayers-property">GeoBlazor Docs</a>
    ///     An optional list of layers to be included in the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Layer>? Layers { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarkOptionsScreenshotSettings.html#bookmarkoptionsscreenshotsettingswidth-property">GeoBlazor Docs</a>
    ///     The width (in pixels) of the screenshot.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarkOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Area property.
    /// </summary>
    public async Task<BookmarkOptionsScreenshotSettingsArea?> GetArea()
    {
        if (CoreJsModule is null)
        {
            return Area;
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
            return Area;
        }

        BookmarkOptionsScreenshotSettingsArea? result = await JsComponentReference.InvokeAsync<BookmarkOptionsScreenshotSettingsArea?>(
            "getArea", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Area = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Area)] = Area;
        }
        
        return Area;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Height property.
    /// </summary>
    public async Task<int?> GetHeight()
    {
        if (CoreJsModule is null)
        {
            return Height;
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
            return Height;
        }

        // get the property value
        JsNullableIntWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableIntWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "height");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Height = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Height)] = Height;
        }
         
        return Height;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Layers property.
    /// </summary>
    public async Task<IReadOnlyList<Layer>?> GetLayers()
    {
        if (CoreJsModule is null)
        {
            return Layers;
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
            return Layers;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getLayers", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Layers = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Layers)] = Layers;
        }
        
        return Layers;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Width property.
    /// </summary>
    public async Task<int?> GetWidth()
    {
        if (CoreJsModule is null)
        {
            return Width;
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
            return Width;
        }

        // get the property value
        JsNullableIntWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableIntWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "width");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Width = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Width)] = Width;
        }
         
        return Width;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Area property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetArea(BookmarkOptionsScreenshotSettingsArea? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Area = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Area)] = value;
        
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
            JsComponentReference, "area", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Height property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHeight(int? value)
    {
#pragma warning disable BL0005
        Height = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Height)] = value;
        
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
            JsComponentReference, "height", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Layers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLayers(IReadOnlyList<Layer>? value)
    {
        if (value is not null)
        {
            foreach (Layer item in value)
            {
                item.CoreJsModule = CoreJsModule;
                item.Parent = this;
                item.Layer = Layer;
                item.View = View;
            }
        }
        
#pragma warning disable BL0005
        Layers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Layers)] = value;
        
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
            JsComponentReference, "layers", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Width property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWidth(int? value)
    {
#pragma warning disable BL0005
        Width = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Width)] = value;
        
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
            JsComponentReference, "width", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Layers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToLayers(params Layer[] values)
    {
        Layer[] join = Layers is null
            ? values
            : [..Layers, ..values];
        await SetLayers(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Layers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromLayers(params Layer[] values)
    {
        if (Layers is null)
        {
            return;
        }
        await SetLayers(Layers.Except(values).ToArray());
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case BookmarkOptionsScreenshotSettingsArea area:
                if (area != Area)
                {
                    Area = area;
                    ModifiedParameters[nameof(Area)] = Area;
                }
                
                return true;
            case Layer layers:
                Layers ??= [];
                if (!Layers.Contains(layers))
                {
                    Layers = [..Layers, layers];
                    ModifiedParameters[nameof(Layers)] = Layers;
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
            case BookmarkOptionsScreenshotSettingsArea _:
                Area = null;
                ModifiedParameters[nameof(Area)] = Area;
                return true;
            case Layer layers:
                Layers = Layers?.Where(l => l != layers).ToList();
                ModifiedParameters[nameof(Layers)] = Layers;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Area?.ValidateRequiredGeneratedChildren();
        if (Layers is not null)
        {
            foreach (Layer child in Layers)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
