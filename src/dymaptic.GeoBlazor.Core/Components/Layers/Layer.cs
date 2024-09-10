using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector
///     graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store
///     vector data or continuous cells/pixels that store raster data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(LayerConverter))]
public abstract class Layer : MapComponent
{
    /// <summary>
    ///     Used internally to identify the sub type of Layer
    /// </summary>
    [JsonPropertyName("type")]
    public virtual string LayerType => default!;

    /// <summary>
    ///     The opacity of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#opacity">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    /// <summary>
    ///     The title of the layer used to identify it in places such as the [LayerList](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html) widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#title">ArcGIS Maps SDK for JavaScript</a>
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
    ///     The JavaScript object that represents the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IJSObjectReference? JsLayerReference { get; internal set; }

    /// <summary>
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
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
    ///     The full extent of the layer. By default, this is worldwide. This property may be used to set the extent of the
    ///     view to match a layer's extent so that its features appear to fill the view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; set; }
    
    /// <summary>
    ///     Enable persistence of the layer in a WebMap or WebScene.
    ///     Default Value: true
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

    /// <summary>
    ///     Handles conversion from .NET CancellationToken to JavaScript AbortController
    /// </summary>
    public AbortManager? AbortManager { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent extent:
                if (!extent.Equals(FullExtent))
                {
                    FullExtent = extent;
                    LayerChanged = true;
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
            case Extent _:
                FullExtent = null;
                LayerChanged = true;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async ValueTask DisposeAsync()
    {
        if (AbortManager != null)
        {
            await AbortManager.DisposeAsync();
        }

        LayerView?.Dispose();

        if (JsLayerReference is not null)
        {
            try
            {
                await JsLayerReference.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
                // ignore, we have disconnected from the JS runtime
            }
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
        if (JsLayerReference is not null)
        {
            // this layer has already been loaded
            return;
        }
        AbortManager = new AbortManager(JsRuntime);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        IJSObjectReference? arcGisPro = await JsModuleManager.GetArcGisJsPro(JsRuntime, cancellationToken);
        IJSObjectReference arcGisJsInterop = await JsModuleManager.GetArcGisJsCore(JsRuntime, arcGisPro, cancellationToken);

        JsLayerReference = await arcGisJsInterop.InvokeAsync<IJSObjectReference>("createLayer",
            // ReSharper disable once RedundantCast
            cancellationToken, (object)this, true, View?.Id);

        await JsLayerReference.InvokeVoidAsync("load", cancellationToken, abortSignal);

        Layer loadedLayer = await arcGisJsInterop.InvokeAsync<Layer>("getSerializedDotNetObject",
            cancellationToken, Id);
        await UpdateFromJavaScript(loadedLayer);
        await AbortManager.DisposeAbortController(cancellationToken);
    }

    /// <inheritdoc />
    public override void Refresh()
    {
        LayerChanged = true;
        base.Refresh();
    }
    
    /// <summary>
    ///     Sets any property to a new value after initial render. Supports all basic types (strings, numbers, booleans, dictionaries) and properties.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to set.
    /// </param>
    /// <param name="value">
    ///     The new value.
    /// </param>
    public async Task SetProperty(string propertyName, object? value)
    {
        ModifiedParameters[propertyName] = value;
        
        if (JsModule is null) return;
        await JsModule!.InvokeVoidAsync("setProperty", JsLayerReference, 
            propertyName.ToLowerFirstChar(), value);
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        FullExtent?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
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
    protected override async Task OnParametersSetAsync()
    {
        LayerChanged = true;
        await base.OnParametersSetAsync();
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (LayerChanged && MapRendered)
        {
            await UpdateLayer();
        }
    }

    private async Task UpdateLayer()
    {
        LayerChanged = false;

        if (JsModule is null) return;

        if (GetType().Namespace!.Contains("Pro"))
        {
            // ReSharper disable once RedundantCast
            await ProJsModule!.InvokeVoidAsync("updateProLayer", CancellationTokenSource.Token,
                (object)this, View!.Id);
        }
        else
        {
            // ReSharper disable once RedundantCast
            await JsModule!.InvokeVoidAsync("updateLayer", CancellationTokenSource.Token,
                (object)this, View!.Id);
        }
    }

    /// <summary>
    ///     Indicates if the layer has changed since the last render.
    /// </summary>
    public bool LayerChanged;
}

internal class LayerConverter : JsonConverter<Layer>
{
    public override Layer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "feature":
                    return JsonSerializer.Deserialize<FeatureLayer>(ref cloneReader, newOptions);
                case "graphics":
                    return JsonSerializer.Deserialize<GraphicsLayer>(ref cloneReader, newOptions);
                case "geo-json":
                case "geojson":
                    return JsonSerializer.Deserialize<GeoJSONLayer>(ref cloneReader, newOptions);
                case "geo-rss":
                case "georss":
                    return JsonSerializer.Deserialize<GeoRSSLayer>(ref cloneReader, newOptions);
                case "tile":
                    return JsonSerializer.Deserialize<TileLayer>(ref cloneReader, newOptions);
                case "vector-tile":
                    return JsonSerializer.Deserialize<VectorTileLayer>(ref cloneReader, newOptions);
                case "open-street-map":
                    return JsonSerializer.Deserialize<OpenStreetMapLayer>(ref cloneReader, newOptions);
                case "elevation":
                    return JsonSerializer.Deserialize<ElevationLayer>(ref cloneReader, newOptions);
                case "csv":
                    return JsonSerializer.Deserialize<CSVLayer>(ref cloneReader, newOptions);
                case "kml":
                    return JsonSerializer.Deserialize<KMLLayer>(ref cloneReader, newOptions);
                case "wcs":
                    return JsonSerializer.Deserialize<WCSLayer>(ref cloneReader, newOptions);
                case "bing-maps":
                    return JsonSerializer.Deserialize<BingMapsLayer>(ref cloneReader, newOptions);
                case "imagery":
                    return JsonSerializer.Deserialize<ImageryLayer>(ref cloneReader, newOptions);
                case "map-image":
                    return JsonSerializer.Deserialize<MapImageLayer>(ref cloneReader, newOptions);
                case "imagery-tile":
                    return JsonSerializer.Deserialize<ImageryTileLayer>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Layer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}

/// <summary>
///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
/// </summary>
[JsonConverter(typeof(ListModeConverter))]
public enum ListMode
{
#pragma warning disable CS1591
    Show,
    Hide,
    HideChildren
#pragma warning restore CS1591
}

internal class ListModeConverter : JsonConverter<ListMode>
{
    public override ListMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "show" => ListMode.Show,
            "hide" => ListMode.Hide,
            "hide-children" => ListMode.HideChildren,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, ListMode value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(ListMode), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}