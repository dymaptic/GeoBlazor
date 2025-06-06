// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.HighlightOptions.html">GeoBlazor Docs</a>
///     HighlightOptions are used to customize the appearance of highlights applied to features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class HighlightOptions
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public HighlightOptions()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="color">
    ///     The color of the highlight fill.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="haloColor">
    ///     The color of the halo surrounding the highlight.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#haloColor">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="haloOpacity">
    ///     The opacity of the highlight halo.
    ///     default 1
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#haloOpacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fillOpacity">
    ///     The opacity of the fill (area within the halo).
    ///     default 0.25
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#fillOpacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="shadowColor">
    ///     The color of the highlighted feature's shadow in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">3D SceneView</a>.
    ///     default #000000
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#shadowColor">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="shadowOpacity">
    ///     The opacity of the highlighted feature's shadow in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">3D SceneView</a>.
    ///     default 0.4
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#shadowOpacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="shadowDifference">
    ///     Defines the intensity of the shadow area obtained by overlapping the shadow of the highlighted feature and the
    ///     shadow of other objects in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">3D SceneView</a>.
    ///     default 0.2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#shadowDifference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     A name used to uniquely identify the highlight options within the view's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html#highlights">highlights</a> collection.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public HighlightOptions(
        MapColor? color = null,
        MapColor? haloColor = null,
        double? haloOpacity = null,
        double? fillOpacity = null,
        MapColor? shadowColor = null,
        double? shadowOpacity = null,
        double? shadowDifference = null,
        string? name = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Color = color;
        HaloColor = haloColor;
        HaloOpacity = haloOpacity;
        FillOpacity = fillOpacity;
        ShadowColor = shadowColor;
        ShadowOpacity = shadowOpacity;
        ShadowDifference = shadowDifference;
        Name = name;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.HighlightOptions.html#highlightoptionsname-property">GeoBlazor Docs</a>
    ///     A name used to uniquely identify the highlight options within the view's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html#highlights">highlights</a> collection.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-support-HighlightOptions.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Color property.
    /// </summary>
    public async Task<MapColor?> GetColor()
    {
        if (CoreJsModule is null)
        {
            return Color;
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
            return Color;
        }

        // get the property value
        MapColor? result = await JsComponentReference!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, "color");
        if (result is not null)
        {
#pragma warning disable BL0005
             Color = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Color)] = Color;
        }
         
        return Color;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the FillOpacity property.
    /// </summary>
    public async Task<double?> GetFillOpacity()
    {
        if (CoreJsModule is null)
        {
            return FillOpacity;
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
            return FillOpacity;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "fillOpacity");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             FillOpacity = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(FillOpacity)] = FillOpacity;
        }
         
        return FillOpacity;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the HaloColor property.
    /// </summary>
    public async Task<MapColor?> GetHaloColor()
    {
        if (CoreJsModule is null)
        {
            return HaloColor;
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
            return HaloColor;
        }

        // get the property value
        MapColor? result = await JsComponentReference!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, "haloColor");
        if (result is not null)
        {
#pragma warning disable BL0005
             HaloColor = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(HaloColor)] = HaloColor;
        }
         
        return HaloColor;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the HaloOpacity property.
    /// </summary>
    public async Task<double?> GetHaloOpacity()
    {
        if (CoreJsModule is null)
        {
            return HaloOpacity;
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
            return HaloOpacity;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "haloOpacity");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             HaloOpacity = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(HaloOpacity)] = HaloOpacity;
        }
         
        return HaloOpacity;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Name property.
    /// </summary>
    public async Task<string?> GetName()
    {
        if (CoreJsModule is null)
        {
            return Name;
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
            return Name;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "name");
        if (result is not null)
        {
#pragma warning disable BL0005
             Name = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Name)] = Name;
        }
         
        return Name;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ShadowColor property.
    /// </summary>
    public async Task<MapColor?> GetShadowColor()
    {
        if (CoreJsModule is null)
        {
            return ShadowColor;
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
            return ShadowColor;
        }

        // get the property value
        MapColor? result = await JsComponentReference!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, "shadowColor");
        if (result is not null)
        {
#pragma warning disable BL0005
             ShadowColor = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ShadowColor)] = ShadowColor;
        }
         
        return ShadowColor;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ShadowDifference property.
    /// </summary>
    public async Task<double?> GetShadowDifference()
    {
        if (CoreJsModule is null)
        {
            return ShadowDifference;
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
            return ShadowDifference;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "shadowDifference");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             ShadowDifference = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ShadowDifference)] = ShadowDifference;
        }
         
        return ShadowDifference;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ShadowOpacity property.
    /// </summary>
    public async Task<double?> GetShadowOpacity()
    {
        if (CoreJsModule is null)
        {
            return ShadowOpacity;
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
            return ShadowOpacity;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "shadowOpacity");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             ShadowOpacity = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ShadowOpacity)] = ShadowOpacity;
        }
         
        return ShadowOpacity;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Color property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetColor(MapColor? value)
    {
#pragma warning disable BL0005
        Color = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Color)] = value;
        
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
            JsComponentReference, "color", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the FillOpacity property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetFillOpacity(double? value)
    {
#pragma warning disable BL0005
        FillOpacity = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(FillOpacity)] = value;
        
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
            JsComponentReference, "fillOpacity", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the HaloColor property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHaloColor(MapColor? value)
    {
#pragma warning disable BL0005
        HaloColor = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HaloColor)] = value;
        
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
            JsComponentReference, "haloColor", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the HaloOpacity property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHaloOpacity(double? value)
    {
#pragma warning disable BL0005
        HaloOpacity = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HaloOpacity)] = value;
        
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
            JsComponentReference, "haloOpacity", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Name property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetName(string? value)
    {
#pragma warning disable BL0005
        Name = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Name)] = value;
        
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
            JsComponentReference, "name", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ShadowColor property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetShadowColor(MapColor? value)
    {
#pragma warning disable BL0005
        ShadowColor = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ShadowColor)] = value;
        
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
            JsComponentReference, "shadowColor", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ShadowDifference property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetShadowDifference(double? value)
    {
#pragma warning disable BL0005
        ShadowDifference = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ShadowDifference)] = value;
        
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
            JsComponentReference, "shadowDifference", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ShadowOpacity property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetShadowOpacity(double? value)
    {
#pragma warning disable BL0005
        ShadowOpacity = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ShadowOpacity)] = value;
        
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
            JsComponentReference, "shadowOpacity", value);
    }
    
#endregion

}
