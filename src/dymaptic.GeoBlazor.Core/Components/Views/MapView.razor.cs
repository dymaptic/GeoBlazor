﻿using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Events;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using ProtoBuf;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;


// ReSharper disable RedundantCast

namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
///     The Top-Level Map Component Container.
///     A MapView displays a 2D view of a Map instance. An instance of MapView must be created to render a Map (along with
///     its operational and base layers) in 2D. To render a map and its layers in 3D, see the documentation for SceneView.
///     For a general overview of views, see View.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/navigation">Sample - Navigation</a>
/// </example>
public partial class MapView : MapComponent
{
#region Injected Services
    /// <summary>
    ///     A set of key/value application configuration properties, that can be populated from `appsettings.json, environment
    ///     variables, or other sources.
    /// </summary>
    [Inject]
    public IConfiguration Configuration { get; set; } = default!;

    /// <summary>
    ///     Handles OAuth authentication
    /// </summary>
    [Inject]
    public AuthenticationManager AuthenticationManager { get; set; } = default!;

    /// <summary>
    ///     Validates GeoBlazor Registration or Pro Licensing
    /// </summary>
    [Inject]
    private IAppValidator AppValidator { get; set; } = default!;
#endregion
    


#region Parameters

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
    public double? Latitude { get; set; }

    /// <summary>
    ///     The Longitude for the Center point of the view
    /// </summary>
    [Parameter]
    public double? Longitude { get; set; }

#pragma warning disable BL0007
    /// <summary>
    ///     The Center point of the view, equivalent to setting Latitude/Longitude
    /// </summary>
    [Parameter]
    public Point? Center
    {
        get => Longitude is null || Latitude is null ? null : new Point(Longitude, Latitude);
        set
        {
            Longitude = value?.Longitude;
            Latitude = value?.Latitude;
        }
    }
#pragma warning restore BL0007

    /// <summary>
    ///     Represents the level of detail (LOD) at the center of the view.
    /// </summary>
    [Parameter]
    public double? Zoom { get; set; }

    /// <summary>
    ///     Represents the map scale at the center of the view.
    /// </summary>
    [Parameter]
    public double? Scale { get; set; }

    /// <summary>
    ///     The clockwise rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    public double Rotation { get; set; }

    /// <summary>
    ///     Allows maps to be rendered without an Api or OAuth Token, which will trigger a default esri login popup.
    /// </summary>
    [Parameter]
    public bool? AllowDefaultEsriLogin { get; set; }

    /// <summary>
    ///     Boolean flag that can be set to false to prevent the MapView from automatically rendering with the Blazor
    ///     components.
    /// </summary>
    [Parameter]
    public bool LoadOnRender { get; set; } = true;

    /// <summary>
    ///     Provides an override for the default behavior of requiring an API key. By setting to "false", all calls to ArcGIS
    ///     services will trigger a sign-in popup.
    /// </summary>
    /// <remarks>
    ///     Setting this to "false" is the same as setting <see cref="AllowDefaultEsriLogin" /> to "true". This is provided
    ///     simply for convenience of discovery.
    /// </remarks>
    [Parameter]
    public bool? PromptForArcGISKey { get; set; }

    /// <summary>
    ///     If you set an `AppId` in your configuration, setting this to true will cause the app to attempt to auto-login
    ///     using ArcGIS OAuth.
    /// </summary>
    [Parameter]
    public bool? PromptForOAuthLogin { get; set; }
    
