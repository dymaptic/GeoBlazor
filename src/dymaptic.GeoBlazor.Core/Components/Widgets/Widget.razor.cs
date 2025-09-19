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
    ///     If the Widget is defined outside of the MapView, this link is required to connect them together.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public MapView? MapView { get; set; }

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
    ///     Indicates if the widget is hidden. For internal use only.
    /// </summary>
    protected virtual bool Hidden => false;

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

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference,
            "containerId", containerId);
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

        await CoreJsModule.InvokeVoidAsync("setWidgetPosition", CancellationTokenSource.Token, View.Id, Id,
            position);
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

        if (!dictionary.ContainsKey(nameof(View)) && !dictionary.ContainsKey(nameof(MapView)))
        {
            throw new MissingMapViewReferenceException(
                "Widgets outside the MapView must have the MapView parameter set.");
        }

        if (PreviousParameters is not null && MapRendered)
        {
            foreach (KeyValuePair<string, object?> kvp in dictionary)
            {
                if (kvp.Key is nameof(View) or nameof(MapRendered)
                    || (kvp.Value?.GetType().Name.Contains("EventCallback") ?? false))
                {
                    continue;
                }

                if (!PreviousParameters.TryGetValue(kvp.Key, out object? previousValue)
                    || (!kvp.Value?.Equals(previousValue) ?? true))
                {
                    await UpdateWidget();
                    break;
                }
            }
        }

        PreviousParameters = dictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (View is null && MapView is not null && !_externalWidgetRegistered)
        {
            // Widgets might be added in markup and registered after the call to MapView.RenderView, but before that is completed.
            // this loop allows a little time to let the map render before trying to register the widget.
            int tries = 10;
            while (!MapRendered && !IsDisposed && tries > 0)
            {
                await Task.Delay(200);
                tries--;
            }
            await MapView!.AddWidget(this);
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
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
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
        await JsComponentReference!.InvokeVoidAsync("updateComponent", CancellationTokenSource.Token, (object)this);
    }
    
    private bool _externalWidgetRegistered;
    private bool _delayedUpdate;
}

/// <summary>
///     Exception raised if an external component is missing a required reference to a <see cref="MapView" />
/// </summary>
public class MissingMapViewReferenceException : Exception
{
    /// <summary>
    ///     Exception raised if an external component is missing a required reference to a <see cref="MapView" />
    /// </summary>
    public MissingMapViewReferenceException(string message) : base(message)
    {
    }
}