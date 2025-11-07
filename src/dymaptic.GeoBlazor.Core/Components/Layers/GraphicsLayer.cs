namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class GraphicsLayer : Layer
{
    
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public GraphicsLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="graphics">
    ///     A collection of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">graphics</a> in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#graphics">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    ///     default 1
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#opacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     default "show"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="persistenceEnabled">
    ///     When `true`, the layer can be persisted.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#persistenceEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#minScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#maxScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenSizePerspectiveEnabled">
    ///     Apply perspective scaling to screen-size point symbols in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#screenSizePerspectiveEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#blendMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="arcGISLayerId">
    ///     The unique ID assigned to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to
    ///     how image filters work.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#effect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="elevationInfo">
    ///     Specifies how graphics are placed on the vertical axis (z).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#elevationInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fullExtent">
    ///     The full extent of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="isBasemapReferenceLayer">
    ///     Indicates whether the layer is a basemap reference layer. Default value: false.
    /// </param>
    /// <param name="visibilityTimeExtent">
    ///     Specifies a fixed <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">time extent</a> during which a layer should be visible.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visibilityTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="excludeApiKey">
    ///     Indicates whether the layer should exclude the API key when making requests to services. This is a workaround for an ArcGIS bug where public services throw an "Invalid Token" error.
    /// </param>
    [CodeGenerationIgnore]
    public GraphicsLayer(
        IReadOnlyCollection<Graphic>? graphics = null,
        string? title = null,
        double? opacity = null,
        bool? visible = null,
        ListMode? listMode = null,
        bool? persistenceEnabled = null,
        double? minScale = null,
        double? maxScale = null,
        bool? screenSizePerspectiveEnabled = null,
        BlendMode? blendMode = null,
        string? arcGISLayerId = null,
        Effect? effect = null,
        GraphicsLayerElevationInfo? elevationInfo = null,
        Extent? fullExtent = null,
        bool? isBasemapReferenceLayer = null,
        TimeExtent? visibilityTimeExtent = null,
        bool? excludeApiKey = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        if (graphics is not null)
        {
            Graphics = graphics;
        }
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
        PersistenceEnabled = persistenceEnabled;
        MinScale = minScale;
        MaxScale = maxScale;
        ScreenSizePerspectiveEnabled = screenSizePerspectiveEnabled;
        BlendMode = blendMode;
        ArcGISLayerId = arcGISLayerId;
        Effect = effect;
        ElevationInfo = elevationInfo;
        FullExtent = fullExtent;
        IsBasemapReferenceLayer = isBasemapReferenceLayer;
        VisibilityTimeExtent = visibilityTimeExtent;
        ExcludeApiKey = excludeApiKey;
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
        init => _graphics = [..value];
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
    [CodeGenerationIgnore]
    public Task Add(Graphic graphic)
    {
        return Add([graphic]);
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
    [CodeGenerationIgnore]
    public async Task Add(IEnumerable<Graphic> graphics, CancellationToken cancellationToken = default)
    {
        AllowRender = false;
        var newGraphics = graphics.ToList();
        _graphics.UnionWith(newGraphics);

        foreach (Graphic graphic in newGraphics)
        {
            graphic.View = View;
            graphic.Layer = this;
            graphic.LayerId = Id;
            graphic.Parent = this;
        }

        if (View is null || !View.MapRendered)
        {
            if (MapRendered)
            {
                await UpdateLayer();
            }
            UpdateState();

            return;
        }
        
        int chunkSize = View!.GraphicSerializationChunkSize ?? (View.IsMaui ? 100 : 200);
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        if (View.IsWebAssembly)
        {
            for (var index = 0; index < newGraphics.Count; index += chunkSize)
            {
                int skip = index;

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }

                GraphicCollectionSerializationRecord collection =
                    new(newGraphics.Skip(skip).Take(chunkSize).Select(g => g.ToProtobuf()).ToArray());
                MemoryStream ms = new();
                Serializer.Serialize(ms, collection);

                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested)
                {
                    await ms.DisposeAsync();

                    return;
                }

                ms.Seek(0, SeekOrigin.Begin);
                ((IJSInProcessObjectReference)CoreJsModule!).InvokeVoid("addGraphicsSynchronously", 
                    ms.ToArray(), View.Id, Id);
                await ms.DisposeAsync();
                await Task.Delay(1, cancellationToken);
            }
        }
        else if (View.IsMaui)
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
                
                GraphicCollectionSerializationRecord collection = new(newGraphics.Skip(skip).Take(chunkSize)
                    .Select(g => g.ToProtobuf()).ToArray());
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

                await CoreJsModule!.InvokeVoidAsync("addGraphicsFromStream",
                    cancellationToken, streamRef, View?.Id, abortSignal, Id);
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
                    
                    GraphicCollectionSerializationRecord collection = new(newGraphics.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToProtobuf()).ToArray());
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

                    await CoreJsModule!.InvokeVoidAsync("addGraphicsFromStream",
                        cancellationToken, streamRef, View?.Id, abortSignal, Id);
                }, cancellationToken));
            }

            await Task.WhenAll(serializationTasks);
        }
    }
    
    /// <summary>
    ///     Adds an array of graphics to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#addMany">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="graphics">
    ///     The graphic(s) to add to the layer.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public Task AddMany(IReadOnlyCollection<Graphic> graphics)
    {
        return Add(graphics);
    }

    /// <summary>
    ///     Remove a graphic from the current layer
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to remove
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task Remove(Graphic graphic)
    {
        if (!_graphics.Remove(graphic))
        {
            // graphic was not in layer
            return;
        }
        
        if (CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                            
        if (JsComponentReference is null)
        {
            return;
        }
         
        AllowRender = false;
        await JsComponentReference!.InvokeVoidAsync(
            "remove", 
            CancellationTokenSource.Token,
            graphic);
        AllowRender = true;
    }

    /// <summary>
    ///     Removes a set of graphics from the current layer
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to remove
    /// </param>
    [CodeGenerationIgnore]
    public Task Remove(IReadOnlyCollection<Graphic> graphics)
    {
        return RemoveMany(graphics);
    }
    
    /// <summary>
    ///     Removes an array of graphics from the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#removeMany">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to remove from the layer.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task RemoveMany(IReadOnlyCollection<Graphic> graphics)
    {
        AllowRender = false;
        _graphics.ExceptWith(graphics);
        
        if (CoreJsModule is null)
        {
            AllowRender = true;
            return;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                            
        if (JsComponentReference is null)
        {
            AllowRender = true;
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync(
            "removeMany", 
            CancellationTokenSource.Token,
            graphics);
        AllowRender = true;
    }
    
    /// <summary>
    ///     Clears all the graphics from the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html#removeAll">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task RemoveAll()
    {
        AllowRender = false;
        _graphics.Clear();
        
        if (CoreJsModule is null)
        {
            AllowRender = true;
            return;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                            
        if (JsComponentReference is null)
        {
            AllowRender = true;
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync(
            "removeAll", 
            CancellationTokenSource.Token);
        AllowRender = true;
    }

    /// <summary>
    ///     Removes all graphics from the current layer
    /// </summary>
    [CodeGenerationIgnore]
    public Task Clear()
    {
        return RemoveAll();
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                await Add(graphic);

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
                if (_graphics.Remove(graphic) && CoreJsModule is not null && !graphic.IsDisposed)
                {
                    try
                    {
                        await CoreJsModule.InvokeVoidAsync("removeGraphic",
                            CancellationTokenSource.Token, graphic.Id);
                    }
                    catch
                    {
                        // object disposed
                    }
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
            graphic.View = View;
            graphic.Layer = Layer;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        foreach (Graphic graphic in Graphics)
        {
            graphic.ValidateRequiredChildren();
        }
    }

    private readonly HashSet<Graphic> _graphics = [];
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

        List<Graphic> graphics = [];

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
            JsonSerializer.Serialize(writer, graphic.ToProtobuf(), options);
        }

        writer.WriteEndArray();
    }
}