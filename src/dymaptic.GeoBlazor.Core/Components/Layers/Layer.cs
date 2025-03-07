namespace dymaptic.GeoBlazor.Core.Components.Layers;

[JsonConverter(typeof(LayerConverter))]
public abstract partial class Layer : MapComponent
{
    /// <summary>
    ///     Used internally to identify the sub type of Layer
    /// </summary>
    public abstract LayerType Type { get; }
    
    /// <summary>
    ///     The opacity of the layer.
    ///     default 1
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#opacity">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    /// <summary>
    ///     The title of the layer used to identify it in places such as the [Legend](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html) and [LayerList](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html) widgets.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureLayerBase.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Represents the view for a single layer after it has been added to either a MapView or a SceneView.
    /// </summary>
    [JsonIgnore]
    public LayerView? LayerView { get; internal set; }


    /// <summary>
    ///     Indicates how the layer should display in the [LayerList](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html) widget.
    ///     default "show"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ListMode? ListMode { get; set; }
    
    /// <summary>
    ///     If the layer is added to the <see cref="Basemap"/>, this flag identifies the layer as a reference layer,
    ///     which will sit on top of other layers to add labels.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#referenceLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsBasemapReferenceLayer { get; set; }

    /// <summary>
    ///     The full extent of the layer. By default, this is worldwide. This property may be used to set the extent of the view to match a layer's extent so that its features appear to fill the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureLayerBase.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; set; }
    
    /// <summary>
    ///     Enable persistence of the layer in a [WebMap](https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html) or [WebScene](https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html).
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-OperationalLayer.html#persistenceEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PersistenceEnabled { get; set; }

    /// <summary>
    ///     Specifies a fixed [time extent](https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeExtent.html) during which a layer should be visible.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visibilityTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? VisibilityTimeExtent { get; set; }

    /// <summary>
    ///     Marks an incoming layer loaded from a service or Javascript source.
    /// </summary>
    public bool Imported { get; set; }

#region PropertySetters

