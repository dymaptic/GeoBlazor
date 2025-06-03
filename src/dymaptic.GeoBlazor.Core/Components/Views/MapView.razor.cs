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
    ///     A set of key/value application configuration properties, that can be populated from `appsettings.json, environment variables, or other sources.
    /// </summary>
    [Inject]
    public IConfiguration Configuration { get; set; } = null!;

    /// <summary>
    ///     Handles OAuth authentication
    /// </summary>
    [Inject]
    public AuthenticationManager AuthenticationManager { get; set; } = null!;

    /// <summary>
    ///     Validates GeoBlazor Registration or Pro Licensing
    /// </summary>
    [Inject]
    private IAppValidator AppValidator { get; set; } = null!;
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
    ///     The background color of the MapView. If the view's map changes, the view's background is reset to the map's background, even if the user set it previously.
    /// </summary>
    [Parameter]
    public MapColor? BackgroundColor { get; set; }

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
    ///     Boolean flag that can be set to false to prevent the MapView from automatically rendering with the Blazor components.
    /// </summary>
    [Parameter]
    public bool LoadOnRender { get; set; } = true;

    /// <summary>
    ///     Provides an override for the default behavior of requiring an API key. By setting to "false", all calls to ArcGIS services will trigger a sign-in popup.
    /// </summary>
    /// <remarks>
    ///     Setting this to "false" is the same as setting <see cref="AllowDefaultEsriLogin" /> to "true". This is provided simply for convenience of discovery.
    /// </remarks>
    [Parameter]
    public bool? PromptForArcGISKey { get; set; }

    /// <summary>
    ///     If you set an `AppId` in your configuration, setting this to true will cause the app to attempt to auto-login using ArcGIS OAuth.
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
    ///     The reference to arcGisJsInterop.ts from .NET
    /// </summary>
    [Obsolete("Use CoreJsModule instead.")]
    public IJSObjectReference? ViewJsModule => CoreJsModule;

    /// <summary>
    ///     The reference to arcGisJsInterop.ts from .NET
    /// </summary>
    [Obsolete("Use ProJsModule instead.")]
    public IJSObjectReference? ProViewJsModule => ProJsModule;

    /// <summary>
    ///     The collection of <see cref="Widget" />s in the view.
    /// </summary>
    public IReadOnlyCollection<Widget> Widgets
    {
        get => _widgets;
        private set => _widgets = [..value];
    }

    /// <summary>
    ///     The collection of <see cref="Graphic" />s in the view. These are directly on the view itself, not in a <see cref="GraphicsLayer" />.
    /// </summary>
    public IReadOnlyCollection<Graphic> Graphics
    {
        get => _graphics;
        private set => _graphics = [..value];
    }

    /// <summary>
    ///     An instance of a <see cref="Map" /> object to display in the view.
    /// </summary>
    [RequiredProperty]
    public Map? Map { get; private set; }
    
    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Server mode
    /// </summary>
    public bool IsServer => JsRuntime!.GetType().Name.Contains("Remote");

    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor WebAssembly (client) mode
    /// </summary>
    public bool IsWebAssembly => OperatingSystem.IsBrowser();

    /// <summary>
    ///     Boolean flag to identify if GeoBlazor is running in Blazor Hybrid (MAUI) mode
    /// </summary>
    public bool IsMaui => JsRuntime!.GetType().Name.Contains("WebView");
    
    /// <summary>
    ///     A boolean flag to indicate that the map extent has been modified in JavaScript, and therefore should not be modifiable by markup until <see cref="Refresh" /> is called
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
    ///     Options for configuring the highlight. Use the highlight method on the appropriate LayerView to highlight a feature. With version 4.19, highlighting a feature influences the shadow of the feature as well. By default, the shadow of the highlighted feature is displayed in a darker shade.
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
    ///     Fires after a user clicks on the view. This event emits slightly slower than an immediate-click event to make sure that a double-click event isn't triggered instead. The immediate-click event can be used for responding to a click
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
    ///     Handler delegate for pointer leave events on the view. Must take in a <see cref="Point" /> and return a <see cref="Task" />.
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
    ///     Handler delegate for point move events on the view. Must take in a <see cref="Point" /> and return a <see cref="Task" />.
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
    ///     Handler delegate for pointer up events on the view. Must take in a <see cref="Point" /> and return a <see cref="Task" />.
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
        if (_isDisposed || _waitingForRender) return;
        
        _waitingForRender = true;

        while (!MapRendered)
        {
            // wait for the RenderView method to complete
            await Task.Delay(50);
        }
        await OnViewRendered.InvokeAsync(Id);
        _waitingForRender = false;
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
    public async Task<Guid?> OnJavascriptLayerViewCreateComplete(Guid? geoBlazorLayerId, string layerUid,
        IJSObjectReference layerRef, IJSObjectReference layerViewRef, bool isBasemapLayer, bool isReferenceLayer)
    {
        if (_isDisposed) return null;
        try
        {
            JsonSerializerOptions options = GeoBlazorSerialization.JsonSerializerOptions;
            Layer layer = JsonSerializer.Deserialize<Layer>(_layerCreateData[layerUid].ToString(), options)!;

            LayerView layerView =
                JsonSerializer.Deserialize<LayerView>(_layerViewCreateData[layerUid].ToString(), options)!;

            LayerViewCreateInternalEvent createEvent =
                new(layerRef, layerViewRef, geoBlazorLayerId ?? Guid.Empty, layer,
                    layerView, isBasemapLayer, isReferenceLayer);
            return await OnJavascriptLayerViewCreate(createEvent);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return null;
        }
    }

    /// <summary>
    ///     JS-Invokable method to return when a layer view is created.
    /// </summary>
    /// <param name="layerViewCreateEvent">
    ///     The new <see cref="LayerViewCreateEvent" />
    /// </param>
    [JSInvokable]
    public async Task<Guid?> OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent layerViewCreateEvent)
    {
        if (_isDisposed) return null;
        LayerView? layerView = layerViewCreateEvent.Layer switch
        {
            FeatureLayer => new FeatureLayerView(layerViewCreateEvent.LayerView!, new AbortManager(CoreJsModule!)),
            _ => layerViewCreateEvent.LayerView
        };

        if (layerView is not null)
        {
            layerView.View = this;
            layerView.Parent = this;
            layerView.CoreJsModule = CoreJsModule;
            layerView.JsComponentReference = layerViewCreateEvent.LayerViewObjectRef;
        }

        Layer? createdLayer = layerViewCreateEvent.IsBasemapLayer
            ? Map?.Basemap?.BaseLayers?.FirstOrDefault(l => l.Id == layerViewCreateEvent.LayerGeoBlazorId)
            : layerViewCreateEvent.IsReferenceLayer
                ? Map?.Basemap?.ReferenceLayers?.FirstOrDefault(l => l.Id == layerViewCreateEvent.LayerGeoBlazorId)
                : Map?.Layers.FirstOrDefault(l => l.Id == layerViewCreateEvent.LayerGeoBlazorId)
                ?? Map?.Layers.OfType<IGroupLayer>()
                    .Select(g => 
                        g.Layers?.FirstOrDefault(sl => sl.Id == layerViewCreateEvent.LayerGeoBlazorId))
                    .FirstOrDefault(l => l is not null);

        if (createdLayer is not null) // layer already exists in GeoBlazor
        {
            createdLayer.LayerView = layerView;
            createdLayer.Loaded = true;

            if (layerViewCreateEvent.Layer is not null)
            {
                createdLayer.CopyProperties(layerViewCreateEvent.Layer!);
                await createdLayer.UpdateFromJavaScript(layerViewCreateEvent.Layer!);
            }

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
                layer.AbortManager = new AbortManager(CoreJsModule!);
                layer.JsComponentReference = layerViewCreateEvent.LayerObjectRef;
                layer.CoreJsModule = CoreJsModule;
                layer.ProJsModule = ProJsModule;
                layer.AbortManager = new AbortManager(CoreJsModule!);
                layer.Imported = true;
                layer.Loaded = true;

                if (layerView is not null)
                {
                    layerView.Layer = layer;
                }

                layer.View = this;

                if (layerViewCreateEvent.IsBasemapLayer)
                {
                    if (Map?.Basemap is not null)
                    {
#pragma warning disable BL0005
                        Map!.Basemap!.BaseLayers ??= [];
                        Map.Basemap.BaseLayers = [..Map.Basemap.BaseLayers, layer];
                    }
                }
                else if (layerViewCreateEvent.IsReferenceLayer)
                {
                    if (Map?.Basemap is not null)
                    {
                        Map!.Basemap!.ReferenceLayers ??= [];
                        Map.Basemap.ReferenceLayers = [..Map.Basemap.ReferenceLayers, layer];
#pragma warning restore BL0005
                    }
                }
                else
                {
                    if (Map is not null)
                    {
                        Map!.Layers.Add(layer);
                    }
                }
                
                await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject", layerViewCreateEvent.LayerObjectRef, layer.Id);
            }
        }

        await OnLayerViewCreate.InvokeAsync(new LayerViewCreateEvent(layerView?.Layer, layerView));

        return layerView?.Id;
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
        if (_isDisposed) return;
        await OnLayerViewCreateError.InvokeAsync(errorEvent);
    }

    /// <summary>
    ///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.
    /// </summary>
    [Parameter]
    public EventCallback<LayerViewCreateErrorEvent> OnLayerViewCreateError { get; set; }

    /// <summary>
    ///     Set this parameter to limit the rate at which recurring events are returned. Applies to <see cref="OnDrag" />, <see cref="OnPointerMove" />, <see cref="OnMouseWheel" />, <see cref="OnResize" />, and <see cref="OnExtentChanged" />
    /// </summary>
    [Parameter]
    public int EventRateLimitInMilliseconds { get; set; } = 100;

    /// <summary>
    ///    Optional setting to control the number of graphics that are serialized in a single chunk. Tuning this value might help with performance when adding large graphic sets.
    /// </summary>
    [Parameter]
    public int? GraphicSerializationChunkSize { get; set; }
    
    /// <summary>
    ///     The maximum size of query results that will be returned in a stream. Note that setting this to a smaller value might create errors in query returns.
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
    ///     For internal use only, this looks up a missing <see cref="DotNetObjectReference"/> for a <see cref="PopupTemplate"/> and returns it to JavaScript.
    /// </summary>
    [JSInvokable]
    public DotNetObjectReference<MapComponent>? GetDotNetPopupTemplateObjectReference(Guid popupTemplateId)
    {
        if (_isDisposed) return null;
        foreach (Graphic graphic in Graphics)
        {
            if (graphic.PopupTemplate?.Id == popupTemplateId)
            {
                return graphic.PopupTemplate.DotNetComponentReference;
            }
        }

        if (Map is null)
        {
            return null;
        }

        foreach (Layer layer in Map!.Layers)
        {
            switch (layer)
            {
                case FeatureLayer featureLayer:
                    if (featureLayer.PopupTemplate?.Id == popupTemplateId)
                    {
                        return featureLayer.PopupTemplate.DotNetComponentReference;
                    }

                    if (featureLayer.Source is not null)
                    {
                        foreach (Graphic graphic in featureLayer.Source)
                        {
                            if (graphic.PopupTemplate?.Id == popupTemplateId)
                            {
                                return graphic.PopupTemplate.DotNetComponentReference;
                            }
                        }
                    }

                    break;
                case GraphicsLayer graphicsLayer:
                    foreach (Graphic graphic in graphicsLayer.Graphics)
                    {
                        if (graphic.PopupTemplate?.Id == popupTemplateId)
                        {
                            return graphic.PopupTemplate.DotNetComponentReference;
                        }
                    }

                    break;
                case IPopupTemplateLayer templateLayer:
                    if (templateLayer.PopupTemplate?.Id == popupTemplateId)
                    {
                        return templateLayer.PopupTemplate.DotNetComponentReference;
                    }

                    break;
            }
        }

        return null;
    }
    
    /// <summary>
    ///     For internal use only, this looks up a missing <see cref="DotNetObjectReference"/> for an <see cref="ActionBase"/> and returns it to JavaScript.
    /// </summary>
    [JSInvokable]
    public DotNetObjectReference<MapComponent>? GetDotNetActionObjectReference(Guid actionId)
    {
        if (_isDisposed) return null;
        foreach (Graphic graphic in Graphics)
        {
            if (graphic.PopupTemplate?.Actions is null)
            {
                continue;
            }
            
            foreach (ActionBase action in graphic.PopupTemplate.Actions)
            {
                if (action.Id == actionId)
                {
                    return action.DotNetComponentReference;
                }
            }
        }

        if (Map is null)
        {
            return null;
        }

        foreach (Layer layer in Map!.Layers)
        {
            switch (layer)
            {
                case FeatureLayer featureLayer:
                    if (featureLayer.PopupTemplate?.Actions is { } actions)
                    {
                        foreach (ActionBase action in actions)
                        {
                            if (action.Id == actionId)
                            {
                                return action.DotNetComponentReference;
                            }
                        }
                    }

                    if (featureLayer.Source is not null)
                    {
                        foreach (Graphic graphic in featureLayer.Source)
                        {
                            if (graphic.PopupTemplate?.Actions is not { } graphicActions)
                            {
                                continue;
                            }

                            foreach (ActionBase action in graphicActions)
                            {
                                if (action.Id == actionId)
                                {
                                    return action.DotNetComponentReference;
                                }
                            }
                        }
                    }

                    break;
                case GraphicsLayer graphicsLayer:
                    foreach (Graphic graphic in graphicsLayer.Graphics)
                    {
                        if (graphic.PopupTemplate?.Actions is not { } graphicActions)
                        {
                            continue;
                        }

                        foreach (ActionBase action in graphicActions)
                        {
                            if (action.Id == actionId)
                            {
                                return action.DotNetComponentReference;
                            }
                        }
                    }

                    break;
                case IPopupTemplateLayer templateLayer:
                    if (templateLayer.PopupTemplate?.Actions is { } templateLayerActions)
                    {
                        foreach (ActionBase action in templateLayerActions)
                        {
                            if (action.Id == actionId)
                            {
                                return action.DotNetComponentReference;
                            }
                        }
                    }

                    break;
            }
        }

        return null;
    }

