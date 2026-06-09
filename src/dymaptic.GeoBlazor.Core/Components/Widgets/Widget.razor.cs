namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The base class for widgets. Each widget's presentation is separate from its properties, methods, and data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(WidgetConverter))]
[CodeGenerationIgnore]
public abstract partial class Widget : MapComponent
{
    /// <summary>
    ///     The position of the widget in relation to the map view.
    /// </summary>
    /// <remarks>
    ///     Either <see cref="Position" /> or <see cref="ContainerId" /> should be set, but not both.
    /// </remarks>
    [Parameter]
    public OverlayPosition? Position { get; set; }

    /// <summary>
    ///     The id of an external HTML Element (div). If provided, the widget will be placed inside that element, instead of on the map.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContainerId { get; set; }

    /// <summary>
    ///     The type of widget
    /// </summary>
    public abstract WidgetType Type { get; }

    /// <summary>
    ///     Icon which represents the widget. It is typically used when the widget is controlled by another one (e.g. in the Expand widget).
    ///     Default Value:null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Icon { get; set; }

    /// <summary>
    ///     The widget's label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual string? Label { get; set; }

    /// <summary>
    ///     The unique ID assigned to the widget when the widget is created. If not set by the developer, it will default to the container ID, or if that is not present then it will be automatically generated.
    /// </summary>
    [Parameter]
    public string? WidgetId { get; set; }

    /// <summary>
    ///     Event handler to know when the widget has been created.
    /// </summary>
    [Parameter]
    public EventCallback OnWidgetCreated { get; set; }

    /// <summary>
    ///     A reference to the MapView that this widget belongs to.
    /// </summary>
    [Parameter]
    [Obsolete("Use View instead of MapView. This property will be removed in a future release.")]
    public MapView? MapView { get; set; }

    /// <summary>
    ///     Additional attributes to be splatted onto the root HTML element of the widget. This can be used to add custom attributes or override default attributes such as style or class. For example, to set a custom width on a widget, you could use AdditionalAttributes="@(new Dictionary&lt;string, object?&gt; { [&quot;style&quot;] = &quot;width: 300px;&quot; })".
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = [];

    /// <summary>
    ///     Indicates if the widget is hidden. For internal use only.
    /// </summary>
    [JsonInclude]
    protected virtual bool Hidden => false;

    /// <summary>
    ///     Indicates that this widget renders as an ArcGIS map component (web component) instead of
    ///     using the imperative ArcGIS JS widget creation pattern.
    ///     When true, the widget renders its own &lt;arcgis-*&gt; tag in Razor markup.
    /// </summary>
    [JsonInclude]
    protected internal virtual bool ArcGISComponent => false;

    /// <summary>
    ///     Indicates that this is a custom GeoBlazor-only widget that is not based on any ArcGIS widget or component.
    ///     When true, the widget is not sent to ArcGIS JS for rendering.
    /// </summary>
    [JsonInclude]
    protected internal virtual bool GeoBlazorWidget => false;

    /// <summary>
    ///     The HTML tag name of the ArcGIS map component that this widget wraps (e.g., "arcgis-legend").
    ///     When non-null, the widget renders as a web component instead of using the imperative widget creation pattern.
    /// </summary>
    [JsonInclude]
    protected internal virtual string? MapComponentTagName => null;

    /// <summary>
    ///     Converts the <see cref="Position"/> to a slot name for web component positioning within arcgis-map/arcgis-scene.
    /// </summary>
    [ArcGISMethod]
    protected string? GetPositionSlot() => Position switch
    {
        OverlayPosition.TopLeft => "top-left",
        OverlayPosition.TopRight => "top-right",
        OverlayPosition.BottomLeft => "bottom-left",
        OverlayPosition.BottomRight => "bottom-right",
        OverlayPosition.TopLeading => "top-leading",
        OverlayPosition.TopTrailing => "top-trailing",
        OverlayPosition.BottomLeading => "bottom-leading",
        OverlayPosition.BottomTrailing => "bottom-trailing",
        OverlayPosition.Manual => "manual",
        _ => null
    };

    /// <summary>
    ///     Helper for rendering boolean values as HTML attributes in generated Razor files.
    /// </summary>
    protected static string? BooleanToAttribute(bool? value) =>
        value?.ToString().ToLowerInvariant();

    /// <summary>
    ///     Helper for rendering inverted boolean values as HTML attributes in generated Razor files.
    ///     Converts an Enabled-style bool to a Disabled-style attribute.
    /// </summary>
    protected static string? InvertBooleanForAttribute(bool? value) =>
        (!value)?.ToString().ToLowerInvariant();

