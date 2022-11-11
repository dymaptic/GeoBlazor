using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Events;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;


// ReSharper disable RedundantCast

namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
///     The Top-Level Map Component Container.
///     A MapView displays a 2D view of a Map instance. An instance of MapView must be created to render a Map (along with its operational and base layers) in 2D. To render a map and its layers in 3D, see the documentation for SceneView. For a general overview of views, see View.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">ArcGIS JS API</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/navigation">Sample - Navigation</a>
/// </example>
public partial class MapView : MapComponent
{
    /// <summary>
    ///     A set of key/value application configuration properties, that can be populated from `appsettings.json, environment variables, or other sources. 
    /// </summary>
    [Inject]
    public IConfiguration Configuration { get; set; } = default!;

    /// <summary>
    ///     Represents an instance of a JavaScript runtime to which calls may be dispatched.
    /// </summary>
    [Inject]
    public IJSRuntime JsRuntime { get; set; } = default!;

    /// <summary>
    ///     Inline css styling attribute
    /// </summary>
    [Parameter]
    public string Style { get; set; } = string.Empty;

    /// <summary>
    ///     Inline html/css class selector for applying css
    /// </summary>
    [Parameter]
    public string Class { get; set; } = string.Empty;

    /// <summary>
    ///     The Latitude for the Center point of the view
    /// </summary>
    [Parameter]
    public double Latitude
    {
        get => _latitude;
        set
        {
            if (Math.Abs(_latitude - value) > 0.0000000000001)
            {
                _latitude = value;
                NewPropertyValues[nameof(Latitude)] = value;
            }
        }
    }

    /// <summary>
    ///     The Longitude for the Center point of the view
    /// </summary>
    [Parameter]
    public double Longitude
    {
        get => _longitude;
        set
        {
            if (Math.Abs(_longitude - value) > 0.0000000000001)
            {
                _longitude = value;
                NewPropertyValues[nameof(Longitude)] = value;
            }
        }
    }

    /// <summary>
    ///     Represents the level of detail (LOD) at the center of the view.
    /// </summary>
    [Parameter]
    public double Zoom
    {
        get => _zoom;
        set
        {
            if (Math.Abs(_zoom - value) > 0.0000000000001)
            {
                _zoom = value;
                NewPropertyValues[nameof(Zoom)] = value;
            }
        }
    }

    /// <summary>
    ///     Represents the map scale at the center of the view.
    /// </summary>
    [Parameter]
    public double? Scale
    {
        get => _scale;
        set
        {
            if (_scale is null || value is null || (Math.Abs(_scale!.Value - value.Value) > 0.0000000000001))
            {
                _scale = value;

                if (value is not null)
                {
                    NewPropertyValues[nameof(Scale)] = value;
                }
            }
        }
    }

    /// <summary>
    ///     The clockwise rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    public double Rotation
    {
        get => _rotation;
        set
        {
            if (Math.Abs(_rotation - value) > 0.0000000000001)
            {
                _rotation = value;
                NewPropertyValues[nameof(Rotation)] = value;
            }
        }
    }
    
    /// <summary>
    ///     Allows maps to be rendered without an Api or OAuth Token, which will trigger a default esri login popup.
    /// </summary>
    [Parameter]
    public bool? AllowDefaultEsriLogin { get; set; }

#region EventHandlers

    /// <summary>
    ///     Surfaces JavaScript errors to the .NET Code for debugging.
    /// </summary>
    /// <param name="error">
    ///     The original Javascript error.
    /// </param>
    /// <exception cref="JavascriptException">
    ///     Wraps the JS Error and throws a .NET Exception.
    /// </exception>
    [JSInvokable]
    public void OnJavascriptError(JavascriptError error)
    {
#if DEBUG
        ErrorMessage = error.Message.Replace("\n", "<br>");
        StateHasChanged();
#endif
        var exception = new JavascriptException(error);

        if (OnJavascriptErrorHandler is not null)
        {
            OnJavascriptErrorHandler?.Invoke(exception);
        }
        else
        {
            throw exception;
        }
    }
    
    /// <summary>
    ///     Implement this handler in your calling code to catch and handle Javascript errors.
    /// </summary>
    [Parameter]
    public Func<JavascriptException, Task>? OnJavascriptErrorHandler { get; set; } 

