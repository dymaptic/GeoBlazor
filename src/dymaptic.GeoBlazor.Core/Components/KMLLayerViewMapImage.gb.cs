// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.KMLLayerViewMapImage.html">GeoBlazor Docs</a>
///     **MapImage*represents an image overlay draped onto the terrain.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class KMLLayerViewMapImage : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public KMLLayerViewMapImage()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="extent">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of the map image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="href">
    ///     URL to the map image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="kMLLayerViewMapImageId">
    ///     Map image id.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rotation">
    ///     Rotation of the map image about its center, in degrees.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public KMLLayerViewMapImage(
        Extent? extent = null,
        string? href = null,
        long? kMLLayerViewMapImageId = null,
        double? rotation = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Extent = extent;
        Href = href;
        KMLLayerViewMapImageId = kMLLayerViewMapImageId;
        Rotation = rotation;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.KMLLayerViewMapImage.html#kmllayerviewmapimageextent-property">GeoBlazor Docs</a>
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of the map image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.KMLLayerViewMapImage.html#kmllayerviewmapimagehref-property">GeoBlazor Docs</a>
    ///     URL to the map image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Href { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.KMLLayerViewMapImage.html#kmllayerviewmapimagekmllayerviewmapimageid-property">GeoBlazor Docs</a>
    ///     Map image id.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? KMLLayerViewMapImageId { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.KMLLayerViewMapImage.html#kmllayerviewmapimagerotation-property">GeoBlazor Docs</a>
    ///     Rotation of the map image about its center, in degrees.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-KMLLayerView.html#MapImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Rotation { get; set; }
    
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
            return Extent;
        }

        Extent? result = await JsComponentReference.InvokeAsync<Extent?>(
            "getExtent", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (Extent is not null)
            {
                result.Id = Extent.Id;
            }
            
#pragma warning disable BL0005
            Extent = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Extent)] = Extent;
        }
        
        return Extent;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Href property.
    /// </summary>
    public async Task<string?> GetHref()
    {
        if (CoreJsModule is null)
        {
            return Href;
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
            return Href;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "href");
        if (result is not null)
        {
#pragma warning disable BL0005
             Href = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Href)] = Href;
        }
         
        return Href;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the KMLLayerViewMapImageId property.
    /// </summary>
    public async Task<long?> GetKMLLayerViewMapImageId()
    {
        if (CoreJsModule is null)
        {
            return KMLLayerViewMapImageId;
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
            return KMLLayerViewMapImageId;
        }

        // get the property value
        JsNullableLongWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableLongWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "kMLLayerViewMapImageId");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             KMLLayerViewMapImageId = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(KMLLayerViewMapImageId)] = KMLLayerViewMapImageId;
        }
         
        return KMLLayerViewMapImageId;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Rotation property.
    /// </summary>
    public async Task<double?> GetRotation()
    {
        if (CoreJsModule is null)
        {
            return Rotation;
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
            return Rotation;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "rotation");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Rotation = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Rotation)] = Rotation;
        }
         
        return Rotation;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Extent property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExtent(Extent? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Extent = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Extent)] = value;
        
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
            JsComponentReference, "extent", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Href property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHref(string? value)
    {
#pragma warning disable BL0005
        Href = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Href)] = value;
        
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
            JsComponentReference, "href", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the KMLLayerViewMapImageId property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetKMLLayerViewMapImageId(long? value)
    {
#pragma warning disable BL0005
        KMLLayerViewMapImageId = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(KMLLayerViewMapImageId)] = value;
        
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
    
    /// <summary>
    ///    Asynchronously set the value of the Rotation property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetRotation(double? value)
    {
#pragma warning disable BL0005
        Rotation = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Rotation)] = value;
        
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
            JsComponentReference, "rotation", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent extent:
                if (extent != Extent)
                {
                    Extent = extent;
                    ModifiedParameters[nameof(Extent)] = Extent;
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
                Extent = null;
                ModifiedParameters[nameof(Extent)] = Extent;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Extent?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