    /// <inheritdoc />
    [JSInvokable]
    public override async ValueTask<MapComponent?> OnJsComponentCreated(IJSObjectReference jsComponentReference,
        IJSStreamReference jsonStreamReference)
    {
        var renderedWidget = await base.OnJsComponentCreated(jsComponentReference, jsonStreamReference) as Widget;
        await OnWidgetCreated.InvokeAsync(this);

        return renderedWidget;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the ContainerId property.
    /// </summary>
    [ArcGISMethod]
    public async Task<string?> GetContainerId()
    {
        if (CoreJsModule is null) return ContainerId;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return ContainerId;

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "containerId");

        if (result is not null)
        {
#pragma warning disable BL0005
            ContainerId = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(ContainerId)] = result;
        }

        return ContainerId;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the Icon property.
    /// </summary>
    [ArcGISMethod]
    public async Task<string?> GetIcon()
    {
        if (CoreJsModule is null) return Icon;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return Icon;

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "icon");

        if (result is not null)
        {
#pragma warning disable BL0005
            Icon = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Icon)] = result;
        }

        return Icon;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the Label property.
    /// </summary>
    [ArcGISMethod]
    public async Task<string?> GetLabel()
    {
        if (CoreJsModule is null) return Label;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return Label;

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "label");

        if (result is not null)
        {
#pragma warning disable BL0005
            Label = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Label)] = result;
        }

        return Label;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the Position property.
    /// </summary>
    [ArcGISMethod]
    public async Task<OverlayPosition?> GetPosition()
    {
        if (CoreJsModule is null) return Position;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return Position;

        // get the property value
        JsNullableEnumWrapper<OverlayPosition>? result =
            await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<OverlayPosition>?>("getProperty",
                CancellationTokenSource.Token, JsComponentReference, "position");

        if (result?.Value is not null)
        {
#pragma warning disable BL0005
            Position = result.Value.Value;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Position)] = result;
        }

        return Position;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the WidgetId property.
    /// </summary>
    [ArcGISMethod]
    public async Task<string?> GetWidgetId()
    {
        if (CoreJsModule is null) return WidgetId;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return WidgetId;

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "widgetId");

        if (result is not null)
        {
#pragma warning disable BL0005
            WidgetId = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(WidgetId)] = result;
        }

        return WidgetId;
    }

    /// <summary>
    ///     Asynchronously set the value of the ContainerId property after render.
    /// </summary>
    public async Task SetContainerId(string? containerId)
    {
#pragma warning disable BL0005
        ContainerId = containerId;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ContainerId)] = containerId;

        if (CoreJsModule is null) return;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return;

        await CoreJsModule.InvokeVoidAsync("setWidgetContainer", CancellationTokenSource.Token,
            JsComponentReference, Type, containerId, ViewId);
    }

    /// <summary>
    ///     Asynchronously set the value of the Icon property after render.
    /// </summary>
    public async Task SetIcon(string? icon)
    {
#pragma warning disable BL0005
        Icon = icon;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Icon)] = icon;

        if (CoreJsModule is null) return;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return;

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference,
            "icon", icon);
    }

    /// <summary>
    ///     Asynchronously set the value of the Label property after render.
    /// </summary>
    public async Task SetLabel(string? label)
    {
#pragma warning disable BL0005
        Label = label;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Label)] = label;

        if (CoreJsModule is null) return;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return;

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference,
            "label", label);
    }

    /// <summary>
    ///     Asynchronously set the value of the Position property after render.
    /// </summary>
    public async Task SetPosition(OverlayPosition? position)
    {
#pragma warning disable BL0005
        Position = position;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Position)] = position;

        if (CoreJsModule is null || View is null) return;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return;

        await CoreJsModule.InvokeVoidAsync("setWidgetPosition", CancellationTokenSource.Token,
            JsComponentReference, position, ViewId);
    }

    /// <summary>
    ///     Asynchronously set the value of the WidgetId property after render.
    /// </summary>
    public async Task SetWidgetId(string? widgetId)
    {
#pragma warning disable BL0005
        WidgetId = widgetId;
#pragma warning restore BL0005
        ModifiedParameters[nameof(WidgetId)] = widgetId;

        if (CoreJsModule is null) return;

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null) return;

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference,
            "widgetId", widgetId);
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        IReadOnlyDictionary<string, object?> dictionary = parameters.ToDictionary();
        await base.SetParametersAsync(parameters);

#pragma warning disable CS0618 // Type or member is obsolete
        if (!dictionary.ContainsKey(nameof(View)) 
            && !dictionary.ContainsKey(nameof(MapView))
            && !dictionary.ContainsKey(nameof(CascadingView)))
        {
            throw new MissingViewReferenceException(
                "Widgets outside the View must have the View parameter set.");
        }

        if (View is null && MapView is not null)
        {
            View = MapView;
        }