    /// <summary>
    ///     JS-Invokable method to return view clicks.
    /// </summary>
    /// <param name="clickEvent">
    ///     The <see cref="ClickEvent"/> return meta object.
    /// </param>
    /// <remarks>
    ///     Fires after a user clicks on the view. This event emits slightly slower than an immediate-click event to make sure that a double-click event isn't triggered instead. The immediate-click event can be used for responding to a click event without delay.
    /// </remarks>
    [JSInvokable]
    public async Task OnJavascriptClick(ClickEvent clickEvent)
    {
#pragma warning disable CS0618
        OnClickAsyncHandler?.Invoke(clickEvent.MapPoint);
#pragma warning restore CS0618
        await OnClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Handler delegate for click events on the view. Must take in a <see cref="Point"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     <b style="color: red">OBSOLETE: Use OnClick EventCallback instead</b>
    /// </remarks>
    [Parameter]
    [Obsolete("Use OnClick EventCallback instead.")]
    public Func<Point, Task>? OnClickAsyncHandler { get; set; } // TODO: Remove for V2.0.0 release
    
    /// <summary>
    ///     Handler delegate for click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnClick { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view double-clicks.
    /// </summary>
    /// <param name="clickEvent">
    ///     The <see cref="ClickEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptDoubleClick(ClickEvent clickEvent)
    {
        await OnDoubleClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Handler delegate for double-click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnDoubleClick { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view immediate-clicks.
    /// </summary>
    /// <param name="clickEvent">
    ///     The <see cref="ClickEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptImmediateClick(ClickEvent clickEvent)
    {
        await OnImmediateClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Handler delegate for immediate-click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnImmediateClick { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view immediate-double-clicks.
    /// </summary>
    /// <param name="clickEvent">
    ///     The <see cref="ClickEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptImmediateDoubleClick(ClickEvent clickEvent)
    {
        await OnImmediateDoubleClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Handler delegate for immediate-double-click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnImmediateDoubleClick { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view hold events.
    /// </summary>
    /// <param name="holdEvent">
    ///     The <see cref="ClickEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptHold(ClickEvent holdEvent)
    {
        await OnHold.InvokeAsync(holdEvent);
    }
    
    /// <summary>
    ///     Handler delegate for hold events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnHold { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view blur (lost focus) events.
    /// </summary>
    /// <param name="blurEvent">
    ///     The <see cref="BlurEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptBlur(BlurEvent blurEvent)
    {
        await OnBlur.InvokeAsync(blurEvent);
    }
    
    /// <summary>
    ///     Handler delegate for blur (lost focus) events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<BlurEvent> OnBlur { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view focus events.
    /// </summary>
    /// <param name="focusEvent">
    ///     The <see cref="FocusEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptFocus(FocusEvent focusEvent)
    {
        await OnFocus.InvokeAsync(focusEvent);
    }
    
    /// <summary>
    ///     Handler delegate for focus events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<FocusEvent> OnFocus { get; set; }

    /// <summary>
    ///     JS-Invokable method to return view drag events.
    /// </summary>
    /// <param name="dragEvent">
    ///     The <see cref="DragEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptDrag(DragEvent dragEvent)
    {
        await OnDrag.InvokeAsync(dragEvent);
    }

    /// <summary>
    ///     Handler delegate for pointer drag events on the view, returns a <see cref="DragEvent"/>.
    /// </summary>
    /// <remarks>
    ///     The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.
    ///     In this scenario, you should write a custom JavaScript handler instead.
    /// </remarks>
    [Parameter]
    public EventCallback<DragEvent> OnDrag { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view pointer down events.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerDown(PointerEvent pointerEvent)
    {
        await OnPointerDown.InvokeAsync(pointerEvent);
    }
    
    /// <summary>
    ///     Handler delegate for pointer down events on the view.
    /// </summary>
    /// <remarks>
    ///     Fires after a mouse button is pressed, or a finger touches the display.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerDown { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view pointer enter events.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerEnter(PointerEvent pointerEvent)
    {
        await OnPointerEnter.InvokeAsync(pointerEvent);
    }
    
    /// <summary>
    ///     Handler delegate for pointer enter events on the view.
    /// </summary>
    /// <remarks>
    ///     Fires after a mouse cursor enters the view, or a display touch begins.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerEnter { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view pointer leave events.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerLeave(PointerEvent pointerEvent)
    {
        await OnPointerLeave.InvokeAsync(pointerEvent);
    }
    
    /// <summary>
    ///     Handler delegate for pointer leave events on the view. Must take in a <see cref="Point"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     Fires after a mouse cursor leaves the view, or a display touch ends.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerLeave { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view pointer movement.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerMove(PointerEvent pointerEvent)
    {
        await OnPointerMove.InvokeAsync(pointerEvent);
#pragma warning disable CS0618, BL0005
        OnPointerMoveHandler?.Invoke(new Point{X = pointerEvent.X, Y = pointerEvent.Y});
#pragma warning restore CS0618, BL0005
    }
    
    /// <summary>
    ///     Handler delegate for point move events on the view. Must take in a <see cref="Point"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     Fires after the mouse or a finger on the display moves.
    ///     The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.
    ///     In this scenario, you should write a custom JavaScript handler instead.
    ///     See <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">Display Projection</a> code.
    /// </remarks>
    /// <remarks>
    ///     <b style="color: red">OBSOLETE: Use OnPointerMove EventCallback instead</b>
    /// </remarks>
    [Parameter]
    [Obsolete("Use OnPointerMove instead")]
    public Func<Point, Task>? OnPointerMoveHandler { get; set; } // TODO: Remove for V2.0.0 release
    
    /// <summary>
    ///     Handler delegate for point move events on the view. Must take in a <see cref="Point"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.
    ///     In this scenario, you should write a custom JavaScript handler instead.
    ///     See <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">Display Projection</a> code.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerMove { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view pointer up events.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerUp(PointerEvent pointerEvent)
    {
        await OnPointerUp.InvokeAsync(pointerEvent);
    }
    
    /// <summary>
    ///     Handler delegate for pointer up events on the view. Must take in a <see cref="Point"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     Fires after a mouse button is released, or a display touch ends.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerUp { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view key-down events.
    /// </summary>
    /// <param name="keyDownEvent">
    ///     The <see cref="KeyDownEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptKeyDown(KeyDownEvent keyDownEvent)
    {
        await OnKeyDown.InvokeAsync(keyDownEvent);
    }
    
    /// <summary>
    ///     Handler delegate for key-down events on the view. 
    /// </summary>
    /// <remarks>
    ///     Fires after a keyboard key is pressed.
    /// </remarks>
    [Parameter]
    public EventCallback<KeyDownEvent> OnKeyDown { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return view key-up events.
    /// </summary>
    /// <param name="keyUpEvent">
    ///     The <see cref="KeyUpEvent"/> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptKeyUp(KeyUpEvent keyUpEvent)
    {
        await OnKeyUp.InvokeAsync(keyUpEvent);
    }
    
    /// <summary>
    ///     Handler delegate for key-up events on the view. 
    /// </summary>
    /// <remarks>
    ///     Fires after a keyboard key is released.
    /// </remarks>
    [Parameter]
    public EventCallback<KeyUpEvent> OnKeyUp { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view is fully rendered.
    /// </summary>
    [JSInvokable]
    public async Task OnViewRendered()
    {
#pragma warning disable CS0618
        OnMapRenderedHandler?.Invoke();
#pragma warning restore CS0618
        await OnMapRendered.InvokeAsync();
    }
    
    /// <summary>
    ///     Handler delegate for when the map view is fully rendered. Must return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     <b style="color: red">OBSOLETE: Use OnMapRendered EventCallback instead</b>
    /// </remarks>
    [Parameter]
    [Obsolete("Use OnMapRendered instead")]
    public Func<Task>? OnMapRenderedHandler { get; set; } // TODO: Remove for V2.0.0 release
    
    /// <summary>
    ///     Handler delegate for when the map view is fully rendered. Must return a <see cref="Task"/>.
    /// </summary>
    [Parameter]
    public EventCallback OnMapRendered { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view Spatial Reference changes.
    /// </summary>
    /// <param name="spatialReference">
    ///     The new <see cref="SpatialReference"/>
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptSpatialReferenceChanged(SpatialReference spatialReference)
    {
        _spatialReference = spatialReference;
        await OnSpatialReferenceChanged.InvokeAsync(spatialReference);
#pragma warning disable CS0618
        OnSpatialReferenceChangedHandler?.Invoke(spatialReference);
#pragma warning restore CS0618
    }
    
    /// <summary>
    ///     Handler delegate for the view's Spatial Reference changing.
    ///     Must take in a <see cref="SpatialReference"/> and return a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    ///     <b style="color: red">OBSOLETE: Use OnSpatialReferenceChanged instead</b>
    /// </remarks>
    [Parameter]
    [Obsolete("Use OnSpatialReferenceChanged instead")]
    public Func<SpatialReference, Task>? OnSpatialReferenceChangedHandler { get; set; } // TODO: Remove for V2.0.0 release
    
    /// <summary>
    ///     Handler delegate for the view's Spatial Reference changing.
    /// </summary>
    [Parameter]
    public EventCallback<SpatialReference> OnSpatialReferenceChanged { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return when the map view Extent changes.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptExtentChanged(Extent extent)
    {
        Extent = extent;
        await OnExtentChanged.InvokeAsync(extent);
    }
    
    /// <summary>
    ///     Handler delegate for the view's Extent changing.
    /// </summary>
    [Parameter]
    public EventCallback<Extent> OnExtentChanged { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view is resized in the window.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptResize(ResizeEvent resizeEvent)
    {
        await OnResize.InvokeAsync(resizeEvent);
    }
    
    /// <summary>
    ///     Handler delegate for the view's Extent changing.
    /// </summary>
    [Parameter]
    public EventCallback<ResizeEvent> OnResize { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the mouse wheel is scrolled.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptMouseWheel(MouseWheelEvent mouseWheelEvent)
    {
        await OnMouseWheel.InvokeAsync(mouseWheelEvent);
    }
    
    /// <summary>
    ///     Handler delegate for the view's Extent changing.
    /// </summary>
    [Parameter]
    public EventCallback<MouseWheelEvent> OnMouseWheel { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when a layer view is created.
    /// </summary>
    /// <param name="layerViewCreateEvent">
    ///     The new <see cref="LayerViewCreateEvent"/>
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptLayerViewCreate(LayerViewCreateEvent layerViewCreateEvent)
    {
        await OnLayerViewCreate.InvokeAsync(layerViewCreateEvent);
    }
    
    /// <summary>
    ///     Fires after each layer in the map has a corresponding LayerView created and rendered in the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewCreateEvent> OnLayerViewCreate { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return when a layer view is destroyed.
    /// </summary>
    /// <param name="layerViewDestroyEvent">
    ///     The destroyed <see cref="LayerViewDestroyEvent"/>
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptLayerViewDestroy(LayerViewDestroyEvent layerViewDestroyEvent)
    {
        await OnLayerViewDestroy.InvokeAsync(layerViewDestroyEvent);
    }
    
    /// <summary>
    ///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewDestroyEvent> OnLayerViewDestroy { get; set; }
    
    /// <summary>
    ///     JS-Invokable method to return when a layer view is destroyed.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptLayerViewCreateError(LayerViewCreateErrorEvent errorEvent)
    {
        await OnLayerViewCreateError.InvokeAsync(errorEvent);
    }
    
    /// <summary>
    ///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewCreateErrorEvent> OnLayerViewCreateError { get; set; }
    
    /// <summary>
    ///     Set this parameter to limit the rate at which recurring events are returned. Applies to <see cref="OnDrag" />, <see cref="OnPointerMove"/>, <see cref="OnMouseWheel"/>, <see cref="OnResize"/>, and <see cref="OnExtentChanged"/>
    /// </summary>
    [Parameter]
    public int? EventRateLimitInMilliseconds { get; set; }

#endregion
    
    /// <summary>
    ///     The collection of <see cref="Widget"/>s in the view.
    /// </summary>
    public HashSet<Widget> Widgets { get; set; } = new();
    
    /// <summary>
    ///     The collection of <see cref="Graphic"/>s in the view. These are directly on the view itself, not in a <see cref="GraphicsLayer"/>.
    /// </summary>
    public List<Graphic> Graphics { get; set; } = new();

    /// <summary>
    ///     An instance of a <see cref="Map"/> object to display in the view.
    /// </summary>
    [RequiredProperty(nameof(WebMap), nameof(SceneView.WebScene))]
    public Map? Map { get; set; }

    /// <summary>
    ///     An instance of a <see cref="WebMap"/> object to display in the view.
    /// </summary>
    [RequiredProperty(nameof(Map), nameof(SceneView.WebScene))]
    public WebMap? WebMap { get; set; }
    
    /// <summary>
    ///     The extent represents the visible portion of a map within the view as an instance of Extent.
    /// </summary>
    public Extent? Extent { get; set; }

    /// <summary>
    ///     The <see cref="SpatialReference"/> of the view.
    /// </summary>
    public SpatialReference? SpatialReference
    {
        get => _spatialReference;
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_spatialReference?.Wkid != value?.Wkid)
            {
                _spatialReference = value;
                NeedsRender = true;
            }
        }
    }
    
    /// <summary>
    ///     Specifies constraints to scale, zoom, and rotation that may be applied to the MapView.
    /// </summary>
    public Constraints? Constraints { get; set; }

    /// <summary>
    ///     Surfaces errors to the UI for easy debugging of issues.
    /// </summary>
    public string? ErrorMessage { get; set; }
    
    /// <summary>
    ///     The ArcGIS Api Token/Key or OAuth Token
    /// </summary>
    protected string? ApiKey
    {
        get => _apiKey;
        set
        {
            _apiKey = value;

            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                Configuration["ArcGISApiKey"] = value;
            }
        }
    }
    
    /// <summary>
    ///     A .NET Object Reference to this view for use in JavaScript calls.
    /// </summary>
    protected DotNetObjectReference<MapView> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

    /// <inheritdoc />
    public override void Refresh()
    {
        NeedsRender = true;
        StateHasChanged();
    }

    /// <inheritdoc />
    public override async Task UpdateComponent()
    {
        if (!MapRendered)
        {
            return;
        }

        foreach (KeyValuePair<string, object> kvp in NewPropertyValues)
        {
            await ViewJsModule!.InvokeVoidAsync("updateView", kvp.Key, kvp.Value, Id);
        }

        NewPropertyValues.Clear();
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Map m:
                if (!m.Equals(Map))
                {
                    Map = m;
                    await RenderView();
                }

                break;
            case WebMap webMap:
                if (!webMap.Equals(WebMap))
                {
                    WebMap = webMap;
                    await RenderView();
                }

                break;
            case Widget widget:
                if (!Widgets.Contains(widget))
                {
                    Widgets.Add(widget);
                    widget.Parent ??= this;
                    await AddWidget(widget);
                }

                break;
            case Graphic graphic:
                if (!Graphics.Contains(graphic))
                {
                    graphic.GraphicIndex = Graphics.Count;
                    Graphics.Add(graphic);
                    await AddGraphic(graphic);
                }

                break;
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                    await UpdateComponent();
                }

                break;
            case Constraints constraints:
                if (!constraints.Equals(Constraints))
                {
                    Constraints = constraints;
                    await UpdateComponent();
                }

                break;
            case Extent extent:
                if (!extent.Equals(Extent))
                {
                    Extent = extent;
                    await UpdateComponent();
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Map _:
                Map = null;
                await UpdateComponent();

                break;
            case WebMap _:
                WebMap = null;
                await UpdateComponent();

                break;
            case Widget widget:
                if (Widgets.Contains(widget))
                {
                    Widgets.Remove(widget);

                    if (MapRendered)
                    {
                        await RemoveWidget(widget);
                    }
                }

                break;
            case Graphic graphic:
                if (Graphics.Contains(graphic))
                {
                    Graphics.Remove(graphic);

                    if (MapRendered)
                    {
                        await RemoveGraphicAtIndex(graphic.GraphicIndex!.Value);
                    }
                }

                break;
            case Constraints _:
                Constraints = null;
                await UpdateComponent();

                break;
            case SpatialReference _:
                SpatialReference = null;
                await UpdateComponent();

                break;
            case Extent _:
                Extent = null;
                await UpdateComponent();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Map?.ValidateRequiredChildren();
        WebMap?.ValidateRequiredChildren();
        Constraints?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
        Extent?.ValidateRequiredChildren();

        foreach (Graphic graphic in Graphics)
        {
            graphic.ValidateRequiredChildren();
        }

        foreach (Widget widget in Widgets)
        {
            widget.ValidateRequiredChildren();
        }
    }

    /// <summary>
    ///     A custom method to query a provided <see cref="FeatureLayer"/> on the current map view, and display the results.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="Query"/> to run.
    /// </param>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> to query against.
    /// </param>
    /// <param name="displaySymbol">
    ///     The <see cref="Symbol"/> to use to render the results of the query.
    /// </param>
    /// <param name="popupTemplate">
    ///     A <see cref="PopupTemplate"/> for displaying Popups on rendered results.
    /// </param>
    public async Task QueryFeatures(Query query, FeatureLayer featureLayer, Symbol displaySymbol,
        PopupTemplate popupTemplate)
    {
        await ViewJsModule!.InvokeVoidAsync("queryFeatureLayer", (object)query,
            (object)featureLayer, (object)displaySymbol, (object)popupTemplate, Id);
    }

    /// <summary>
    ///     A custom method to run an <see cref="AddressQuery"/> against the current view, and display the results.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="AddressQuery"/> to run.
    /// </param>
    /// <param name="displaySymbol">
    ///     The <see cref="Symbol"/> to use to render the results of the query.
    /// </param>
    /// <param name="popupTemplate">
    ///     A <see cref="PopupTemplate"/> for displaying Popups on rendered results.
    /// </param>
    public async Task FindPlaces(AddressQuery query, Symbol displaySymbol, PopupTemplate popupTemplate)
    {
        await ViewJsModule!.InvokeVoidAsync("findPlaces", (object)query,
            (object)displaySymbol, (object)popupTemplate, Id);
    }

    /// <summary>
    ///     Opens a Popup on a particular <see cref="Point"/> of the map view.
    /// </summary>
    /// <param name="template">
    ///     The <see cref="PopupTemplate"/> defining the Popup.
    /// </param>
    /// <param name="location">
    ///     The <see cref="Point"/> on which to display the Popup.
    /// </param>
    public async Task ShowPopup(PopupTemplate template, Point location)
    {
        await ViewJsModule!.InvokeVoidAsync("showPopup", (object)template,
            (object)location, Id);
    }

    /// <summary>
    ///     Opens a Popup with a custom <see cref="Graphic"/> on a particular <see cref="Point"/> of the map view.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic"/> to display in the Popup
    /// </param>
    /// <param name="options">
    ///     A set of <see cref="PopupOptions"/> that define the position and visible elements of the Popup.
    /// </param>
    public async Task ShowPopupWithGraphic(Graphic graphic, PopupOptions options)
    {
        await ViewJsModule!.InvokeVoidAsync("showPopupWithGraphic", (object)graphic, 
            (object)options, Id);
    }

    /// <summary>
    ///     Adds a <see cref="Graphic"/> to the current view, or to a <see cref="GraphicsLayer"/>.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic"/> to add.
    /// </param>
    /// <param name="layerIndex">
    ///     An optional index, that determines which <see cref="GraphicsLayer"/> to add the graphic to. If omitted, the graphic will be placed directly on the view.
    /// </param>
    public async Task AddGraphic(Graphic graphic, int? layerIndex = null)
    {
        if (ViewJsModule is null) return;
        await ViewJsModule!.InvokeVoidAsync("addGraphic", (object)graphic, Id, layerIndex);
    }

    /// <summary>
    ///     Clears all graphics from the view.
    /// </summary>
    public async Task ClearGraphics()
    {
        await ViewJsModule!.InvokeVoidAsync("clearViewGraphics", Id);
    }
    
    /// <summary>
    ///     A custom method to set up the interaction for clicking a start and end point, and have the view render a driving route. Also returns a set of <see cref="Direction"/>s for display.
    /// </summary>
    /// <param name="routeSymbol">
    ///     The <see cref="Symbol"/> used to render the route.
    /// </param>
    /// <param name="routeUrl">
    ///     A routing service url for calculating the route.
    /// </param>
    /// <returns>
    ///     A collection of <see cref="Direction"/> steps to follow the route.
    /// </returns>
    public async Task<Direction[]> DrawRouteAndGetDirections(Symbol routeSymbol, string routeUrl)
    {
        return await ViewJsModule!.InvokeAsync<Direction[]?>("drawRouteAndGetDirections",
            routeUrl, (object)routeSymbol, Id) ?? Array.Empty<Direction>();
    }

    /// <summary>
    ///     A custom method to find and display Service Areas around a given point.
    /// </summary>
    /// <param name="serviceAreaUrl">
    ///     A url for a Service Area rest service.
    /// </param>
    /// <param name="driveTimeCutOffs">
    ///     A collection of drivable distances, calculated in minutes
    /// </param>
    /// <param name="serviceAreaSymbol">
    ///     The <see cref="Symbol"/> used to render the service areas.
    /// </param>
    public async Task SolveServiceArea(string serviceAreaUrl, double[] driveTimeCutOffs, Symbol serviceAreaSymbol)
    {
        await ViewJsModule!.InvokeVoidAsync("solveServiceArea",
            serviceAreaUrl, driveTimeCutOffs, serviceAreaSymbol, Id);
    }

    /// <summary>
    ///     Returns all graphics for the view, or for a particular <see cref="GraphicsLayer"/>.
    /// </summary>
    /// <param name="layerIndex">
    ///     Optional <see cref="GraphicsLayer"/> index. If not provided, this will return the graphics from the view itself.
    /// </param>
    /// <returns>
    ///     A collection of <see cref="Graphic"/>s.
    /// </returns>
    public async Task<Graphic[]> GetAllGraphics(int? layerIndex)
    {
        return await ViewJsModule!.InvokeAsync<Graphic[]>("getAllGraphics", layerIndex, Id);
    }

    /// <summary>
    ///     Removes a graphic based on the graphic index and optional layer index.
    /// </summary>
    /// <param name="index">
    ///     Within the layer or view, the position of the graphic to be removed in the collection.
    /// </param>
    /// <param name="layerIndex">
    ///     Optional layer index. If omitted, will remove the graphic from the view itself.
    /// </param>
    public async Task RemoveGraphicAtIndex(int index, int? layerIndex = null)
    {
        await ViewJsModule!.InvokeVoidAsync("removeGraphicAtIndex", index, layerIndex, Id);
    }

    /// <summary>
    ///     Removes a collection of graphics based on index.
    /// </summary>
    /// <param name="indexes">
    ///     Within the layer or view, remove all graphics at these indexes in the collection.
    /// </param>
    /// <param name="layerIndex">
    ///     Optional layer index. If omitted, will remove the graphics from the view itself.
    /// </param>
    public async Task RemoveGraphicsAtIndexes(int[] indexes, int? layerIndex = null)
    {
        await ViewJsModule!.InvokeVoidAsync("removeGraphicsAtIndexes", indexes, layerIndex, Id);
    }

    /// <summary>
    ///     Redraws a particular graphic.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic"/> to redraw.
    /// </param>
    /// <param name="layerIndex">
    ///     Optional layer index. If omitted, will look for the graphic on the view itself.
    /// </param>
    public async Task UpdateGraphic(Graphic graphic, int? layerIndex)
    {
        await ViewJsModule!.InvokeVoidAsync("updateGraphic", (object)graphic, layerIndex, Id);
    }

    /// <summary>
    ///     Returns the center <see cref="Point"/> of the current view extent.
    /// </summary>
    public async Task<Point?> GetCenter()
    {
        if (ViewJsModule is null) return null;
        return await ViewJsModule!.InvokeAsync<Point>("getCenter", Id);
    }

    /// <summary>
    ///     Returns the current <see cref="Extent"/> of the view.
    /// </summary>
    public async Task<Extent?> GetExtent()
    {
        if (ViewJsModule is null) return null;
        return await ViewJsModule!.InvokeAsync<Extent?>("getExtent", Id);
    }

    /// <summary>
    ///     Returns the current <see cref="SpatialReference"/> of the view.
    /// </summary>
    public async Task<SpatialReference?> GetSpatialReference()
    {
        if (ViewJsModule is null) return null;

        return await ViewJsModule!.InvokeAsync<SpatialReference?>("getSpatialReference", Id);
    }

    /// <summary>
    ///     Changes the view <see cref="Extent"/> and redraws.
    /// </summary>
    /// <param name="extent">
    ///     The new <see cref="Extent"/> of the view.
    /// </param>
    public async Task GoTo(Extent extent)
    {
        if (ViewJsModule is null) return;

        await ViewJsModule!.InvokeVoidAsync("goToExtent", extent, Id);
    }

    /// <inheritdoc />
    public override async ValueTask DisposeAsync()
    {
        try
        {
            if (ViewJsModule != null) await ViewJsModule.InvokeVoidAsync("disposeView", Id);
        }
        catch (JSDisconnectedException)
        {
            // ignore, dispose is called by Blazor too early
        }
    }

    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        ApiKey = Configuration["ArcGISApiKey"];

        if (AllowDefaultEsriLogin is null)
        {
            string? setting = Configuration["AllowDefaultEsriLogin"];

            if (setting is not null && bool.TryParse(setting, out var allow))
            {
                AllowDefaultEsriLogin = allow;
            }
        }
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            LicenseType licenseType = Licensing.GetLicenseType();
            
            switch ((int)licenseType)
            {
                case >= 100:
                    // this is here to support the interactive extension library
                    IJSObjectReference interactiveModule = await JsRuntime
                        .InvokeAsync<IJSObjectReference>("import",
                            "./_content/dymaptic.GeoBlazor.Interactive/js/arcGisInteractive.js");
                    ViewJsModule = await interactiveModule.InvokeAsync<IJSObjectReference>("getCore");

                    break;
                default:
                    ViewJsModule = await JsRuntime
                        .InvokeAsync<IJSObjectReference>("import",
                            "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");

                    break;
            }
            
            JsModule = ViewJsModule;
            // the first render never has all the child components registered
            Rendering = false;
            StateHasChanged();

            return;
        }

        if (NeedsRender)
        {
            await RenderView();
        }
        else if (NewPropertyValues.Any())
        {
            await UpdateComponent();
        }
    }

    /// <inheritdoc />
    protected override async Task RenderView(bool forceRender = false)
    {
        if (!NeedsRender && !forceRender)
        {
            return;
        }

        if (Rendering || (Map is null && WebMap is null) || ViewJsModule is null) return;

        if (string.IsNullOrWhiteSpace(ApiKey) && (AllowDefaultEsriLogin is null || !AllowDefaultEsriLogin.Value))
        {
            ErrorMessage = "No ArcGIS API Key Found. See UsingTheAPI.md for instructions on providing an API Key or suppressing this message.";
            System.Diagnostics.Debug.WriteLine(ErrorMessage);
            StateHasChanged();

            return;
        }

        Rendering = true;
        ValidateRequiredChildren();

        await InvokeAsync(async () =>
        {
            Console.WriteLine("Rendering View");
            string mapType = Map is null ? "webmap" : "map";
            object? map = Map is null ? WebMap : Map;

            if (map is null)
            {
                throw new MissingMapException();
            }

            NeedsRender = false;

            await ViewJsModule!.InvokeVoidAsync("buildMapView", Id,
                DotNetObjectReference, Longitude, Latitude, Rotation, map, Zoom, Scale,
                ApiKey, mapType, Widgets, Graphics, SpatialReference, Constraints, Extent,
                EventRateLimitInMilliseconds, GetActiveEventHandlers());
            Rendering = false;
            NewPropertyValues.Clear();
            MapRendered = true;
        });
    }

    private async Task AddWidget(Widget widget)
    {
        if (ViewJsModule is null) return;
        await InvokeAsync(async () =>
        {
            await ViewJsModule!.InvokeVoidAsync("addWidget", widget, Id);
        });
    }
    
    private async Task RemoveWidget(Widget widget)
    {
        await InvokeAsync(async () =>
        {
            await ViewJsModule!.InvokeVoidAsync("removeWidget", widget.Id, Id);
        });
    }

    /// <summary>
    ///     Retrieves all <see cref="EventCallback"/>s and <see cref="Func{TResult}"/>s that are listening for JavaScript events.
    /// </summary>
    protected List<string> GetActiveEventHandlers()
    {
        List<string> activeHandlers = new();
        IEnumerable<PropertyInfo> callbacks = this.GetType().GetProperties()
            .Where(p => p.PropertyType.Name.StartsWith(nameof(EventCallback)) ||
                p.PropertyType.Name.StartsWith("Func"));

        foreach (PropertyInfo callbackInfo in callbacks)
        {
            dynamic? callback = callbackInfo.GetValue(this);

            if (callback is not null && callback.HasDelegate)
            {
                activeHandlers.Add(callbackInfo.Name);
            }
        }

        return activeHandlers;
    }

    /// <summary>
    ///     A reference to the arcGisJsInterop module
    /// </summary>
    protected IJSObjectReference? ViewJsModule;
    
    /// <summary>
    ///     A boolean flag to indicate that rendering is underway
    /// </summary>
    protected bool Rendering;
    
    /// <summary>
    ///     Tracked properties that need to be updated.
    /// </summary>
    protected readonly Dictionary<string, object> NewPropertyValues = new();

    /// <summary>
    ///     A boolean flag to indicate a "dirty" state that needs to be re-rendered
    /// </summary>
    protected bool NeedsRender = true;
    private double _longitude = -118.805;
    private double _zoom = 11;
    private double? _scale;
    private double _rotation;
    private double _latitude = 34.027;
    private string? _apiKey;
    private SpatialReference? _spatialReference;
}