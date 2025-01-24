namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a
///     LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent
///     real-world phenomena.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class GraphicsLayer : Layer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public GraphicsLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="graphics">
    ///     A collection of <see cref="Graphic" />s in the layer.
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///     referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Indicates if the layer will allow the client to save the layer's state to local storage.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </param>
    /// <param name="screenSizePerspectiveEnabled">
    ///     Indicates if the layer will display in a perspective view in a SceneView.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer
    /// </param>
    public GraphicsLayer(IReadOnlyCollection<Graphic>? graphics = null, string? title = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null,
        bool? persistenceEnabled = null, double? minScale = null, double? maxScale = null,
        bool? screenSizePerspectiveEnabled = null, BlendMode? blendMode = null)
    {
#pragma warning disable BL0005
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
        PersistenceEnabled = persistenceEnabled;
        MinScale = minScale;
        MaxScale = maxScale;
        ScreenSizePerspectiveEnabled = screenSizePerspectiveEnabled;
        BlendMode = blendMode;

        if (graphics is not null)
        {
            Graphics = graphics;
        }
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode {  get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }
    
    /// <summary>
    ///     Apply perspective scaling to screen-size point symbols in a SceneView. When true, screen sized objects such as icons, labels or callouts integrate better in the 3D scene by applying a certain perspective projection to the sizing of features. This only applies when using a SceneView.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ScreenSizePerspectiveEnabled { get; set; }

    /// <summary>
    ///     A collection of <see cref="Graphic" />s in the layer.
    /// </summary>
    [JsonConverter(typeof(GraphicsToSerializationConverter))]
[CodeGenerationIgnore]
    public IReadOnlyCollection<Graphic> Graphics
    {
        get => _graphics;
        set => _graphics = new HashSet<Graphic>(value);
    }

    /// <inheritdoc />
    public override LayerType Type => LayerType.Graphics;

    /// <summary>
    ///     Add a graphic to the current layer
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to add
    /// </param>
[ArcGISMethod]
    public Task Add(Graphic graphic)
    {
        return Add(new[] { graphic });
    }

    /// <summary>
    ///     Adds a collection of graphics to the graphics layer
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to add
    /// </param>
    /// <param name="cancellationToken">
    ///     A CancellationToken to cancel the operation
    /// </param>
    public async Task Add(IEnumerable<Graphic> graphics, CancellationToken cancellationToken = default)
    {
        AllowRender = false;
        var newGraphics = graphics.ToList();
        _graphics.UnionWith(newGraphics);

        foreach (Graphic graphic in newGraphics)
        {
            graphic.View = View;
            graphic.LayerId = Id;
            graphic.Parent = this;
        }

        if (View is null || !View.MapRendered)
        {
            LayerChanged = true;
            UpdateState();

            return;
        }

        var records = newGraphics.Select(g => g.ToSerializationRecord()).ToList();
        int chunkSize = View!.GraphicSerializationChunkSize ?? (View.IsMaui ? 100 : 200);
        ProJsModule ??= await JsModuleManager.GetArcGisJsPro(JsRuntime, cancellationToken);
        CoreJsModule ??= await JsModuleManager.GetArcGisJsCore(JsRuntime, ProJsModule, cancellationToken);
        AbortManager ??= new AbortManager(CoreJsModule);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        if (View.IsWebAssembly)
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
                ((IJSInProcessObjectReference)CoreJsModule).InvokeVoid("addGraphicsSynchronously", 
                    ms.ToArray(), View.Id, Id);
                await ms.DisposeAsync();
                await Task.Delay(1, cancellationToken);
            }
        }
        else if (View.IsMaui)
        {
            for (var index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                GraphicSerializationRecord[] recordChunk = records.Skip(skip).Take(chunkSize).ToArray();
                ProtoGraphicCollection collection = new(recordChunk);
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

                await CoreJsModule.InvokeVoidAsync("addGraphicsFromStream",
                    cancellationToken, streamRef, View?.Id, abortSignal, Id);
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

                    GraphicSerializationRecord[] recordChunk = records.Skip(skip).Take(chunkSize).ToArray();
                    ProtoGraphicCollection collection = new(recordChunk);
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

                    await CoreJsModule.InvokeVoidAsync("addGraphicsFromStream",
                        cancellationToken, streamRef, View?.Id, abortSignal, Id);
                }, cancellationToken));
            }

            await Task.WhenAll(serializationTasks);
        }
    }

    /// <summary>
    ///     Remove a graphic from the current layer
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to remove
    /// </param>
    [ArcGISMethod]
    public Task Remove(Graphic graphic)
    {
        return UnregisterChildComponent(graphic);
    }

    /// <summary>
    ///     Removes a set of graphics from the current layer
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to remove
    /// </param>
    public async Task Remove(IEnumerable<Graphic> graphics)
    {
        AllowRender = false;
        var removedGraphics = graphics.ToList();
        var wrapperIds = removedGraphics.Select(g => g.Id).ToList();
        await CoreJsModule!.InvokeVoidAsync("removeGraphics", wrapperIds, View?.Id, Id);
        _graphics.ExceptWith(removedGraphics);
        AllowRender = true;
    }

    /// <summary>
    ///     Removes all graphics from the current layer
    /// </summary>
    public async Task Clear()
    {
        AllowRender = false;
        _graphicsToRender.Clear();
        _graphics.Clear();
        await CoreJsModule!.InvokeVoidAsync("clearGraphics", View!.Id, Id);
        AllowRender = true;
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                _graphicsToRender.Add(graphic);
                UpdateState(false);

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
            case Graphic graphic:
                if (_graphics.Remove(graphic) && CoreJsModule is not null)
                {
                    try
                    {
                        _graphicsToRender.Remove(graphic);

                        await CoreJsModule.InvokeVoidAsync("removeGraphic",
                            CancellationTokenSource.Token, graphic.Id, View?.Id, Id);
                    }
                    catch
                    {
                        // object disposed
                    }
                }
                else
                {
                    LayerChanged = true;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <summary>
    ///     Registers a set of graphics that were created from JavaScript
    /// </summary>
    public void RegisterExistingGraphicsFromJavaScript(IEnumerable<Graphic> graphics)
    {
        foreach (Graphic graphic in graphics)
        {
            _graphics.Add(graphic);
            graphic.Parent = this;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        foreach (Graphic graphic in Graphics)
        {
            graphic.ValidateRequiredChildren();
        }
    }

    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (!firstRender && _graphicsToRender.Any(g => !g.IsDisposed) && !_rendering && View?.MapRendered == true)
        {
            _rendering = true;
            AllowRender = false;
            await Add(_graphicsToRender.Where(g => !g.IsDisposed));
            _graphicsToRender.Clear();
            AllowRender = true;
            _rendering = false;
        }
    }

    private HashSet<Graphic> _graphics = new();
    private HashSet<Graphic> _graphicsToRender = new();
    private bool _rendering;
}

internal class GraphicsToSerializationConverter : JsonConverter<IReadOnlyCollection<Graphic>>
{
    public override IReadOnlyCollection<Graphic>? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            return null;
        }

        List<Graphic> graphics = new();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                break;
            }

            Graphic graphic = JsonSerializer.Deserialize<Graphic>(ref reader, options)!;
            graphics.Add(graphic);
        }

        return graphics;
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyCollection<Graphic> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (Graphic graphic in value)
        {
            JsonSerializer.Serialize(writer, graphic.ToSerializationRecord(), options);
        }

        writer.WriteEndArray();
    }
}

[ProtoContract]
internal record ProtoGraphicCollection
{
    public ProtoGraphicCollection()
    {
    }
    
    public ProtoGraphicCollection(GraphicSerializationRecord[] graphics)
    {
        Graphics = graphics;
    }

    [property: ProtoMember(1)]
    public GraphicSerializationRecord[] Graphics { get; set; } = Array.Empty<GraphicSerializationRecord>();
}