    [Parameter]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public string? WhiteLabel { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#endregion


#region Public Properties

    /// <summary>
    ///     The collection of <see cref="Widget" />s in the view.
    /// </summary>
    public IReadOnlyCollection<Widget> Widgets
    {
        get => _widgets;
        private set => _widgets = new HashSet<Widget>(value);
    }

    /// <summary>
    ///     The collection of <see cref="Graphic" />s in the view. These are directly on the view itself, not in a
    ///     <see cref="GraphicsLayer" />.
    /// </summary>
    public IReadOnlyCollection<Graphic> Graphics
    {
        get => _graphics;
        private set => _graphics = new HashSet<Graphic>(value);
    }

    /// <summary>
    ///     An instance of a <see cref="Map" /> object to display in the view.
    /// </summary>
    [RequiredProperty]
    public virtual Map? Map { get; private set; }
    
    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </summary>
    public bool IsServer => JsRuntime.GetType().Name.Contains("Remote");

    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor WebAssembly (client) mode
    /// </summary>
    public bool IsWebAssembly => OperatingSystem.IsBrowser();

    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Hybrid (MAUI) mode
    /// </summary>
    public bool IsMaui => JsRuntime.GetType().Name.Contains("WebView");
    
    /// <summary>
    ///     A boolean flag to indicate that the map extent has been modified in JavaScript, and therefore should not be
    ///     modifiable by markup until <see cref="Refresh" /> is called
    /// </summary>
    public bool ExtentChangedInJs { get; set; }
    
#endregion
    
#region Internal Properties
    /// <summary>
    ///     The extent represents the visible portion of a map within the view as an instance of Extent.
    /// </summary>
    protected Extent? Extent { get; set; }

    /// <summary>
    ///     The <see cref="SpatialReference" /> of the view.
    /// </summary>
    protected SpatialReference? SpatialReference { get; private set; }

    /// <summary>
    ///     Specifies constraints to scale, zoom, and rotation that may be applied to the MapView.
    /// </summary>
    protected Constraints? Constraints { get; private set; }

    /// <summary>
    ///     Surfaces errors to the UI for easy debugging of issues.
    /// </summary>
    protected string? ErrorMessage { get; set; }

    /// <summary>
    ///     Options for configuring the highlight. Use the highlight method on the appropriate LayerView to highlight a
    ///     feature. With version 4.19, highlighting a feature influences the shadow of the feature as well. By default, the
    ///     shadow of the highlighted feature is displayed in a darker shade.
    /// </summary>
    protected HighlightOptions? HighlightOptions { get; private set; }

    /// <summary>
    ///     The ArcGIS Api Token/Key or OAuth Token
    /// </summary>
    protected string? ApiKey
    {
        get => AuthenticationManager.ApiKey;
        set => AuthenticationManager.ApiKey = value;
    }

    /// <summary>
    ///     The ArcGIS AppId for OAuth2 login
    /// </summary>
    protected string? AppId
    {
        get => AuthenticationManager.AppId;
        set => AuthenticationManager.AppId = value;
    }

    /// <summary>
    ///     A .NET Object Reference to this view for use in JavaScript calls.
    /// </summary>
    protected DotNetObjectReference<MapView> DotNetObjectReference =>
        Microsoft.JSInterop.DotNetObjectReference.Create(this);

#endregion


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
        if (_isDisposed) return;
#if DEBUG
        ErrorMessage = error.Message?.Replace("\n", "<br>") ?? error.Stack;
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
    ///     JS-Invokable method to generate a new GUID Id
    /// </summary>
    [JSInvokable]
    public string GetId()
    {
        return Guid.NewGuid().ToString();
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
    ///     The <see cref="ClickEvent" /> return meta object.
    /// </param>
    /// <remarks>
    ///     Fires after a user clicks on the view. This event emits slightly slower than an immediate-click event to make sure
    ///     that a double-click event isn't triggered instead. The immediate-click event can be used for responding to a click
    ///     event without delay.
    /// </remarks>
    [JSInvokable]
    public async Task OnJavascriptClick(ClickEvent clickEvent)
    {
        if (_isDisposed) return;
        await OnClick.InvokeAsync(clickEvent);
    }

    /// <summary>
    ///     Handler delegate for click events on the view.
    /// </summary>
    [Parameter]
    public EventCallback<ClickEvent> OnClick { get; set; }

    /// <summary>
    ///     JS-Invokable method to return view double-clicks.
    /// </summary>
    /// <param name="clickEvent">
    ///     The <see cref="ClickEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptDoubleClick(ClickEvent clickEvent)
    {
        if (_isDisposed) return;
        ExtentChangedInJs = true;
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
    ///     The <see cref="ClickEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptImmediateClick(ClickEvent clickEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="ClickEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptImmediateDoubleClick(ClickEvent clickEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="ClickEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptHold(ClickEvent holdEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="BlurEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptBlur(BlurEvent blurEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="FocusEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptFocus(FocusEvent focusEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="DragEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptDrag(DragEvent dragEvent)
    {
        if (_isDisposed) return;
        ExtentChangedInJs = true;
        await OnDrag.InvokeAsync(dragEvent);
    }

    /// <summary>
    ///     Handler delegate for pointer drag events on the view, returns a <see cref="DragEvent" />.
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
    ///     The <see cref="PointerEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerDown(PointerEvent pointerEvent)
    {
        if (_isDisposed) return;
        PointerDown = true;
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
    ///     The <see cref="PointerEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerEnter(PointerEvent pointerEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="PointerEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerLeave(PointerEvent pointerEvent)
    {
        if (_isDisposed) return;
        await OnPointerLeave.InvokeAsync(pointerEvent);
    }

    /// <summary>
    ///     Handler delegate for pointer leave events on the view. Must take in a <see cref="Point" /> and return a
    ///     <see cref="Task" />.
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
    ///     The <see cref="PointerEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerMove(PointerEvent pointerEvent)
    {
        if (_isDisposed) return;
        await OnPointerMove.InvokeAsync(pointerEvent);
    }

    /// <summary>
    ///     Handler delegate for point move events on the view. Must take in a <see cref="Point" /> and return a
    ///     <see cref="Task" />.
    /// </summary>
    /// <remarks>
    ///     The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.
    ///     In this scenario, you should write a custom JavaScript handler instead.
    ///     See
    ///     <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">
    ///         Display
    ///         Projection
    ///     </a>
    ///     code.
    /// </remarks>
    [Parameter]
    public EventCallback<PointerEvent> OnPointerMove { get; set; }

    /// <summary>
    ///     JS-Invokable method to return view pointer up events.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The <see cref="PointerEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptPointerUp(PointerEvent pointerEvent)
    {
        if (_isDisposed) return;
        PointerDown = false;
        await OnPointerUp.InvokeAsync(pointerEvent);
    }

    /// <summary>
    ///     Handler delegate for pointer up events on the view. Must take in a <see cref="Point" /> and return a
    ///     <see cref="Task" />.
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
    ///     The <see cref="KeyDownEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptKeyDown(KeyDownEvent keyDownEvent)
    {
        if (_isDisposed) return;
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
    ///     The <see cref="KeyUpEvent" /> return meta object.
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptKeyUp(KeyUpEvent keyUpEvent)
    {
        if (_isDisposed) return;
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
    ///     JS-Invokable callback that signifies when the view is created but not yet fully rendered.
    /// </summary>
    [JSInvokable]
    public async Task OnJsViewInitialized()
    {
        if (_isDisposed) return;
        await OnViewInitialized.InvokeAsync();
    }

    /// <summary>
    ///     Event triggered when the JS view is created, but before the full map is rendered.
    /// </summary>
    [Parameter]
    public EventCallback OnViewInitialized { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view is fully rendered.
    /// </summary>
    [JSInvokable]
    public async Task OnJsViewRendered()
    {
        if (_isDisposed) return;
        await OnViewRendered.InvokeAsync(Id);
    }

    /// <summary>
    ///     Handler delegate for when the map view is fully rendered. Must return a <see cref="Task" />.
    /// </summary>
    [Parameter]
    public EventCallback<Guid> OnViewRendered { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view Spatial Reference changes.
    /// </summary>
    /// <param name="spatialReference">
    ///     The new <see cref="SpatialReference" />
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptSpatialReferenceChanged(SpatialReference spatialReference)
    {
        if (_isDisposed) return;
        _spatialReference = spatialReference;
        await OnSpatialReferenceChanged.InvokeAsync(spatialReference);
    }

    /// <summary>
    ///     Handler delegate for the view's Spatial Reference changing.
    /// </summary>
    [Parameter]
    public EventCallback<SpatialReference> OnSpatialReferenceChanged { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when the map view Extent changes.
    /// </summary>
    [JSInvokable]
    public virtual async Task OnJavascriptExtentChanged(Extent extent, Point? center, double zoom, double scale,
        double? rotation = null, double? tilt = null)
    {
        if (_isDisposed) return;
        // if extents are set, but don't match, that means the change was done JS-side
        if (Extent is not null && !extent.Equals(Extent))
        {
            ExtentChangedInJs = true;
        }

        Extent = extent;

        if (center is not null)
        {
            Center = center;
        }

        Zoom = zoom;
        Scale = scale;
        Rotation = rotation ?? Rotation;
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
        if (_isDisposed) return;
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
        if (_isDisposed) return;
        ExtentChangedInJs = true;
        await OnMouseWheel.InvokeAsync(mouseWheelEvent);
    }

    /// <summary>
    ///     Handler delegate for the view's Extent changing.
    /// </summary>
    [Parameter]
    public EventCallback<MouseWheelEvent> OnMouseWheel { get; set; }

    /// <summary>
    ///     JS-Invokable method for internal use only.
    /// </summary>
    [JSInvokable]
    public void OnJavascriptLayerCreateChunk(string layerUid, string chunk, int chunkIndex)
    {
        if (_isDisposed) return;
        if (chunkIndex == 0)
        {
            _layerCreateData[layerUid] = new StringBuilder(chunk);
        }
        else
        {
            _layerCreateData[layerUid].Append(chunk);
        }
    }

    /// <summary>
    ///     JS-Invokable method for internal use only.
    /// </summary>
    [JSInvokable]
    public void OnJavascriptLayerViewCreateChunk(string layerUid, string chunk, int chunkIndex)
    {
        if (_isDisposed) return;
        if (chunkIndex == 0)
        {
            _layerViewCreateData[layerUid] = new StringBuilder(chunk);
        }
        else
        {
            _layerViewCreateData[layerUid].Append(chunk);
        }
    }

    /// <summary>
    ///     JS-Invokable method for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptLayerViewCreateComplete(Guid? geoBlazorLayerId, string layerUid,
        IJSObjectReference layerRef, IJSObjectReference layerViewRef, bool isBasemapLayer)
    {
        if (_isDisposed) return;
        try
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            Layer layer = JsonSerializer.Deserialize<Layer>(_layerCreateData[layerUid].ToString(), options)!;

            LayerView layerView =
                JsonSerializer.Deserialize<LayerView>(_layerViewCreateData[layerUid].ToString(), options)!;

            LayerViewCreateInternalEvent createEvent =
                new(layerRef, layerViewRef, geoBlazorLayerId ?? Guid.Empty, layer,
                    layerView, isBasemapLayer);
            await OnJavascriptLayerViewCreate(createEvent);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    /// <summary>
    ///     JS-Invokable method to return when a layer view is created.
    /// </summary>
    /// <param name="layerViewCreateEvent">
    ///     The new <see cref="LayerViewCreateEvent" />
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent layerViewCreateEvent)
    {
        if (_isDisposed) return;
        LayerView? layerView = layerViewCreateEvent.Layer switch
        {
            FeatureLayer => new FeatureLayerView(layerViewCreateEvent.LayerView!, new AbortManager(JsRuntime)),
            _ => layerViewCreateEvent.LayerView
        };

        if (layerView is not null)
        {
            layerView.JsObjectReference = layerViewCreateEvent.LayerViewObjectRef;
        }

        Layer? createdLayer = layerViewCreateEvent.IsBasemapLayer
            ? Map?.Basemap?.Layers.FirstOrDefault(l => l.Id == layerViewCreateEvent.LayerGeoBlazorId)
            : Map?.Layers.FirstOrDefault(l => l.Id == layerViewCreateEvent.LayerGeoBlazorId);

        if (createdLayer is not null) // layer already exists in C#
        {
            createdLayer.LayerView = layerView;

            createdLayer.JsLayerReference ??= layerViewCreateEvent.LayerObjectRef;

            createdLayer.AbortManager = new AbortManager(JsRuntime);
            await createdLayer.UpdateFromJavaScript(layerViewCreateEvent.Layer!);

            if (layerView is not null)
            {
                layerView.Layer = createdLayer;
            }
        }
        else // this should be a web-hosted layer that came via JS
        {
            Layer? layer = layerViewCreateEvent.Layer;

            if (layer is not null)
            {
                layer.LayerView = layerView;
                layer.AbortManager = new AbortManager(JsRuntime);
                layer.JsLayerReference = layerViewCreateEvent.LayerObjectRef;
                layer.JsModule = ViewJsModule;
                layer.ProJsModule = ProJsViewModule;
                layer.Imported = true;

                if (layerView is not null)
                {
                    layerView.Layer = layer;
                }

                layer.View = this;

                if (layerViewCreateEvent.IsBasemapLayer)
                {
                    if (Map?.Basemap is not null)
                    {
                        Map!.Basemap!.Layers.Add(layer);
                    }
                }
                else
                {
                    if (Map is not null)
                    {
                        Map!.Layers.Add(layer);
                    }
                }
                
                await JsModule!.InvokeVoidAsync("registerGeoBlazorObject", layerViewCreateEvent.LayerObjectRef, layer.Id);
            }
        }

        await OnLayerViewCreate.InvokeAsync(new LayerViewCreateEvent(layerView?.Layer, layerView));
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
    ///     The destroyed <see cref="LayerViewDestroyEvent" />
    /// </param>
    [JSInvokable]
    public async Task OnJavascriptLayerViewDestroy(LayerViewDestroyEvent layerViewDestroyEvent)
    {
        if (_isDisposed) return;
        await OnLayerViewDestroy.InvokeAsync(layerViewDestroyEvent);
    }

    /// <summary>
    ///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer
    ///     is removed from the map of the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewDestroyEvent> OnLayerViewDestroy { get; set; }

    /// <summary>
    ///     JS-Invokable method to return when a layer view is destroyed.
    /// </summary>
    [JSInvokable]
    public async Task OnJavascriptLayerViewCreateError(LayerViewCreateErrorEvent errorEvent)
    {
        if (_isDisposed) return;
        await OnLayerViewCreateError.InvokeAsync(errorEvent);
    }

    /// <summary>
    ///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer
    ///     is removed from the map of the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewCreateErrorEvent> OnLayerViewCreateError { get; set; }

    /// <summary>
    ///     Set this parameter to limit the rate at which recurring events are returned. Applies to <see cref="OnDrag" />,
    ///     <see cref="OnPointerMove" />, <see cref="OnMouseWheel" />, <see cref="OnResize" />, and
    ///     <see cref="OnExtentChanged" />
    /// </summary>
    [Parameter]
    public int? EventRateLimitInMilliseconds { get; set; } = 100;

    /// <summary>
    ///    Optional setting to control the number of graphics that are serialized in a single chunk. Tuning this value might help with performance when adding large graphic sets.
    /// </summary>
    [Parameter]
    public int? GraphicSerializationChunkSize { get; set; }
    
    /// <summary>
    ///     The maximum size of query results that will be returned in a stream. Note that setting this to a smaller
    ///     value might create errors in query returns.
    /// </summary>
    [Parameter]
    public long QueryResultsMaxSizeLimit { get; set; } = 1_000_000_000L;

    /// <summary>
    ///     Controls whether the popup opens when users click on the view.
    ///     When true, a Popup instance is created and assigned to view.popup the first time the user clicks on the view, unless popup is null. The popup then processes the click event.
    ///     When false, the click event is ignored and popup is not created for features but will open for other scenarios that use a popup, such as displaying Search results.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///     For internal use only, this looks up a missing <see cref="DotNetObjectReference"/> for a <see cref="PopupTemplate"/>
    ///     and returns it to JavaScript.
    /// </summary>
    [JSInvokable]
    public DotNetObjectReference<PopupTemplate>? GetDotNetPopupTemplateObjectReference(Guid popupTemplateId)
    {
        if (_isDisposed) return null;
        foreach (Graphic graphic in Graphics)
        {
            if (graphic.PopupTemplate?.Id == popupTemplateId)
            {
                return graphic.PopupTemplate.DotNetPopupTemplateReference;
            }
        }

        foreach (Layer layer in Map!.Layers)
        {
            switch (layer)
            {
                case FeatureLayer featureLayer:
                    if (featureLayer.PopupTemplate?.Id == popupTemplateId)
                    {
                        return featureLayer.PopupTemplate.DotNetPopupTemplateReference;
                    }

                    if (featureLayer.Source is not null)
                    {
                        foreach (Graphic graphic in featureLayer.Source)
                        {
                            if (graphic.PopupTemplate?.Id == popupTemplateId)
                            {
                                return graphic.PopupTemplate.DotNetPopupTemplateReference;
                            }
                        }
                    }

                    break;
                case GraphicsLayer graphicsLayer:
                    foreach (Graphic graphic in graphicsLayer.Graphics)
                    {
                        if (graphic.PopupTemplate?.Id == popupTemplateId)
                        {
                            return graphic.PopupTemplate.DotNetPopupTemplateReference;
                        }
                    }

                    break;
                case IPopupTemplateLayer templateLayer:
                    if (templateLayer.PopupTemplate?.Id == popupTemplateId)
                    {
                        return templateLayer.PopupTemplate.DotNetPopupTemplateReference;
                    }

                    break;
            }
        }

        return null;
    }

#endregion


#region Public Methods

    /// <inheritdoc />
    public override void Refresh()
    {
        NeedsRender = true;
        ExtentSetByCode = false;
        ExtentChangedInJs = false;
        StateHasChanged();
    }

    /// <summary>
    ///     Manually loads and renders the MapView, if the consumer has also set <see cref="LoadOnRender" /> to false.
    ///     If <see cref="LoadOnRender" /> is true, this method will function the same as <see cref="Refresh" />.
    /// </summary>
    public void Load()
    {
        _renderCalled = true;
        NeedsRender = true;
        StateHasChanged();
    }

    /// <summary>
    ///     A custom method to query a provided <see cref="FeatureLayer" /> on the current map view, and display the results.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="Query" /> to run.
    /// </param>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer" /> to query against.
    /// </param>
    /// <param name="displaySymbol">
    ///     The <see cref="Symbol" /> to use to render the results of the query.
    /// </param>
    /// <param name="popupTemplate">
    ///     A <see cref="PopupTemplate" /> for displaying Popups on rendered results.
    /// </param>
    public async Task QueryFeatures(Query query, FeatureLayer featureLayer, Symbol displaySymbol,
        PopupTemplate popupTemplate)
    {
        await ViewJsModule!.InvokeVoidAsync("queryFeatureLayer",
            CancellationTokenSource.Token, (object)query,
            (object)featureLayer, (object)displaySymbol, (object)popupTemplate, Id);
    }

    /// <summary>
    ///     A custom method to run an <see cref="AddressQuery" /> against the current view, and display the results.
    /// </summary>
    /// <param name="query">
    ///     The <see cref="AddressQuery" /> to run.
    /// </param>
    /// <param name="displaySymbol">
    ///     The <see cref="Symbol" /> to use to render the results of the query.
    /// </param>
    /// <param name="popupTemplate">
    ///     A <see cref="PopupTemplate" /> for displaying Popups on rendered results.
    /// </param>
    public async Task FindPlaces(AddressQuery query, Symbol displaySymbol, PopupTemplate popupTemplate)
    {
        await ViewJsModule!.InvokeVoidAsync("findPlaces", CancellationTokenSource.Token,
            (object)query, (object)displaySymbol, (object)popupTemplate, Id);
    }

    /// <summary>
    ///     Opens a Popup on a particular <see cref="Point" /> of the map view.
    /// </summary>
    /// <param name="template">
    ///     The <see cref="PopupTemplate" /> defining the Popup.
    /// </param>
    /// <param name="location">
    ///     The <see cref="Point" /> on which to display the Popup.
    /// </param>
    public async Task ShowPopup(PopupTemplate template, Point location)
    {
        await ViewJsModule!.InvokeVoidAsync("showPopup", CancellationTokenSource.Token,
            (object)template, (object)location, Id);
    }

    /// <summary>
    ///     Opens a Popup with a custom <see cref="Graphic" /> on a particular <see cref="Point" /> of the map view.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic" /> to display in the Popup
    /// </param>
    /// <param name="options">
    ///     A set of <see cref="PopupOptions" /> that define the position and visible elements of the Popup.
    /// </param>
    public async Task ShowPopupWithGraphic(Graphic graphic, PopupOptions options)
    {
        await ViewJsModule!.InvokeVoidAsync("showPopupWithGraphic", CancellationTokenSource.Token,
            (object)graphic, (object)options, Id);
    }

    /// <summary>
    ///     Opens the popup at the given location with content defined either explicitly with content or driven from the
    ///     PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively
    ///     open the popup by directly setting the visible property to true.
    /// </summary>
    /// <param name="options">
    ///     Defines the location and content of the popup when opened.
    /// </param>
    public async Task OpenPopup(PopupOpenOptions? options = null)
    {
        await ViewJsModule!.InvokeVoidAsync("openPopup", CancellationTokenSource.Token, Id, options);
    }

    /// <summary>
    ///     Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly
    ///     setting the visible property to false.
    /// </summary>
    public async Task ClosePopup()
    {
        await ViewJsModule!.InvokeVoidAsync("closePopup", CancellationTokenSource.Token, Id);
    }

    /// <summary>
    ///     Adds a collection of <see cref="Graphic" />s to the current view
    /// </summary>
    public async Task AddGraphics(IEnumerable<Graphic> graphics, CancellationToken cancellationToken = default)
    {
        AllowRender = false;
        var newGraphics = graphics.ToList();
        _graphics.UnionWith(newGraphics);

        foreach (Graphic graphic in newGraphics)
        {
            graphic.View = this;
            graphic.JsModule = ViewJsModule;
            graphic.Parent = this;
            graphic.AllowRender = false;
        }

        if (ViewJsModule is null) return;

        var records = newGraphics.Select(g => g.ToSerializationRecord()).ToList();
        int chunkSize = GraphicSerializationChunkSize ?? (IsMaui ? 100 : 200);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        if (IsWebAssembly)
        {
            for (var index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                ProtoGraphicCollection collection =
                    new(records.Skip(skip).Take(chunkSize).ToArray());
                MemoryStream ms = new();
                Serializer.Serialize(ms, collection);

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    await ms.DisposeAsync();

                    return;
                }

                ms.Seek(0, SeekOrigin.Begin);
                ((IJSInProcessObjectReference)JsModule!).InvokeVoid("addGraphicsSynchronously", ms.ToArray(), Id);
                await ms.DisposeAsync();
                await Task.Delay(1, cancellationToken);
            }
        }
        else if (IsMaui)
        {
            // MAUI at least on windows seems to occasionally throw an exception when adding graphics from multiple threads
            for (var index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                ProtoGraphicCollection collection =
                    new(records.Skip(skip).Take(chunkSize).ToArray());
                MemoryStream ms = new();
                Serializer.Serialize(ms, collection);

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    await ms.DisposeAsync();

                    return;
                }

                ms.Seek(0, SeekOrigin.Begin);
                using DotNetStreamReference streamRef = new(ms);

                await ViewJsModule!.InvokeVoidAsync("addGraphicsFromStream", cancellationToken,
                    streamRef, Id, abortSignal);
            }
        }
        else
        {
            List<Task> serializationTasks = new();

            for (var index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;

                serializationTasks.Add(Task.Run(async () =>
                {
                    if (cancellationToken.IsCancellationRequested ||
                        CancellationTokenSource.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    ProtoGraphicCollection collection =
                        new(records.Skip(skip).Take(chunkSize).ToArray());
                    MemoryStream ms = new();
                    Serializer.Serialize(ms, collection);

                    if (cancellationToken.IsCancellationRequested ||
                        CancellationTokenSource.Token.IsCancellationRequested)
                    {
                        await ms.DisposeAsync();

                        return;
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using DotNetStreamReference streamRef = new(ms);

                    await ViewJsModule!.InvokeVoidAsync("addGraphicsFromStream", cancellationToken,
                        streamRef, Id, abortSignal);
                }, cancellationToken));
            }

            await Task.WhenAll(serializationTasks);
        }

        AllowRender = true;
    }

    /// <summary>
    ///     Adds a <see cref="Graphic" /> to the current view, or to a <see cref="GraphicsLayer" />.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic" /> to add.
    /// </param>
    public async Task AddGraphic(Graphic graphic)
    {
        if (!_graphics.Any(g => g.Equals(graphic)))
        {
            graphic.View = this;
            graphic.JsModule = ViewJsModule;
            graphic.Parent = this;
            _graphics.Add(graphic);

            if (ViewJsModule is null) return;

            ProtoGraphicCollection collection = new(new[] { graphic.ToSerializationRecord() });
            MemoryStream ms = new();
            Serializer.Serialize(ms, collection);
            ms.Seek(0, SeekOrigin.Begin);
            using DotNetStreamReference streamRef = new(ms);

            await ViewJsModule!.InvokeVoidAsync("addGraphic", CancellationTokenSource.Token,
                streamRef, Id);
        }
    }

    /// <summary>
    ///     Clears all graphics from the view.
    /// </summary>
    public async Task ClearGraphics()
    {
        AllowRender = false;

        foreach (Graphic graphic in _graphics)
        {
            graphic.View = null;
            graphic.Parent = null;
        }

        _graphics.Clear();

        if (ViewJsModule is null) return;

        await ViewJsModule!.InvokeVoidAsync("clearGraphics", CancellationTokenSource.Token, Id);
        AllowRender = true;
    }

    /// <summary>
    ///     Adds a layer to the current Map
    /// </summary>
    /// <param name="layer">
    ///     The layer to add
    /// </param>
    /// <param name="isBasemapLayer">
    ///     If true, adds the layer as a Basemap. If there is no Basemap yet, one will be created.
    /// </param>
    public async Task AddLayer(Layer layer, bool isBasemapLayer = false)
    {
        if (isBasemapLayer)
        {
            Map!.Basemap ??= new Basemap();
            Map.Basemap.Layers.Add(layer);
            layer.Parent ??= Map.Basemap;
        }
        else
        {
            Map!.Layers.Add(layer);
            layer.Parent ??= Map;
        }
        
        layer.View ??= this;
        layer.JsModule ??= ViewJsModule;

        if (ViewJsModule is null) return;

        if (ProJsViewModule is not null && layer.GetType().Namespace!.Contains("Pro"))
        {
            await ProJsViewModule!.InvokeVoidAsync("addProLayer", CancellationTokenSource.Token, 
                (object)layer, Id, isBasemapLayer);
        }
        else
        {
            await ViewJsModule!.InvokeVoidAsync("addLayer", CancellationTokenSource.Token,
                (object)layer, Id, isBasemapLayer);
        }
    }

    /// <summary>
    ///     Removes a layer from the current Map
    /// </summary>
    /// <param name="layer">
    ///     The layer to remove
    /// </param>
    /// <param name="isBasemapLayer">
    ///     If true, removes the layer as a Basemap
    /// </param>
    public async Task RemoveLayer(Layer layer, bool isBasemapLayer = false)
    {
        var removed = false;

        if (isBasemapLayer)
        {
            if (Map?.Basemap?.Layers.Contains(layer) == true)
            {
                Map.Basemap.Layers.Remove(layer);
                layer.Parent = null;
                removed = true;
            }
        }
        else
        {
            if (Map?.Layers.Contains(layer) == true)
            {
                Map.Layers.Remove(layer);
                layer.Parent = null;
                removed = true;
            }
        }

        if (ViewJsModule is null || !removed) return;

        await ViewJsModule!.InvokeVoidAsync("removeLayer", CancellationTokenSource.Token,
            layer.Id, Id, isBasemapLayer);
    }

    /// <summary>
    ///     A custom method to set up the interaction for clicking a start and end point, and have the view render a driving
    ///     route. Also returns a set of <see cref="Direction" />s for display.
    /// </summary>
    /// <param name="routeSymbol">
    ///     The <see cref="Symbol" /> used to render the route.
    /// </param>
    /// <param name="routeUrl">
    ///     A routing service url for calculating the route.
    /// </param>
    /// <returns>
    ///     A collection of <see cref="Direction" /> steps to follow the route.
    /// </returns>
    public async Task<Direction[]> DrawRouteAndGetDirections(Symbol routeSymbol, string routeUrl)
    {
        return await ViewJsModule!.InvokeAsync<Direction[]?>("drawRouteAndGetDirections",
            CancellationTokenSource.Token, routeUrl, (object)routeSymbol, Id) ?? Array.Empty<Direction>();
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
    ///     The <see cref="Symbol" /> used to render the service areas.
    /// </param>
    public async Task SolveServiceArea(string serviceAreaUrl, double[] driveTimeCutOffs, Symbol serviceAreaSymbol)
    {
        await ViewJsModule!.InvokeVoidAsync("solveServiceArea", CancellationTokenSource.Token,
            serviceAreaUrl, driveTimeCutOffs, serviceAreaSymbol, Id);
    }

    /// <summary>
    ///     Removes a graphic from the current view.
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic" /> to remove.
    /// </param>
    public async Task RemoveGraphic(Graphic graphic)
    {
        _graphics.Remove(graphic);
        graphic.Parent = null;
        graphic.View = null;

        if (ViewJsModule is null) return;

        await ViewJsModule!.InvokeVoidAsync("removeGraphic", CancellationTokenSource.Token,
            graphic.Id, Id);
    }

    /// <summary>
    ///     Removes a collection of graphics from the current view.
    /// </summary>
    /// <param name="graphics">
    ///     The <see cref="Graphic" />s to remove.
    /// </param>
    public async Task RemoveGraphics(IEnumerable<Graphic> graphics)
    {
        AllowRender = false;
        var oldGraphics = graphics.ToList();

        foreach (Graphic graphic in oldGraphics)
        {
            _graphics.Remove(graphic);
            graphic.View = null;
            graphic.Parent = null;
        }

        if (ViewJsModule is null) return;

        await ViewJsModule!.InvokeVoidAsync("removeGraphics", CancellationTokenSource.Token,
            oldGraphics.Select(g => g.Id), View!.Id);
        AllowRender = true;
    }

    /// <summary>
    ///     Sets the center <see cref="Point" /> of the current view.
    /// </summary>
    public virtual async Task SetCenter(Point point)
    {
        if (!Equals(point.Latitude, Latitude) || !Equals(point.Longitude, Longitude))
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;
            Latitude = point.Latitude;
            Longitude = point.Longitude;

            if (ViewJsModule is null || !MapRendered) return;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setCenter",
                    CancellationTokenSource.Token, (object)point, Id);
            Extent = change.Extent;
            Zoom = change.Zoom;
            Scale = change.Scale;
            Rotation = change.Rotation ?? Rotation;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Returns the center <see cref="Point" /> of the current view extent.
    /// </summary>
    public async Task<Point?> GetCenter()
    {
        Point? center = null;

        if (ViewJsModule is not null && MapRendered)
        {
            center = await ViewJsModule!.InvokeAsync<Point?>("getCenter", CancellationTokenSource.Token, Id);

            if (center is not null)
            {
                Latitude = center.Latitude;
                Longitude = center.Longitude;
            }
        }
        else if (Latitude is not null && Longitude is not null)
        {
            center = new Point(Longitude, Latitude);
        }

        return center;
    }

    /// <summary>
    ///     Sets the zoom level of the current view.
    /// </summary>
    public virtual async Task SetZoom(double zoom)
    {
        Zoom = zoom;

        if (ViewJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setZoom", CancellationTokenSource.Token, Zoom, Id);
            Extent = change.Extent;
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Scale = change.Scale;
            Rotation = change.Rotation ?? Rotation;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Returns the zoom level of the current view.
    /// </summary>
    public async Task<double?> GetZoom()
    {
        if (ViewJsModule is not null)
        {
            Zoom = await ViewJsModule!.InvokeAsync<double>("getZoom", CancellationTokenSource.Token, Id);
        }

        return Zoom;
    }

    /// <summary>
    ///     Sets the scale of the current view.
    /// </summary>
    public virtual async Task SetScale(double scale)
    {
        Scale = scale;

        if (ViewJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setScale",
                    CancellationTokenSource.Token, Scale, Id);
            Extent = change.Extent;
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Zoom = change.Zoom;
            Rotation = change.Rotation ?? Rotation;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Returns the scale of the current view.
    /// </summary>
    public async Task<double?> GetScale()
    {
        if (ViewJsModule is not null)
        {
            Scale = await ViewJsModule!.InvokeAsync<double>("getScale", CancellationTokenSource.Token, Id);
        }

        return Scale;
    }

    /// <summary>
    ///     Sets the rotation of the current view.
    /// </summary>
    public async Task SetRotation(double rotation)
    {
        Rotation = rotation;

        if (ViewJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setRotation",
                    CancellationTokenSource.Token, Rotation, Id);
            Extent = change.Extent;
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Zoom = change.Zoom;
            Scale = change.Scale;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Returns the rotation of the current view.
    /// </summary>
    public async Task<double?> GetRotation()
    {
        if (ViewJsModule is not null)
        {
            Rotation = await ViewJsModule!.InvokeAsync<double>("getRotation", CancellationTokenSource.Token, Id);
        }

        return Rotation;
    }

    /// <summary>
    ///     Sets the <see cref="Extent" /> of the view.
    /// </summary>
    public virtual async Task SetExtent(Extent extent)
    {
        if (!extent.Equals(Extent))
        {
            Extent = extent;

            if (ViewJsModule is null || !MapRendered) return;

            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setExtent",
                    CancellationTokenSource.Token, (object)Extent, Id);
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Zoom = change.Zoom;
            Scale = change.Scale;
            Rotation = change.Rotation ?? Rotation;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Returns the current <see cref="Extent" /> of the view.
    /// </summary>
    public async Task<Extent?> GetExtent()
    {
        if (ViewJsModule is not null)
        {
            Extent = await ViewJsModule!.InvokeAsync<Extent?>("getExtent", CancellationTokenSource.Token, Id);
        }

        return Extent;
    }

    /// <summary>
    ///     Sets the <see cref="Constraints" /> of the view.
    /// </summary>
    public async Task SetConstraints(Constraints constraints)
    {
        if (!constraints.Equals(Constraints))
        {
            Constraints = constraints;

            if (ViewJsModule is null) return;

            await ViewJsModule!.InvokeVoidAsync("setConstraints",
                CancellationTokenSource.Token, (object)Constraints, Id);
        }
    }

    /// <summary>
    ///     Sets the <see cref="HighlightOptions" /> of the view.
    /// </summary>
    public async Task SetHighlightOptions(HighlightOptions highlightOptions)
    {
        if (!highlightOptions.Equals(HighlightOptions))
        {
            HighlightOptions = highlightOptions;

            if (ViewJsModule is null) return;

            await ViewJsModule!.InvokeVoidAsync("setHighlightOptions",
                CancellationTokenSource.Token, (object)HighlightOptions, Id);
        }
    }

    /// <summary>
    ///     Sets the <see cref="SpatialReference" /> of the view.
    /// </summary>
    public async Task SetSpatialReference(SpatialReference spatialReference)
    {
        if (!spatialReference.Equals(SpatialReference))
        {
            SpatialReference = spatialReference;

            if (ViewJsModule is null) return;

            await ViewJsModule!.InvokeVoidAsync("setSpatialReference",
                CancellationTokenSource.Token, (object)SpatialReference, Id);
        }
    }

    /// <summary>
    ///     Returns the current <see cref="SpatialReference" /> of the view.
    /// </summary>
    public async Task<SpatialReference?> GetSpatialReference()
    {
        if (ViewJsModule is not null)
        {
            SpatialReference = await ViewJsModule!.InvokeAsync<SpatialReference?>("getSpatialReference",
                CancellationTokenSource.Token, Id);
        }

        return SpatialReference;
    }

    /// <summary>
    ///     Retrieves the Popup Widget for the view.
    /// </summary>
    public async Task<PopupWidget?> GetPopupWidget()
    {
        if (!Widgets.Any(w => w is PopupWidget) && ViewJsModule is not null)
        {
            var popupWidget = new PopupWidget();
            await AddWidget(popupWidget);
        }

        return Widgets.FirstOrDefault(w => w is PopupWidget) as PopupWidget;
    }

    /// <summary>
    ///     Changes the view <see cref="Extent" /> and redraws.
    /// </summary>
    /// <param name="extent">
    ///     The new <see cref="Extent" /> of the view.
    /// </param>
    public async Task GoTo(Extent extent)
    {
        if (ViewJsModule is null || !MapRendered) return;

        ShouldUpdate = false;
        ExtentSetByCode = true;

        ViewExtentUpdate change =
            await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("goToExtent",
                CancellationTokenSource.Token, extent, Id);
        Extent = change.Extent;
        Latitude = change.Center?.Latitude;
        Longitude = change.Center?.Longitude;
        Zoom = change.Zoom;
        Scale = change.Scale;
        Rotation = change.Rotation ?? Rotation;
        ShouldUpdate = true;
    }

    /// <summary>
    ///     Changes the view <see cref="Extent" /> and redraws.
    /// </summary>
    /// <param name="graphics">
    ///     The <see cref="Graphic" />s to zoom to.
    /// </param>
    public virtual async Task GoTo(IEnumerable<Graphic> graphics)
    {
        if (ViewJsModule is null || !MapRendered) return;

        ShouldUpdate = false;
        ExtentSetByCode = true;

        ViewExtentUpdate change =
            await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("goToGraphics",
                CancellationTokenSource.Token, graphics, Id);
        Extent = change.Extent;
        Latitude = change.Center?.Latitude;
        Longitude = change.Center?.Longitude;
        Zoom = change.Zoom;
        Scale = change.Scale;
        Rotation = change.Rotation ?? Rotation;
        ShouldUpdate = true;
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results
    ///     are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="clickEvent">
    ///     The click event to test for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(ClickEvent clickEvent, HitTestOptions? options = null)
    {
        return await HitTestImplementation(new ScreenPoint(clickEvent.X, clickEvent.Y), options);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results
    ///     are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The pointer event to test for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(PointerEvent pointerEvent, HitTestOptions? options = null)
    {
        return await HitTestImplementation(new ScreenPoint(pointerEvent.X, pointerEvent.Y), options);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results
    ///     are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="screenPoint">
    ///     The screen point to check for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(ScreenPoint screenPoint, HitTestOptions? options = null)
    {
        return await HitTestImplementation(screenPoint, options);
    }
    
    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results
    ///     are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="mapPoint">
    ///     The map point, in the same projection as the map, to check for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(Point mapPoint, HitTestOptions? options = null)
    {
        ScreenPoint screenPoint = await ToScreen(mapPoint);
        return await HitTestImplementation(screenPoint, options);
    }

    /// <summary>
    ///     Converts the given screen point to a map point. The screen point represents a point in terms of pixels relative to the top-left corner of the view.
    /// </summary>
    public async Task<Point> ToMap(ScreenPoint screenPoint)
    {
        return await ViewJsModule!.InvokeAsync<Point>("toMap",
            CancellationTokenSource.Token, screenPoint, Id);
    }

    /// <summary>
    ///     Converts the given map point to a screen point. The screen point represents a point in terms of pixels relative to the top-left corner of the view.
    /// </summary>
    public async Task<ScreenPoint> ToScreen(Point mapPoint)
    {
        return await ViewJsModule!.InvokeAsync<ScreenPoint>("toScreen",
            CancellationTokenSource.Token, mapPoint, Id);
    }

    /// <summary>
    ///     Returns the current cursor when hovering over the view.
    /// </summary>
    public async Task<string> GetCursor()
    {
        return await ViewJsModule!.InvokeAsync<string>("getCursor",
            CancellationTokenSource.Token, Id);
    }
    
    /// <summary>
    ///     Sets the cursor for the view.
    /// </summary>
    public async Task SetCursor(string cursor)
    {
        await ViewJsModule!.InvokeVoidAsync("setCursor",
            CancellationTokenSource.Token, cursor, Id);
    }

    /// <summary>
    ///     The callback method for returning a chunk of data from a Blazor Server hit test.
    /// </summary>
    /// <param name="eventId">
    ///     The hit test event id.
    /// </param>
    /// <param name="chunk">
    ///     A chunk of hit test data, to be combined with other data before deserialization.
    /// </param>
    [JSInvokable]
    public void OnJavascriptHitTestResult(Guid eventId, string chunk)
    {
        if (_isDisposed) return;
        if (_hitTestResults.TryGetValue(eventId, out StringBuilder? result))
        {
            result.Append(chunk);
        }
        else
        {
            _hitTestResults.Add(eventId, new StringBuilder(chunk));
        }
    }

    /// <inheritdoc />
    public override async ValueTask DisposeAsync()
    {
        try
        {
            if (ViewJsModule != null)
            {
                await ViewJsModule.InvokeVoidAsync("disposeView",
                    CancellationTokenSource.Token, Id);
            }
        }
        catch (JSDisconnectedException)
        {
            // ignore, dispose is called by Blazor too early
        }

        _isDisposed = true;
    }

    /// <summary>
    ///     Adds a widget to the view.
    /// </summary>
    public async Task AddWidget(Widget widget)
    {
        if (_widgets.Add(widget))
        {
            widget.Parent ??= this;
            widget.View ??= this;
            widget.JsModule ??= ViewJsModule;
        }

        if (ViewJsModule is null || !widget.ArcGisWidget) return;

        while (Rendering)
        {
            await Task.Delay(100);
        }

        await InvokeAsync(async () =>
        {
            if (widget.GetType().Namespace!.Contains("Core"))
            {
                await ViewJsModule!.InvokeVoidAsync("addWidget",
                    CancellationTokenSource.Token, widget, Id);
            }
            else
            {
                await ProJsViewModule!.InvokeVoidAsync("addProWidget",
                    CancellationTokenSource.Token, widget, Id);
            }
        });

        if (widget is PopupWidget)
        {
            // we have to update the layers to make sure the popupTemplates aren't unset by this action
            foreach (Layer layer in Map!.Layers.Where(l => l is FeatureLayer { PopupTemplate: not null }))
            {
                // ReSharper disable once RedundantCast
                await JsModule!.InvokeVoidAsync("updateLayer", CancellationTokenSource.Token,
                    (object)layer, Id);
            }
        }
    }

    /// <summary>
    ///     Removes a widget from the view.
    /// </summary>
    public async Task RemoveWidget(Widget widget)
    {
        if (ViewJsModule is null) return;

        if (_widgets.Contains(widget))
        {
            _widgets.Remove(widget);
            widget.Parent = null;
        }

        await InvokeAsync(async () =>
        {
            try
            {
                await ViewJsModule!.InvokeVoidAsync("removeWidget",
                    CancellationTokenSource.Token, widget.Id, Id);
            }
            catch (JSDisconnectedException)
            {
                // ignore, dispose is called by Blazor too early
            }
        });
    }

#endregion
    
#region Lifecycle Methods
    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (AllowDefaultEsriLogin is null)
        {
            bool? setting = Configuration.GetValue<bool?>("AllowDefaultEsriLogin");

            if (setting is not null)
            {
                AllowDefaultEsriLogin = setting.Value;
            }
        }

        if (PromptForArcGISKey is null)
        {
            bool? promptSetting = Configuration.GetValue<bool?>("PromptForArcGISKey");

            if (promptSetting is not null)
            {
                PromptForArcGISKey = promptSetting.Value;
            }
        }

        if (GraphicSerializationChunkSize is null)
        {
            int? chunkSetting = Configuration.GetValue<int?>("GraphicSerializationChunkSize");

            if (chunkSetting is not null)
            {
                GraphicSerializationChunkSize = chunkSetting.Value;
            }
        }

        await UpdateView();
    }


    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        AbortManager ??= new AbortManager(JsRuntime);

        if (!LoadOnRender && !_renderCalled)
        {
            NeedsRender = false;
        }

        if (firstRender)
        {
            ProJsViewModule = await JsModuleManager.GetArcGisJsPro(JsRuntime, CancellationTokenSource.Token);

            ViewJsModule = await JsModuleManager.GetArcGisJsCore(JsRuntime, ProJsViewModule, CancellationTokenSource.Token);

            JsModule = ViewJsModule;

            try
            {
                await AppValidator.ValidateLicense();
            }
            catch (Exception ex)
            {
                // only write exceptions out, don't throw.
                Console.WriteLine(ex);
            }

            // the first render never has all the child components registered
            Rendering = false;

            AuthenticationInitialized = await AuthenticationManager.Initialize();

            if (!string.IsNullOrEmpty(AppId) && (PromptForOAuthLogin == true))
            {
                await AuthenticationManager.Login();
            }

            StateHasChanged();

            return;
        }

        if (NeedsRender)
        {
            await RenderView();
        }
    }

    /// <inheritdoc />
    protected override async Task RenderView(bool forceRender = false)
    {
        if (!NeedsRender && !forceRender)
        {
            return;
        }

        if (!AuthenticationInitialized || Rendering || Map is null || ViewJsModule is null) return;

        if (string.IsNullOrWhiteSpace(ApiKey) && AllowDefaultEsriLogin is null or false &&
            PromptForArcGISKey is null or true && string.IsNullOrWhiteSpace(AppId))
        {
            var newErrorMessage =
                "No ArcGIS API Key Found. See https://docs.geoblazor.com/pages/authentication.html for instructions on providing an API Key or suppressing this message.";

            if (ErrorMessage == newErrorMessage)
            {
                return;
            }

            ErrorMessage = newErrorMessage;
            Debug.WriteLine(ErrorMessage);
            StateHasChanged();

            return;
        }

        Rendering = true;
        Map.Layers.RemoveAll(l => l.Imported);
        Map.Basemap?.Layers.RemoveAll(l => l.Imported);
        ValidateRequiredChildren();

        await InvokeAsync(async () =>
        {
            Console.WriteLine("Rendering View");

            if (Map is null)
            {
                throw new MissingMapException();
            }

            string mapType = Map is WebMap ? "webmap" : "map";

            NeedsRender = false;

            await ViewJsModule!.InvokeVoidAsync("setAssetsPath", CancellationTokenSource.Token,
                Configuration.GetValue<string?>("ArcGISAssetsPath",
                    "/_content/dymaptic.GeoBlazor.Core/assets"));

            await ViewJsModule.InvokeVoidAsync("buildMapView", CancellationTokenSource.Token, Id,
                DotNetObjectReference, Longitude, Latitude, Rotation, Map, Zoom, Scale,
                mapType, Widgets, Graphics, SpatialReference, Constraints, Extent,
                EventRateLimitInMilliseconds, GetActiveEventHandlers(), IsServer, HighlightOptions, PopupEnabled);

            Rendering = false;
            MapRendered = true;

            if (ProJsViewModule is not null)
            {
                // register pro widgets
                foreach (Widget widget in Widgets.Where(w => !w.GetType().Namespace!.Contains("Core")))
                {
                    await AddWidget(widget);
                }
            }
           
          
        });
    }
#endregion
    
#region Internal Methods
    /// <summary>
    ///     Updates properties directly on the view.
    /// </summary>
    protected virtual async Task UpdateView()
    {
        if (!MapRendered || !ShouldUpdate || ExtentSetByCode || ExtentChangedInJs || PointerDown)
        {
            return;
        }

        ShouldUpdate = false;

        ViewExtentUpdate? change = await ViewJsModule!.InvokeAsync<ViewExtentUpdate?>("updateView",
            CancellationTokenSource.Token,
            new
            {
                Id,
                Latitude,
                Longitude,
                Zoom,
                Rotation
            });

        if (change is not null)
        {
            Extent = change.Extent;
        }
        ShouldUpdate = true;
    }

    /// <inheritdoc />
    protected override bool ShouldRender()
    {
        return _shouldRender;
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

            case Widget widget:
                await AddWidget(widget);

                break;
            case Graphic graphic:
                await AddGraphic(graphic);

                break;
            case SpatialReference spatialReference:
                await SetSpatialReference(spatialReference);

                break;
            case Constraints constraints:
                await SetConstraints(constraints);

                break;
            case Extent extent:
                if (ExtentChangedInJs)
                {
                    return; // once a user has moved the map, we shouldn't be able to re-use the originally set extent in markup
                }

                await SetExtent(extent);

                break;
            case HighlightOptions highlightOptions:
                await SetHighlightOptions(highlightOptions);

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

                break;

            case Widget widget:
                await RemoveWidget(widget);

                break;
            case Graphic graphic:
                await RemoveGraphic(graphic);

                break;
            case Constraints _:
                Constraints = null;

                break;
            case SpatialReference _:
                SpatialReference = null;

                break;
            case Extent _:
                Extent = null;

                break;
            case HighlightOptions _:
                HighlightOptions = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Map?.ValidateRequiredChildren();
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
    
    private async Task<HitTestResult> HitTestImplementation(ScreenPoint screenPoint, HitTestOptions? options)
    {
        Guid hitTestId = Guid.NewGuid();
        HitTestResult result = await ViewJsModule!.InvokeAsync<HitTestResult>("hitTest",
            CancellationTokenSource.Token, screenPoint, Id, options, hitTestId);

        if (_activeHitTests.TryGetValue(hitTestId, out ViewHit[]? viewHits))
        {
            result.Results = viewHits;
        }

        return result;
    }
    
    /// <summary>
    ///     Internal use callback from JavaScript
    /// </summary>
    [JSInvokable]
    public async Task OnHitTestStreamCallback(IJSStreamReference streamReference, Guid hitTestId)
    {
        if (_isDisposed) return;
        try
        {
            await using Stream stream = await streamReference
                .OpenReadStreamAsync(QueryResultsMaxSizeLimit);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ProtoViewHitCollection collection = Serializer.Deserialize<ProtoViewHitCollection>(ms);
            ViewHit[] viewHits = collection.ViewHits!.Select(g => g.FromSerializationRecord()).ToArray();

            _activeHitTests[hitTestId] = viewHits;
        }
        catch (Exception ex)
        {
            throw new SerializationException("Error deserializing graphics from stream.", ex);
        }
    }

    
    private bool IsPro()
    {
        if (_isPro is null)
        {
            try
            {
                Assembly _ = Assembly.Load("dymaptic.GeoBlazor.Pro");

                _isPro = true;
            }
            catch
            {
                _isPro = false;
            }
        }
        
        return _isPro.Value;
    }
    
    /// <summary>
    ///     Retrieves all <see cref="EventCallback" />s and <see cref="Func{TResult}" />s that are listening for JavaScript
    ///     events.
    /// </summary>
    protected List<string> GetActiveEventHandlers()
    {
        List<string> activeHandlers = new();

        var properties = GetType().GetProperties();

        IEnumerable<PropertyInfo> funcCallbacks = properties.Where(p => p.PropertyType.Name.StartsWith("Func"));

        activeHandlers.AddRange(funcCallbacks.Select(x => x.Name));

        IEnumerable<PropertyInfo> eventCallbacks = properties.Where(p => p.PropertyType.Name.StartsWith(nameof(EventCallback)));

        foreach (PropertyInfo callbackInfo in eventCallbacks)
        {
            object? callback = callbackInfo.GetValue(this);

            if(callback is not null)
            {
                var hasDelegate = callback switch
                {
                    EventCallback e => e.HasDelegate,
                    EventCallback<ClickEvent> e => e.HasDelegate,
                    EventCallback<BlurEvent> e => e.HasDelegate,
                    EventCallback<DragEvent> e => e.HasDelegate,
                    EventCallback<FocusEvent> e => e.HasDelegate,
                    EventCallback<PointerEvent> e => e.HasDelegate,
                    EventCallback<KeyDownEvent> e => e.HasDelegate,
                    EventCallback<KeyUpEvent> e => e.HasDelegate,
                    EventCallback<Guid> e => e.HasDelegate,
                    EventCallback<SpatialReference> e => e.HasDelegate,
                    EventCallback<Extent> e => e.HasDelegate,
                    EventCallback<ResizeEvent> e => e.HasDelegate,
                    EventCallback<MouseWheelEvent> e => e.HasDelegate,
                    EventCallback<LayerViewCreateEvent> e => e.HasDelegate,
                    EventCallback<LayerViewDestroyEvent> e => e.HasDelegate,
                    EventCallback<LayerViewCreateErrorEvent> e => e.HasDelegate,
                    _ => false
                };

                if(hasDelegate)
                {
                    activeHandlers.Add(callbackInfo.Name);
                }
            }
        }

        return activeHandlers;
    }
    
#endregion
    
#region Internal Fields
    /// <summary>
    ///     A reference to the arcGisJsInterop module
    /// </summary>
    protected IJSObjectReference? ViewJsModule;

    /// <summary>
    ///     Optional reference to the Pro library JS module
    /// </summary>
    protected IJSObjectReference? ProJsViewModule;

    /// <summary>
    ///     A boolean flag to indicate that rendering is underway
    /// </summary>
    protected bool Rendering;

    /// <summary>
    ///     A boolean flag to indicate a "dirty" state that needs to be re-rendered
    /// </summary>
    protected bool NeedsRender = true;

    /// <summary>
    ///     A boolean flag to indicate that the map should update parameters (lat, lon, zoom, etc)
    /// </summary>
    protected bool ShouldUpdate = true;
    /// <summary>
    ///     A boolean flag to indicate that the map extent has been modified in code, and therefore should not be modifiable by
    ///     markup until <see cref="Refresh" /> is called
    /// </summary>
    protected bool ExtentSetByCode = false;
    /// <summary>
    ///     Indicates that the pointer is currently down, to prevent updating the extent during this action.
    /// </summary>
    protected bool PointerDown;
    /// <summary>
    ///     A reference to the JavaScript AbortManager for this component.
    /// </summary>
    protected AbortManager? AbortManager; 
    /// <summary>
    ///     Marks that the authentication has been initialized.
    /// </summary>
    protected bool AuthenticationInitialized;
    
    private SpatialReference? _spatialReference;
    private Dictionary<Guid, StringBuilder> _hitTestResults = new();
    private bool _renderCalled;
    private bool _shouldRender = true;
    private Dictionary<string, StringBuilder> _layerCreateData = new();
    private Dictionary<string, StringBuilder> _layerViewCreateData = new();
    private HashSet<Graphic> _graphics = new();
    private HashSet<Widget> _widgets = new();
    private bool? _isPro;
    private Dictionary<Guid, ViewHit[]> _activeHitTests = new();
    private bool _isDisposed;
    
#endregion
}
