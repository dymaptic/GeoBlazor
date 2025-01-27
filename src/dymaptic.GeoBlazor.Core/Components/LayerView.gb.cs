// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Represents the view for a single layer after it has been added to either a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> or a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class LayerView
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public LayerView()
    {
    }

#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Indicates if the  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#spatialReference">spatialReference</a> of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> is supported by the layer view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#spatialReferenceSupported">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SpatialReferenceSupported { get; protected set; }
    
    /// <summary>
    ///     Value is `true` if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#suspended">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Suspended { get; protected set; }
    
    /// <summary>
    ///     Indicates if the layer view is making any updates that will impact what is displayed on the map.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#updating">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Updating { get; protected set; }
    
    /// <summary>
    ///     When `true`, the layer is visible in the view at the current scale.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#visibleAtCurrentScale">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? VisibleAtCurrentScale { get; protected set; }
    
    /// <summary>
    ///     When `true`, the layer is visible in the view's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html#timeExtent">timeExtent</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#visibleAtCurrentTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? VisibleAtCurrentTimeExtent { get; protected set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the SpatialReferenceSupported property.
    /// </summary>
    public async Task<bool?> GetSpatialReferenceSupported()
    {
        if (CoreJsModule is null)
        {
            return SpatialReferenceSupported;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SpatialReferenceSupported;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "spatialReferenceSupported");
        if (result is not null)
        {
#pragma warning disable BL0005
             SpatialReferenceSupported = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SpatialReferenceSupported)] = SpatialReferenceSupported;
        }
         
        return SpatialReferenceSupported;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Suspended property.
    /// </summary>
    public async Task<bool?> GetSuspended()
    {
        if (CoreJsModule is null)
        {
            return Suspended;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Suspended;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "suspended");
        if (result is not null)
        {
#pragma warning disable BL0005
             Suspended = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Suspended)] = Suspended;
        }
         
        return Suspended;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Updating property.
    /// </summary>
    public async Task<bool?> GetUpdating()
    {
        if (CoreJsModule is null)
        {
            return Updating;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Updating;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "updating");
        if (result is not null)
        {
#pragma warning disable BL0005
             Updating = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Updating)] = Updating;
        }
         
        return Updating;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the View property.
    /// </summary>
    public async Task<MapView?> GetView()
    {
        if (CoreJsModule is null)
        {
            return View;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return View;
        }

        // get the property value
        MapView? result = await CoreJsModule!.InvokeAsync<MapView?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "view");
        if (result is not null)
        {
#pragma warning disable BL0005
             View = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(View)] = View;
        }
         
        return View;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the VisibleAtCurrentScale property.
    /// </summary>
    public async Task<bool?> GetVisibleAtCurrentScale()
    {
        if (CoreJsModule is null)
        {
            return VisibleAtCurrentScale;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return VisibleAtCurrentScale;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "visibleAtCurrentScale");
        if (result is not null)
        {
#pragma warning disable BL0005
             VisibleAtCurrentScale = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(VisibleAtCurrentScale)] = VisibleAtCurrentScale;
        }
         
        return VisibleAtCurrentScale;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the VisibleAtCurrentTimeExtent property.
    /// </summary>
    public async Task<bool?> GetVisibleAtCurrentTimeExtent()
    {
        if (CoreJsModule is null)
        {
            return VisibleAtCurrentTimeExtent;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return VisibleAtCurrentTimeExtent;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "visibleAtCurrentTimeExtent");
        if (result is not null)
        {
#pragma warning disable BL0005
             VisibleAtCurrentTimeExtent = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(VisibleAtCurrentTimeExtent)] = VisibleAtCurrentTimeExtent;
        }
         
        return VisibleAtCurrentTimeExtent;
    }
    
#endregion




}