    /// <summary>
    ///    Asynchronously set the value of the FullExtent property after render.
    /// </summary>
    public async Task SetFullExtent(Extent? value)
    {
        FullExtent = value;
        ModifiedParameters["FullExtent"] = value;

        if (JsComponentReference is null)
        {
            return;
        }
            
        await JsComponentReference!.InvokeVoidAsync("setProperty", 
            CancellationTokenSource.Token,
            JsComponentReference,
            "fullExtent", 
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Opacity property after render.
    /// </summary>
    public async Task SetOpacity(double value)
    {
        Opacity = value;
        ModifiedParameters["Opacity"] = value;

        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync("setProperty", 
            CancellationTokenSource.Token,
            JsComponentReference,
            "opacity", 
            value);
    }

#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the FullExtent property.
    /// </summary>
    public async Task<Extent?> GetFullExtent()
    {
        if (JsComponentReference is null)
        {
            return null;
        }
            
        return await JsComponentReference!.InvokeAsync<Extent>("getProperty", 
            CancellationTokenSource.Token,
            JsComponentReference, 
            "fullExtent");
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Opacity property.
    /// </summary>
    public async Task<double?> GetOpacity()
    {
        if (JsComponentReference is null)
        {
            return null;
        }
        
        return await JsComponentReference!.InvokeAsync<double>("getProperty", 
            CancellationTokenSource.Token,
            JsComponentReference, 
            "opacity");
    }


#endregion

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent extent:
                if (!extent.Equals(FullExtent))
                {
                    FullExtent = extent;
                    LayerChanged = MapRendered;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                LayerChanged = MapRendered;
                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent _:
                FullExtent = null;
                LayerChanged = MapRendered;

                break;
            default:
                await base.UnregisterChildComponent(child);
                LayerChanged = MapRendered;
                break;
        }
    }

    /// <inheritdoc />
    public override async ValueTask DisposeAsync()
    {
        try
        {
            if (AbortManager is not null)
            {
                await AbortManager.DisposeAsync();
            }

            if (LayerView is not null)
            {
                await LayerView.DisposeAsync();
            }

            if (JsComponentReference is not null)
            {
                try
                {
                    await JsComponentReference.DisposeAsync();
                }
                catch (JSDisconnectedException)
                {
                    // ignore, we have disconnected from the JS runtime
                }
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

        await base.DisposeAsync();
    }

    /// <summary>
    ///     Loads the resources referenced by this class. This method automatically executes for a View and all of the
    ///     resources it references in Map if the view is constructed with a map instance.
    ///     This method must be called by the developer when accessing a resource that will not be loaded in a View.
    ///     The load() method only triggers the loading of the resource the first time it is called. The subsequent calls
    ///     return the same promise.
    /// </summary>
    /// <remarks>
    ///     It's possible to provide a signal to stop being interested into a Loadable instance load status. When the signal is
    ///     aborted, the instance does not stop its loading process, only cancelLoad can abort it.
    /// </remarks>
    public async Task Load(CancellationToken cancellationToken = default)
    {
        if (JsComponentReference is not null)
        {
            // this layer has already been loaded
            return;
        }
        AbortManager = new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        JsComponentReference = await CoreJsModule!.InvokeAsync<IJSObjectReference>("buildJsLayer",
            // ReSharper disable once RedundantCast
            cancellationToken, (object)this, Id, View?.Id);

        Layer loadedLayer = await JsComponentReference.InvokeAsync<Layer>("load", cancellationToken, abortSignal);

        await UpdateFromJavaScript(loadedLayer);
        await AbortManager.DisposeAbortController(cancellationToken);
    }

    /// <inheritdoc/>
    public override async ValueTask Refresh()
    {
        LayerChanged = MapRendered;
        await base.Refresh();
        if (JsComponentReference is null) return;
        
        await JsComponentReference!.InvokeAsync<string?>(
            "refresh", 
            CancellationTokenSource.Token);
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        FullExtent?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }

    [JSInvokable]
    public override async ValueTask<MapComponent?> OnJsComponentCreated(IJSObjectReference jsComponentReference,
        string? instantiatedComponentJson)
    {
        Layer? renderedLayer = await base.OnJsComponentCreated(jsComponentReference, instantiatedComponentJson) as Layer;

        if (renderedLayer is not null)
        {
            await UpdateFromJavaScript(renderedLayer);
        }

        return renderedLayer;
    }

    /// <summary>
    ///     Copies values from the rendered JavaScript layer back to the .NET implementation.
    /// </summary>
    /// <param name="renderedLayer">
    ///     The layer deserialized from JavaScript
    /// </param>
    internal virtual Task UpdateFromJavaScript(Layer renderedLayer)
    {
        FullExtent ??= renderedLayer.FullExtent;

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        IReadOnlyDictionary<string, object?> dictionary = parameters.ToDictionary();
        await base.SetParametersAsync(parameters);
        
        if (PreviousParameters is not null && MapRendered)
        {
            foreach (KeyValuePair<string, object?> kvp in dictionary)
            {
                if (kvp.Key == nameof(View) || kvp.Key == nameof(MapRendered)) continue;
                if (!PreviousParameters.TryGetValue(kvp.Key, out object? previousValue)
                    || (!kvp.Value?.Equals(previousValue) ?? true))
                {
                    LayerChanged = true;

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

        if (LayerChanged)
        {
            await UpdateLayer();
        }
    }

    public async Task UpdateLayer()
    {
        LayerChanged = false;

        if (JsComponentReference is null)
        {
            return;
        }

        // ReSharper disable once RedundantCast
        await JsComponentReference!.InvokeAsync<string?>("updateComponent", CancellationTokenSource.Token, (object)this);
    }

    /// <summary>
    ///     Indicates if the layer has changed since the last render.
    /// </summary>
    public bool LayerChanged;
}