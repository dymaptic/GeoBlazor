// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Layers;


/// <summary>
///    A GraphicsLayer contains one or more client-side <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">Graphics</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class GraphicsLayer : IBlendLayer,
    IScaleRangeLayer
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public GraphicsLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="graphics">
    ///     A collection of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">graphics</a> in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#graphics">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    ///     default 1
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#opacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///              referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     default "show"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="persistenceEnabled">
    ///     When `true`, the layer can be persisted.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#persistenceEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#minScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#maxScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenSizePerspectiveEnabled">
    ///     Apply perspective scaling to screen-size point symbols in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#screenSizePerspectiveEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#blendMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#effect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="elevationInfo">
    ///     Specifies how graphics are placed on the vertical axis (z).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#elevationInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fullExtent">
    ///     The full extent of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityTimeExtent">
    ///     Specifies a fixed <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeExtent.html">time extent</a> during which a layer should be visible.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visibilityTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public GraphicsLayer(
        IReadOnlyCollection<Graphic>? graphics = null,
        string? title = null,
        double? opacity = null,
        bool? visible = null,
        ListMode? listMode = null,
        bool? persistenceEnabled = null,
        double? minScale = null,
        double? maxScale = null,
        bool? screenSizePerspectiveEnabled = null,
        BlendMode? blendMode = null,
        Effect? effect = null,
        GraphicsLayerElevationInfo? elevationInfo = null,
        Extent? fullExtent = null,
        TimeExtent? visibilityTimeExtent = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        if (graphics is not null)
        {
            Graphics = graphics;
        }
        Title = title;
        Opacity = opacity;
        if (visible is not null)
        {
            Visible = visible.Value;
        }
        ListMode = listMode;
        PersistenceEnabled = persistenceEnabled;
        MinScale = minScale;
        MaxScale = maxScale;
        ScreenSizePerspectiveEnabled = screenSizePerspectiveEnabled;
        BlendMode = blendMode;
        Effect = effect;
        ElevationInfo = elevationInfo;
        FullExtent = fullExtent;
        VisibilityTimeExtent = visibilityTimeExtent;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Specifies how graphics are placed on the vertical axis (z).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#elevationInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GraphicsLayerElevationInfo? ElevationInfo { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the BlendMode property.
    /// </summary>
    public async Task<BlendMode?> GetBlendMode()
    {
        if (CoreJsModule is null)
        {
            return BlendMode;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return BlendMode;
        }

        // get the property value
        BlendMode? result = await CoreJsModule!.InvokeAsync<BlendMode?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "blendMode");
        if (result is not null)
        {
#pragma warning disable BL0005
             BlendMode = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(BlendMode)] = BlendMode;
        }
         
        return BlendMode;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Effect property.
    /// </summary>
    public async Task<Effect?> GetEffect()
    {
        if (CoreJsModule is null)
        {
            return Effect;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Effect;
        }

        // get the property value
        Effect? result = await CoreJsModule!.InvokeAsync<Effect?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "effect");
        if (result is not null)
        {
#pragma warning disable BL0005
             Effect = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Effect)] = Effect;
        }
         
        return Effect;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ElevationInfo property.
    /// </summary>
    public async Task<GraphicsLayerElevationInfo?> GetElevationInfo()
    {
        if (CoreJsModule is null)
        {
            return ElevationInfo;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ElevationInfo;
        }

        // get the property value
        GraphicsLayerElevationInfo? result = await CoreJsModule!.InvokeAsync<GraphicsLayerElevationInfo?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "elevationInfo");
        if (result is not null)
        {
#pragma warning disable BL0005
             ElevationInfo = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ElevationInfo)] = ElevationInfo;
        }
         
        return ElevationInfo;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MaxScale property.
    /// </summary>
    public async Task<double?> GetMaxScale()
    {
        if (CoreJsModule is null)
        {
            return MaxScale;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MaxScale;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "maxScale");
        if (result is not null)
        {
#pragma warning disable BL0005
             MaxScale = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MaxScale)] = MaxScale;
        }
         
        return MaxScale;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MinScale property.
    /// </summary>
    public async Task<double?> GetMinScale()
    {
        if (CoreJsModule is null)
        {
            return MinScale;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MinScale;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "minScale");
        if (result is not null)
        {
#pragma warning disable BL0005
             MinScale = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MinScale)] = MinScale;
        }
         
        return MinScale;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ScreenSizePerspectiveEnabled property.
    /// </summary>
    public async Task<bool?> GetScreenSizePerspectiveEnabled()
    {
        if (CoreJsModule is null)
        {
            return ScreenSizePerspectiveEnabled;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ScreenSizePerspectiveEnabled;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "screenSizePerspectiveEnabled");
        if (result is not null)
        {
#pragma warning disable BL0005
             ScreenSizePerspectiveEnabled = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ScreenSizePerspectiveEnabled)] = ScreenSizePerspectiveEnabled;
        }
         
        return ScreenSizePerspectiveEnabled;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the BlendMode property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetBlendMode(BlendMode value)
    {
#pragma warning disable BL0005
        BlendMode = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(BlendMode)] = value;
        
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
            JsComponentReference, "blendMode", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Effect property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetEffect(Effect value)
    {
#pragma warning disable BL0005
        Effect = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Effect)] = value;
        
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
            JsComponentReference, "effect", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ElevationInfo property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetElevationInfo(GraphicsLayerElevationInfo value)
    {
#pragma warning disable BL0005
        ElevationInfo = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ElevationInfo)] = value;
        
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
            JsComponentReference, "elevationInfo", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MaxScale property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMaxScale(double value)
    {
#pragma warning disable BL0005
        MaxScale = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MaxScale)] = value;
        
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
            JsComponentReference, "maxScale", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MinScale property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMinScale(double value)
    {
#pragma warning disable BL0005
        MinScale = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MinScale)] = value;
        
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
            JsComponentReference, "minScale", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ScreenSizePerspectiveEnabled property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetScreenSizePerspectiveEnabled(bool value)
    {
#pragma warning disable BL0005
        ScreenSizePerspectiveEnabled = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ScreenSizePerspectiveEnabled)] = value;
        
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
            JsComponentReference, "screenSizePerspectiveEnabled", value);
    }
    
