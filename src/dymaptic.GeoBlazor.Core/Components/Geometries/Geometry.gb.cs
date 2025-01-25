// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Geometries;


/// <summary>
///    The base class for geometry objects.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract partial class Geometry : ISearchViewModelSelectedSuggestion
{

#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The cache is used to store values computed from geometries that need to be cleared or recomputed upon mutation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#cache">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Cache { get; protected set; }
    
    /// <summary>
    ///     The spatial reference of the geometry.
    ///     default WGS84 (wkid: 4326)
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Cache property.
    /// </summary>
    public async Task<string?> GetCache()
    {
        if (CoreJsModule is null)
        {
            return Cache;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Cache;
        }

        // get the property value
#pragma warning disable BL0005
        Cache = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "cache");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Cache)] = Cache;
        return Cache;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the HasM property.
    /// </summary>
    public async Task<bool?> GetHasM()
    {
        if (CoreJsModule is null)
        {
            return HasM;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return HasM;
        }

        // get the property value
#pragma warning disable BL0005
        HasM = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "hasM");
#pragma warning restore BL0005
         ModifiedParameters[nameof(HasM)] = HasM;
        return HasM;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the HasZ property.
    /// </summary>
    public async Task<bool?> GetHasZ()
    {
        if (CoreJsModule is null)
        {
            return HasZ;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return HasZ;
        }

        // get the property value
#pragma warning disable BL0005
        HasZ = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "hasZ");
#pragma warning restore BL0005
         ModifiedParameters[nameof(HasZ)] = HasZ;
        return HasZ;
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
#pragma warning disable BL0005
        SpatialReference = await CoreJsModule!.InvokeAsync<SpatialReference?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "spatialReference");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SpatialReference)] = SpatialReference;
        return SpatialReference;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the HasM property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHasM(bool value)
    {
#pragma warning disable BL0005
        HasM = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HasM)] = value;
        
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
            JsComponentReference, "hasM", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the HasZ property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHasZ(bool value)
    {
#pragma warning disable BL0005
        HasZ = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HasZ)] = value;
        
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
            JsComponentReference, "hasZ", value);
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
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "spatialReference", value);
    }
    
#endregion




}
