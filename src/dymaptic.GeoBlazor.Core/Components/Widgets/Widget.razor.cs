namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The base class for widgets. Each widget's presentation is separate from its properties, methods, and data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(WidgetConverter))]
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
    ///     The id of an external HTML Element (div). If provided, the widget will be placed inside that element, instead of on
    ///     the map.
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
    public string? Icon { get; set; }
    
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

    [JSInvokable]
    public override async Task OnJsComponentCreated(IJSObjectReference jsComponentReference)
    {
        await base.OnJsComponentCreated(jsComponentReference);
        await OnWidgetCreated.InvokeAsync(this);
    }

    /// <summary>
    ///     Indicates if the widget is hidden. For internal use only.
    /// </summary>
    protected virtual bool Hidden => false;
    
    /// <summary>
    ///     Indicates that the widget is sent to ArcGIS JS to render. Custom GeoBlazor Widgets should override this to return false.
    /// </summary>
    protected internal virtual bool ArcGISWidget => true;
    
    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // the value type of the parameters dictionary changed in .NET 8 to nullable objects.
        IReadOnlyDictionary<string, object?> dictionary = parameters.ToDictionary();

        if (!dictionary.ContainsKey(nameof(View)) && !dictionary.ContainsKey(nameof(MapView)))
        {
            throw new MissingMapViewReferenceException("Widgets outside the MapView must have the MapView parameter set.");
        }
        await base.SetParametersAsync(parameters);
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        await base.RegisterChildComponent(child);
        WidgetChanged = true;
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        await base.UnregisterChildComponent(child);
        WidgetChanged = true;
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        WidgetChanged = true;
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (WidgetChanged && MapRendered)
        {
            await UpdateWidget();
        }
        
        if (View is null && MapView is not null && !_externalWidgetRegistered)
        {
            await MapView!.AddWidget(this);
            _externalWidgetRegistered = true;
        }
    }
    
    private async Task UpdateWidget()
    {
        WidgetChanged = false;

        if (CoreJsModule is null) return;

        // ReSharper disable once RedundantCast
        await CoreJsModule!.InvokeVoidAsync("updateWidget", CancellationTokenSource.Token,
            (object)this, View!.Id);
    }

    /// <summary>
    ///     Indicates if the widget has changed since the last render.
    /// </summary>
    protected bool WidgetChanged;

    private bool _externalWidgetRegistered;
}

/// <summary>
///     Exception raised if an external component is missing a required reference to a <see cref="MapView"/>
/// </summary>
public class MissingMapViewReferenceException: Exception
{
    /// <summary>
    ///    Exception raised if an external component is missing a required reference to a <see cref="MapView"/>
    /// </summary>
    public MissingMapViewReferenceException(string message) : base(message)
    {
    }
}