#endregion


#region Public Methods

    /// <summary>
    ///     Adds an array of graphics to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#addMany">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="graphics">
    ///     The graphic(s) to add to the layer.
    /// </param>
    [ArcGISMethod]
    public async Task AddMany(IReadOnlyCollection<Graphic> graphics)
    {
        if (JsComponentReference is null) return;
        
        await JsComponentReference!.InvokeVoidAsync(
            "addMany", 
            CancellationTokenSource.Token,
graphics);
    }
    
    /// <summary>
    ///     Clears all the graphics from the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#removeAll">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    public async Task RemoveAll()
    {
        if (JsComponentReference is null) return;
        
        await JsComponentReference!.InvokeVoidAsync(
            "removeAll", 
            CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     Removes an array of graphics from the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#removeMany">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to remove from the layer.
    /// </param>
    [ArcGISMethod]
    public async Task RemoveMany(IReadOnlyCollection<Graphic> graphics)
    {
        if (JsComponentReference is null) return;
        
        await JsComponentReference!.InvokeVoidAsync(
            "removeMany", 
            CancellationTokenSource.Token,
graphics);
    }
    
#endregion




    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case GraphicsLayerElevationInfo elevationInfo:
                if (elevationInfo != ElevationInfo)
                {
                    ElevationInfo = elevationInfo;
                    LayerChanged = true;
                    ModifiedParameters[nameof(ElevationInfo)] = ElevationInfo;
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
            case GraphicsLayerElevationInfo _:
                ElevationInfo = null;
                LayerChanged = true;
                ModifiedParameters[nameof(ElevationInfo)] = ElevationInfo;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        ElevationInfo?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
