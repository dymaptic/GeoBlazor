// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.TileMatrixSet.html">GeoBlazor Docs</a>
///     Contains information about the tiling scheme for <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMTSSublayer.html">WMTSSublayer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class TileMatrixSet : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public TileMatrixSet()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="fullExtent">
    ///     The full extent of the TileMatrixSet.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="tileInfo">
    ///     The tiling scheme information for the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#tileInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="tileMatrixSetId">
    ///     The unique ID assigned to the TileMatrixSet.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public TileMatrixSet(
        Extent? fullExtent = null,
        TileInfo? tileInfo = null,
        string? tileMatrixSetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        FullExtent = fullExtent;
        TileInfo = tileInfo;
        TileMatrixSetId = tileMatrixSetId;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.TileMatrixSet.html#tilematrixsetfullextent-property">GeoBlazor Docs</a>
    ///     The full extent of the TileMatrixSet.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.TileMatrixSet.html#tilematrixsettileinfo-property">GeoBlazor Docs</a>
    ///     The tiling scheme information for the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#tileInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.TileMatrixSet.html#tilematrixsettilematrixsetid-property">GeoBlazor Docs</a>
    ///     The unique ID assigned to the TileMatrixSet.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileMatrixSet.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TileMatrixSetId { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the FullExtent property.
    /// </summary>
    public async Task<Extent?> GetFullExtent()
    {
        if (CoreJsModule is null)
        {
            return FullExtent;
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
            return FullExtent;
        }

        Extent? result = await JsComponentReference.InvokeAsync<Extent?>(
            "getFullExtent", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (FullExtent is not null)
            {
                result.Id = FullExtent.Id;
            }
            
#pragma warning disable BL0005
            FullExtent = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(FullExtent)] = FullExtent;
        }
        
        return FullExtent;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the TileInfo property.
    /// </summary>
    public async Task<TileInfo?> GetTileInfo()
    {
        if (CoreJsModule is null)
        {
            return TileInfo;
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
            return TileInfo;
        }

        TileInfo? result = await JsComponentReference.InvokeAsync<TileInfo?>(
            "getTileInfo", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (TileInfo is not null)
            {
                result.Id = TileInfo.Id;
            }
            
#pragma warning disable BL0005
            TileInfo = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(TileInfo)] = TileInfo;
        }
        
        return TileInfo;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the TileMatrixSetId property.
    /// </summary>
    public async Task<string?> GetTileMatrixSetId()
    {
        if (CoreJsModule is null)
        {
            return TileMatrixSetId;
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
            return TileMatrixSetId;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "id");
        if (result is not null)
        {
#pragma warning disable BL0005
             TileMatrixSetId = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(TileMatrixSetId)] = TileMatrixSetId;
        }
         
        return TileMatrixSetId;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the FullExtent property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetFullExtent(Extent? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        FullExtent = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(FullExtent)] = value;
        
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
            JsComponentReference, "fullExtent", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the TileInfo property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTileInfo(TileInfo? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        TileInfo = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TileInfo)] = value;
        
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
            JsComponentReference, "tileInfo", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the TileMatrixSetId property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTileMatrixSetId(string? value)
    {
#pragma warning disable BL0005
        TileMatrixSetId = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TileMatrixSetId)] = value;
        
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
            JsComponentReference, "id", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent fullExtent:
                if (fullExtent != FullExtent)
                {
                    FullExtent = fullExtent;
                    ModifiedParameters[nameof(FullExtent)] = FullExtent;
                }
                
                return true;
            case TileInfo tileInfo:
                if (tileInfo != TileInfo)
                {
                    TileInfo = tileInfo;
                    ModifiedParameters[nameof(TileInfo)] = TileInfo;
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
            case Extent _:
                FullExtent = null;
                ModifiedParameters[nameof(FullExtent)] = FullExtent;
                return true;
            case TileInfo _:
                TileInfo = null;
                ModifiedParameters[nameof(TileInfo)] = TileInfo;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        FullExtent?.ValidateRequiredGeneratedChildren();
        TileInfo?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