#endregion


#region Public Methods

    /// <inheritdoc />
    public override ValueTask Refresh()
    {
        NeedsRender = true;
        ExtentSetByCode = false;
        ExtentChangedInJs = false;
        StateHasChanged();
        return ValueTask.CompletedTask;
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
        await CoreJsModule!.InvokeVoidAsync("queryFeatureLayer",
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
        await CoreJsModule!.InvokeVoidAsync("findPlaces", CancellationTokenSource.Token,
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
        await CoreJsModule!.InvokeVoidAsync("showPopup", CancellationTokenSource.Token,
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
        await CoreJsModule!.InvokeVoidAsync("showPopupWithGraphic", CancellationTokenSource.Token,
            (object)graphic, (object)options, Id);
    }

    /// <summary>
    ///     Opens the popup at the given location with content defined either explicitly with content or driven from the PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively open the popup by directly setting the visible property to true.
    /// </summary>
    /// <param name="options">
    ///     Defines the location and content of the popup when opened.
    /// </param>
    public async Task OpenPopup(PopupOpenOptions? options = null)
    {
        await CoreJsModule!.InvokeVoidAsync("openPopup", CancellationTokenSource.Token, Id, options);
    }

    /// <summary>
    ///     Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly setting the visible property to false.
    /// </summary>
    public async Task ClosePopup()
    {
        await CoreJsModule!.InvokeVoidAsync("closePopup", CancellationTokenSource.Token, Id);
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
            graphic.Parent = this;
            graphic.AllowRender = false;
        }

        if (CoreJsModule is null || !MapRendered) return;
        
        int chunkSize = GraphicSerializationChunkSize ?? (IsMaui ? 100 : 200);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        if (IsWebAssembly)
        {
            for (var index = 0; index < newGraphics.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                ProtoGraphicCollection collection =
                    new(newGraphics.Skip(skip).Take(chunkSize).Select(g => g.ToSerializationRecord(true)).ToArray());
                MemoryStream ms = new();
                Serializer.Serialize(ms, collection);

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    await ms.DisposeAsync();

                    return;
                }

                ms.Seek(0, SeekOrigin.Begin);
                ((IJSInProcessObjectReference)CoreJsModule).InvokeVoid("addGraphicsSynchronously", 
                    ms.ToArray(), Id, null);
                await ms.DisposeAsync();
                await Task.Delay(1, cancellationToken);
            }
        }
        else if (IsMaui)
        {
            // MAUI at least on windows seems to occasionally throw an exception when adding graphics from multiple threads
            for (var index = 0; index < newGraphics.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }
                
                ProtoGraphicCollection collection = new(newGraphics.Skip(skip).Take(chunkSize)
                    .Select(g => g.ToSerializationRecord(true)).ToArray());
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

                await CoreJsModule.InvokeVoidAsync("addGraphicsFromStream", cancellationToken,
                    streamRef, Id, abortSignal, null);
            }
        }
        else
        {
            List<Task> serializationTasks = [];

            for (var index = 0; index < newGraphics.Count; index += chunkSize)
            {
                int skip = index;

                serializationTasks.Add(Task.Run(async () =>
                {
                    if (cancellationToken.IsCancellationRequested ||
                        CancellationTokenSource.Token.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    ProtoGraphicCollection collection = new(newGraphics.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray());
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

                    await CoreJsModule.InvokeVoidAsync("addGraphicsFromStream", cancellationToken,
                        streamRef, Id, abortSignal, null);
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
            graphic.Parent = this;
            _graphics.Add(graphic);

            if (CoreJsModule is null) return;

            ProtoGraphicCollection collection = new([graphic.ToSerializationRecord(true)]);
            MemoryStream ms = new();
            Serializer.Serialize(ms, collection);
            ms.Seek(0, SeekOrigin.Begin);
            using DotNetStreamReference streamRef = new(ms);

            await CoreJsModule.InvokeVoidAsync("addGraphic", CancellationTokenSource.Token,
                streamRef, Id, null);
        }
    }

    /// <summary>
    ///     Clears all graphics from the view.
    /// </summary>
    public async Task ClearGraphics()
    {
        AllowRender = false;

        _graphics.Clear();
        if (CoreJsModule is not null)
        {
            await CoreJsModule!.InvokeVoidAsync("clearGraphics", CancellationTokenSource.Token, Id);    
        }
        
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
    /// <param name="isBasemapReferenceLayer">
    ///     If true, adds the layer as a Basemap Reference Layer.
    /// </param>
    public Task AddLayer(Layer layer, bool isBasemapLayer = false, bool isBasemapReferenceLayer = false)
    {
        if (isBasemapLayer && layer.IsBasemapReferenceLayer != true)
        {
            Map!.Basemap ??= new Basemap();
            
#pragma warning disable BL0005
            Map.Basemap.BaseLayers ??= [];
            Map.Basemap.BaseLayers = [..Map.Basemap.BaseLayers, layer];
            layer.Parent ??= Map.Basemap;
        }
        else if (isBasemapReferenceLayer || layer.IsBasemapReferenceLayer == true)
        {
            Map!.Basemap ??= new Basemap();
            Map.Basemap.ReferenceLayers ??= [];
            Map.Basemap.ReferenceLayers = [..Map.Basemap.ReferenceLayers, layer];
            layer.Parent ??= Map.Basemap;
            layer.IsBasemapReferenceLayer = true;
#pragma warning restore BL0005
        }
        else
        {
            Map!.Layers.Add(layer);
            layer.Parent ??= Map;
        }
        
        layer.View ??= this;

        if (CoreJsModule is null || !MapRendered) return Task.CompletedTask;

        _newLayers.Add((layer, isBasemapLayer, isBasemapReferenceLayer));
        StateHasChanged();
        return Task.CompletedTask;
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
    /// <param name="isReferenceLayer">
    ///     If true, removes the layer as a Basemap Reference Layer
    /// </param>
    public async Task RemoveLayer(Layer layer, bool isBasemapLayer = false, bool isReferenceLayer = false)
    {
        var removed = false;

        if (isBasemapLayer && layer.IsBasemapReferenceLayer != true)
        {
            if (Map?.Basemap?.BaseLayers?.Contains(layer) == true)
            {
#pragma warning disable BL0005
                Map.Basemap.BaseLayers = Map.Basemap.BaseLayers.Except([layer]).ToList();
                layer.Parent = null;
                removed = true;
            }
        }
        if (isReferenceLayer || layer.IsBasemapReferenceLayer == true)
        {
            if (Map?.Basemap?.ReferenceLayers?.Contains(layer) == true)
            {
                Map.Basemap.ReferenceLayers = Map.Basemap.ReferenceLayers.Except([layer]).ToList();
#pragma warning restore BL0005
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

        if (CoreJsModule is null || !removed) return;

        await CoreJsModule.InvokeVoidAsync("removeLayer", CancellationTokenSource.Token,
            layer.Id, Id, isBasemapLayer, isReferenceLayer);
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
        await CoreJsModule!.InvokeVoidAsync("solveServiceArea", CancellationTokenSource.Token,
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

        if (CoreJsModule is null) return;

        await CoreJsModule.InvokeVoidAsync("removeGraphic", CancellationTokenSource.Token,
            graphic.Id, Id);
        graphic.Parent = null;
        graphic.View = null;
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

        if (CoreJsModule is null) return;

        await CoreJsModule.InvokeVoidAsync("removeGraphics", CancellationTokenSource.Token,
            oldGraphics.Select(g => g.Id), Id);
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

            if (CoreJsModule is null || !MapRendered) return;

            ViewExtentUpdate change =
                await CoreJsModule.InvokeAsync<ViewExtentUpdate>("setCenter",
                    CancellationTokenSource.Token, (object)point, Id);
            Extent = change.Extent;
            Zoom = change.Zoom;
            Scale = change.Scale;
            Rotation = change.Rotation ?? Rotation;
            ShouldUpdate = true;
        }
    }

    /// <summary>
    ///     Sets the background color of the view.
    /// </summary>
    public async Task SetBackgroundColor(MapColor backgroundColor)
    {
        BackgroundColor = backgroundColor;
        if (CoreJsModule is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setBackgroundColor", CancellationTokenSource.Token, Id, backgroundColor);
    }

    /// <summary>
    ///     Returns the center <see cref="Point" /> of the current view extent.
    /// </summary>
    public async Task<Point?> GetCenter()
    {
        Point? center = null;

        if (CoreJsModule is not null && MapRendered)
        {
            center = await CoreJsModule.InvokeAsync<Point?>("getCenter", CancellationTokenSource.Token, Id);

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

        if (CoreJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await CoreJsModule.InvokeAsync<ViewExtentUpdate>("setZoom", CancellationTokenSource.Token, Zoom, Id);
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
        if (CoreJsModule is not null)
        {
            Zoom = await CoreJsModule.InvokeAsync<double>("getZoom", CancellationTokenSource.Token, Id);
        }

        return Zoom;
    }

    /// <summary>
    ///     Sets the scale of the current view.
    /// </summary>
    public virtual async Task SetScale(double scale)
    {
        Scale = scale;

        if (CoreJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await CoreJsModule.InvokeAsync<ViewExtentUpdate>("setScale",
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
        if (CoreJsModule is not null)
        {
            Scale = await CoreJsModule.InvokeAsync<double>("getScale", CancellationTokenSource.Token, Id);
        }

        return Scale;
    }

    /// <summary>
    ///     Sets the rotation of the current view.
    /// </summary>
    public async Task SetRotation(double rotation)
    {
        Rotation = rotation;

        if (CoreJsModule is not null && MapRendered)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await CoreJsModule.InvokeAsync<ViewExtentUpdate>("setRotation",
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
        if (CoreJsModule is not null)
        {
            Rotation = await CoreJsModule.InvokeAsync<double>("getRotation", CancellationTokenSource.Token, Id);
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

            if (CoreJsModule is null || !MapRendered) return;

            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await CoreJsModule.InvokeAsync<ViewExtentUpdate>("setExtent",
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
        if (CoreJsModule is not null)
        {
            Extent = await CoreJsModule.InvokeAsync<Extent?>("getExtent", CancellationTokenSource.Token, Id);
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

            if (CoreJsModule is null) return;

            await CoreJsModule.InvokeVoidAsync("setConstraints",
                CancellationTokenSource.Token, (object)Constraints, Id);
        }
        
        ModifiedParameters[nameof(Constraints)] = constraints;
    }

    /// <summary>
    ///     Sets the <see cref="HighlightOptions" /> of the view.
    /// </summary>
    public async Task SetHighlightOptions(HighlightOptions highlightOptions)
    {
        if (!highlightOptions.Equals(HighlightOptions))
        {
            HighlightOptions = highlightOptions;

            if (CoreJsModule is null) return;

            await CoreJsModule.InvokeVoidAsync("setHighlightOptions",
                CancellationTokenSource.Token, (object)HighlightOptions, Id);
        }
        
        ModifiedParameters[nameof(HighlightOptions)] = highlightOptions;
    }

    /// <summary>
    ///     Sets the <see cref="SpatialReference" /> of the view.
    /// </summary>
    public async Task SetSpatialReference(SpatialReference spatialReference)
    {
        if (!spatialReference.Equals(SpatialReference))
        {
            SpatialReference = spatialReference;

            if (CoreJsModule is null) return;

            await CoreJsModule.InvokeVoidAsync("setSpatialReference",
                CancellationTokenSource.Token, (object)SpatialReference, Id);
        }
        
        ModifiedParameters[nameof(SpatialReference)] = spatialReference;
    }

    /// <summary>
    ///     Returns the current <see cref="SpatialReference" /> of the view.
    /// </summary>
    public async Task<SpatialReference?> GetSpatialReference()
    {
        if (CoreJsModule is not null)
        {
            SpatialReference = await CoreJsModule.InvokeAsync<SpatialReference?>("getSpatialReference",
                CancellationTokenSource.Token, Id);
        }

        return SpatialReference;
    }

    /// <summary>
    ///     Retrieves the Popup Widget for the view.
    /// </summary>
    public Task<PopupWidget?> GetPopupWidget()
    {
        if (!Widgets.Any(w => w is PopupWidget) && CoreJsModule is not null)
        {
            // add as custom logic since this is before `MapRendered` and calling `AddWidget` will exit early
            var popupWidget = new PopupWidget
            {
                Parent = this,
                View = this,
                CoreJsModule = CoreJsModule
            };
            _newWidgets.Add(popupWidget);
            StateHasChanged();
        }

        return Task.FromResult(Widgets.FirstOrDefault(w => w is PopupWidget) as PopupWidget);
    }

    /// <summary>
    ///     Changes the view <see cref="Extent" /> and redraws.
    /// </summary>
    /// <param name="extent">
    ///     The new <see cref="Extent" /> of the view.
    /// </param>
    public async Task GoTo(Extent extent)
    {
        if (CoreJsModule is null || !MapRendered) return;

        ShouldUpdate = false;
        ExtentSetByCode = true;

        ViewExtentUpdate change =
            await CoreJsModule.InvokeAsync<ViewExtentUpdate>("goToExtent",
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
        if (CoreJsModule is null || !MapRendered) return;

        ShouldUpdate = false;
        ExtentSetByCode = true;

        ViewExtentUpdate change =
            await CoreJsModule.InvokeAsync<ViewExtentUpdate>("goToGraphics",
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
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="clickEvent">
    ///     The click event to test for hits.
    /// </param>
    public async Task<HitTestResult> HitTest(ClickEvent clickEvent)
    {
        return await HitTest(clickEvent, null);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="clickEvent">
    ///     The click event to test for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(ClickEvent clickEvent, HitTestOptions? options)
    {
        return await HitTestImplementation(new ScreenPoint(clickEvent.X, clickEvent.Y), options);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The pointer event to test for hits.
    /// </param>
    public async Task<HitTestResult> HitTest(PointerEvent pointerEvent)
    {
        return await HitTest(pointerEvent, null);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="pointerEvent">
    ///     The pointer event to test for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(PointerEvent pointerEvent, HitTestOptions? options)
    {
        return await HitTestImplementation(new ScreenPoint(pointerEvent.X, pointerEvent.Y), options);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="screenPoint">
    ///     The screen point to check for hits.
    /// </param>
    public async Task<HitTestResult> HitTest(ScreenPoint screenPoint)
    {
        return await HitTest(screenPoint, null);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="screenPoint">
    ///     The screen point to check for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(ScreenPoint screenPoint, HitTestOptions? options)
    {
        return await HitTestImplementation(screenPoint, options);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="mapPoint">
    ///     The map point, in the same projection as the map, to check for hits.
    /// </param>
    public async Task<HitTestResult> HitTest(Point mapPoint)
    {
        return await HitTest(mapPoint, null);
    }

    /// <summary>
    ///     Returns <see cref="HitTestResult" />s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.
    /// </summary>
    /// <param name="mapPoint">
    ///     The map point, in the same projection as the map, to check for hits.
    /// </param>
    /// <param name="options">
    ///     Options to specify what is included in or excluded from the hitTest.
    /// </param>
    public async Task<HitTestResult> HitTest(Point mapPoint, HitTestOptions? options)
    {
        ScreenPoint screenPoint = await ToScreen(mapPoint);
        return await HitTestImplementation(screenPoint, options);
    }

    /// <summary>
    ///     Converts the given screen point to a map point. The screen point represents a point in terms of pixels relative to the top-left corner of the view.
    /// </summary>
    public async Task<Point> ToMap(ScreenPoint screenPoint)
    {
        return await CoreJsModule!.InvokeAsync<Point>("toMap",
            CancellationTokenSource.Token, screenPoint, Id);
    }

    /// <summary>
    ///     Converts the given map point to a screen point. The screen point represents a point in terms of pixels relative to the top-left corner of the view.
    /// </summary>
    public async Task<ScreenPoint> ToScreen(Point mapPoint)
    {
        return await CoreJsModule!.InvokeAsync<ScreenPoint>("toScreen",
            CancellationTokenSource.Token, mapPoint, Id);
    }

    /// <summary>
    ///     Returns the current cursor when hovering over the view.
    /// </summary>
    public async Task<string> GetCursor()
    {
        return await CoreJsModule!.InvokeAsync<string>("getCursor",
            CancellationTokenSource.Token, Id);
    }
    
    /// <summary>
    ///     Sets the cursor for the view.
    /// </summary>
    public async Task SetCursor(string cursor)
    {
        await CoreJsModule!.InvokeVoidAsync("setCursor",
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
        await CancellationTokenSource.CancelAsync();
        try
        {
            if (CoreJsModule != null)
            {
                await CoreJsModule.InvokeVoidAsync("disposeView",
                    CancellationTokenSource.Token, Id);
            }
        }
        catch (TaskCanceledException)
        {
            // user cancelled
        }
        catch (JSDisconnectedException)
        {
            // lost connection (page navigation)
        }
        catch (JSException)
        {
            // instance already destroyed
        }

        _isDisposed = true;
    }

    /// <summary>
    ///     Adds a widget to the view.
    /// </summary>
    public Task AddWidget(Widget widget)
    {
        if (_widgets.Add(widget))
        {
            widget.Parent ??= this;
            widget.View ??= this;
            widget.CoreJsModule ??= CoreJsModule;
        }

        if (CoreJsModule is null || !widget.ArcGISWidget || !MapRendered) return Task.CompletedTask;

        _newWidgets.Add(widget);
        StateHasChanged();

        return Task.CompletedTask;
    }

    /// <summary>
    ///     Removes a widget from the view.
    /// </summary>
    public async Task RemoveWidget(Widget widget)
    {
        if (CoreJsModule is null) return;

        if (_widgets.Contains(widget))
        {
            _widgets.Remove(widget);
            widget.Parent = null;
        }

        await InvokeAsync(async () =>
        {
            try
            {
                await CoreJsModule.InvokeVoidAsync("removeWidget",
                    CancellationTokenSource.Token, widget.Id, Id);
            }
            catch (JSDisconnectedException)
            {
                // ignore, dispose is called by Blazor too early
            }
        });
    }

    /// <summary>
    ///     Create a screenshot of the current view. Screenshots include only elements that are rendered on the canvas (all geographical elements), but excludes overlayed DOM elements (UI, popups, measurement labels, etc.). By default, a screenshot of the whole view is created. Different options allow for creating different types of screenshots, including taking screenshots at different aspect ratios, different resolutions and creating thumbnails.
    /// </summary>
    /// <param name="options">
    ///     Optional settings for the screenshot.
    /// </param>
    /// <returns>
    ///     Returns a <see cref="Screenshot"/> which includes a Base64 data url as well as raw image data in a byte array.
    /// </returns>
    public async Task<Screenshot> TakeScreenshot(ScreenshotOptions? options = null)
    {
        try
        {
            JsScreenshot jsScreenshot = await CoreJsModule!.InvokeAsync<JsScreenshot>("takeScreenshot",
                CancellationTokenSource.Token, Id, options);
            Stream mapStream = await jsScreenshot.Stream.OpenReadStreamAsync(1_000_000_000L);
            MemoryStream ms = new();
            await mapStream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] data = ms.ToArray();
            string base64 = 
                $"data:image/{(options?.Format == ScreenshotFormat.Jpg ? "jpg" : "png")};base64,{Convert.ToBase64String(data)}";

            Screenshot screenshot = new(base64, new ImageData(data, jsScreenshot.ColorSpace,
                jsScreenshot.Width, jsScreenshot.Height));
            await mapStream.DisposeAsync();
            await ms.DisposeAsync();

            return screenshot;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
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
        await base.OnAfterRenderAsync(firstRender);
        AbortManager ??= new AbortManager(CoreJsModule!);

        if (!LoadOnRender && !_renderCalled)
        {
            NeedsRender = false;
        }

        if (firstRender)
        {
            try
            {
                await AppValidator.ValidateLicense();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                StateHasChanged();
                throw;
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

        if (MapRendered)
        {
            if (_newLayers.Any())
            {
                (Layer Layer, bool IsBasemapLayer, bool IsBasemapReferenceLayer)[] newLayers = _newLayers.ToArray();
                _newLayers.Clear();
                foreach ((Layer newLayer, bool isBasemapLayer, bool isBasemapReferenceLayer) in newLayers)
                {
                    await CoreJsModule!.InvokeVoidAsync("addLayer", CancellationTokenSource.Token,
                        (object)newLayer, Id, isBasemapLayer, isBasemapReferenceLayer);
                }
            }


            if (_newWidgets.Any())
            {
                Widget[] newWidgets = _newWidgets.ToArray();
                _newWidgets.Clear();
                foreach (Widget newWidget in newWidgets)
                {
                    await CoreJsModule!.InvokeVoidAsync("addWidget",
                        CancellationTokenSource.Token, newWidget, Id);

                    if (newWidget is PopupWidget && Map is not null)
                    {
                        // we have to update the layers to make sure the popupTemplates aren't unset by this action
                        foreach (Layer layer in Map!.Layers.Where(l => l is FeatureLayer { PopupTemplate: not null }))
                        {
                            // ReSharper disable once RedundantCast
                            await layer.UpdateLayer();
                        }
                    }
                }
            }
        }
    }

    /// <inheritdoc />
    protected override async Task RenderView(bool forceRender = false)
    {
        if (!NeedsRender && !forceRender)
        {
            return;
        }

        if (!AuthenticationInitialized || Rendering || Map is null || CoreJsModule is null) return;

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

        if (Map.Basemap is not null)
        {
#pragma warning disable BL0005
            Map.Basemap!.BaseLayers = Map.Basemap.BaseLayers?.Where(l => !l.Imported).ToList();
            Map.Basemap!.ReferenceLayers = Map.Basemap!.ReferenceLayers?.Where(l => !l.Imported).ToList();
#pragma warning restore BL0005 
        }
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

            await CoreJsModule.InvokeVoidAsync("setAssetsPath", CancellationTokenSource.Token,
                Configuration.GetValue<string?>("ArcGISAssetsPath",
                    "/_content/dymaptic.GeoBlazor.Core/assets"));

            while (Map is null) // race condition in WebAssembly causes the map to be disposed while creating child components within it.
            {
                await Task.Delay(1);
            }

            await CoreJsModule.InvokeVoidAsync("buildMapView", CancellationTokenSource.Token, Id,
                DotNetComponentReference, Longitude, Latitude, Rotation, Map, Zoom, Scale,
                mapType, Widgets, Graphics, SpatialReference, Constraints, Extent, BackgroundColor,
                EventRateLimitInMilliseconds, GetActiveEventHandlers(), IsServer, HighlightOptions, PopupEnabled);
            
            // must be after main render, but before the boolean flags are set
            await GetPopupWidget();

            Rendering = false;
            MapRendered = true;
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

        ViewExtentUpdate? change = await CoreJsModule!.InvokeAsync<ViewExtentUpdate?>("updateView",
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
    public override void ValidateRequiredChildren()
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
        HitTestResult result = await CoreJsModule!.InvokeAsync<HitTestResult>("hitTest",
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
    ///     Retrieves all <see cref="EventCallback" />s and <see cref="Func{TResult}" />s that are listening for JavaScript events.
    /// </summary>
    protected List<string> GetActiveEventHandlers()
    {
        List<string> activeHandlers = [];

        var properties = GetType().GetProperties();

        IEnumerable<PropertyInfo> funcCallbacks = properties.Where(p => p.PropertyType.Name.StartsWith("Func"));

        activeHandlers.AddRange(funcCallbacks.Select(x => x.Name));

        IEnumerable<PropertyInfo> eventCallbacks = properties.Where(p => p.PropertyType.Name.StartsWith(nameof(EventCallback)));

        foreach (PropertyInfo callbackInfo in eventCallbacks)
        {
            object? callback = callbackInfo.GetValue(this);

            if(callback is not null)
            {
                bool hasDelegate = callback switch
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
    ///     A boolean flag to indicate that the map extent has been modified in code, and therefore should not be modifiable by markup until <see cref="Refresh" /> is called
    /// </summary>
    protected bool ExtentSetByCode = false;
    /// <summary>
    ///     Indicates that the pointer is currently down, to prevent updating the extent during this action.
    /// </summary>
    protected bool PointerDown;
    
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
    private HashSet<Graphic> _graphics = [];
    private HashSet<Widget> _widgets = [];
    private HashSet<(Layer Layer, bool IsBasemapLayer, bool IsBasemapReferenceLayer)> _newLayers = [];
    private HashSet<Widget> _newWidgets = [];
    private bool? _isPro;
    private Dictionary<Guid, ViewHit[]> _activeHitTests = new();
    private bool _isDisposed;
    private bool _waitingForRender;

#endregion
}