#pragma warning restore CS0618 // Type or member is obsolete

        if (PreviousParameters is not null && MapRendered)
        {
            foreach (KeyValuePair<string, object?> kvp in dictionary)
            {
                if (kvp.Key is nameof(View) or nameof(MapRendered)
                    || (kvp.Value?.GetType().Name.Contains("EventCallback") ?? false))
                {
                    continue;
                }

                if (!PreviousParameters.TryGetValue(kvp.Key, out object? previousValue))
                {
                    if (MapRendered)
                    {
                        await UpdateWidget();
                        PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                    }

                    break;
                }

                if (previousValue is null)
                {
                    if (kvp.Value is not null)
                    {
                        if (MapRendered)
                        {
                            await UpdateWidget();
                            PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                        }

                        break;
                    }

                    // both null, no change
                    continue;
                }

                Type paramType = previousValue.GetType();

                if (paramType.IsArray)
                {
                    Array prevArray = (Array)previousValue;
                    Array currArray = (Array)kvp.Value!;

                    if (prevArray.Length != currArray.Length)
                    {
                        if (MapRendered)
                        {
                            await UpdateWidget();
                            PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                        }

                        break;
                    }

                    for (int i = 0; i < prevArray.Length; i++)
                    {
                        if (!Equals(prevArray.GetValue(i), currArray.GetValue(i)))
                        {
                            if (MapRendered)
                            {
                                await UpdateWidget();
                                PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                            }

                            break;
                        }
                    }
                }
                else if (paramType.IsGenericType && previousValue is ICollection prevCollection)
                {
                    ICollection currCollection = (ICollection)kvp.Value!;

                    if (prevCollection.Count != currCollection.Count)
                    {
                        if (MapRendered)
                        {
                            await UpdateWidget();
                            PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                        }

                        break;
                    }

                    IEnumerator prevEnumerator = prevCollection.GetEnumerator();
                    using var prevEnumerator1 = prevEnumerator as IDisposable;
                    IEnumerator currEnumerator = currCollection.GetEnumerator();
                    using var currEnumerator1 = currEnumerator as IDisposable;

                    while (prevEnumerator.MoveNext() && currEnumerator.MoveNext())
                    {
                        if (!Equals(prevEnumerator.Current, currEnumerator.Current))
                        {
                            if (MapRendered)
                            {
                                await UpdateWidget();
                                PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                            }

                            break;
                        }
                    }
                }
                else if (!kvp.Value?.Equals(previousValue) ?? true)
                {
                    if (MapRendered)
                    {
                        await UpdateWidget();
                        PreviousParameters = dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
                    }

                    break;
                }
            }
        }

        // only set PreviousParameters before MapRendered, or after calling UpdateWidget
        PreviousParameters ??= dictionary.ToDictionary(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (View is not null
            && Parent is not Views.MapView
            && Parent is not ExpandWidget
            && !_externalWidgetRegistered)
        {
            // Widgets might be added in markup and registered after the call to View.RenderView, but before that is completed.
            // this loop allows a little time to let the map render before trying to register the widget.
            int tries = 10;

            while (!MapRendered && !IsDisposed && tries > 0)
            {
                await Task.Delay(200);
                tries--;
            }

            await View.AddWidget(this);
            _externalWidgetRegistered = true;
        }

        if (_delayedUpdate)
        {
            await UpdateWidget();
        }
    }

    /// <summary>
    ///     Updates the widget internally. Not intended for public use.
    /// </summary>
    [ArcGISMethod]
    protected async Task UpdateWidget()
    {
        if (MapRendered && !_delayedUpdate)
        {
            // for components added after the map has rendered, wait one render cycle to get all children before updating
            _delayedUpdate = true;
            await InvokeAsync(StateHasChanged);

            return;
        }

        _delayedUpdate = false;

        if (CoreJsModule is null)
        {
            return;
        }

        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch
        {
            // this is expected if the component is not yet built
        }

        if (JsComponentReference is null || !MapRendered || IsDisposed)
        {
            return;
        }

        // ReSharper disable once RedundantCast
        await JsComponentReference.InvokeVoidAsync("updateComponent", CancellationTokenSource.Token, (object)this);
    }

    /// <inheritdoc />
    public override void UpdateGeoBlazorReferences(IJSObjectReference coreJsModule,
        IJSObjectReference? proJsModule,
        MapView? view, IMapComponent? parent, Layer? layer, int depth = 0, HashSet<object>? visited = null)
    {
        bool needsUpdate = layer is not null && (layer.Id != Layer?.Id);

        base.UpdateGeoBlazorReferences(coreJsModule, proJsModule, view, parent, layer, depth, visited);

        if (needsUpdate)
        {
            InvokeAsync(UpdateWidget);
        }
    }

    private bool _externalWidgetRegistered;
    private bool _delayedUpdate;
}

/// <summary>
///     Exception raised if an external component is missing a required reference to a <see cref="MapView" />
/// </summary>
public class MissingViewReferenceException : Exception
{
    /// <summary>
    ///     Exception raised if an external component is missing a required reference to a <see cref="MapView" />
    /// </summary>
    public MissingViewReferenceException(string message) : base(message)
    {
    }
}