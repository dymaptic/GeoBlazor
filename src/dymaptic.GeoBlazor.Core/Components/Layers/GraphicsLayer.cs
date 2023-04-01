using dymaptic.GeoBlazor.Core.Components.Views;
using Microsoft.JSInterop;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a
///     LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent
///     real-world phenomena.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class GraphicsLayer : Layer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
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
    public GraphicsLayer(IReadOnlyCollection<Graphic>? graphics = null, string? title = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null)
    {
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;

        if (graphics is not null)
        {
            Graphics = graphics;
        }
    }

    /// <summary>
    ///     A collection of <see cref="Graphic" />s in the layer.
    /// </summary>
    [JsonConverter(typeof(GraphicsToSerializationConverter))]
    public IReadOnlyCollection<Graphic> Graphics
    {
        get => _graphics;
        set => _graphics = new HashSet<Graphic>(value);
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "graphics";

    /// <summary>
    ///     Add a graphic to the current layer
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to add
    /// </param>
    public Task Add(Graphic graphic)
    {
        return RegisterChildComponent(graphic);
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
        List<Graphic> newGraphics = graphics.ToList();
        _graphics.UnionWith(newGraphics);
        
        foreach (Graphic graphic in newGraphics)
        {
            graphic.View = View;
            graphic.JsModule = JsModule;
            graphic.LayerId = Id;
            graphic.Parent = this;
            graphic.AllowRender = false;
        }

        if (JsModule is null)
        {
            LayerChanged = true;

            return;
        }
        List<GraphicSerializationRecord> records = newGraphics.Select(g => g.ToSerializationRecord()).ToList();
        int chunkSize = View!.GraphicSerializationChunkSize ?? 200;

        if (OperatingSystem.IsBrowser())
        {
            for (int index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;
            
                if (cancellationToken.IsCancellationRequested ||
                    CancellationTokenSource.Token.IsCancellationRequested) return;

                ProtoGraphicCollection collection =
                    new(records.Skip(skip).Take(chunkSize).ToArray());
                MemoryStream ms = new();
                Serializer.Serialize(ms, collection);
                ms.Seek(0, SeekOrigin.Begin);
                using DotNetStreamReference streamRef = new(ms);
#if NET7_0_OR_GREATER
                MapView.AddGraphicsSyncInterop(ms.ToArray(), View!.Id.ToString(), Id.ToString());
                await Task.Delay(1, cancellationToken);
#else
                await JsModule!.InvokeVoidAsync("addGraphicsFromStream", 
                        CancellationTokenSource.Token, streamRef, View?.Id, Id);
#endif                
            }
        }
        else
        {
            List<Task> serializationTasks = new();
            
            for (int index = 0; index < records.Count; index += chunkSize)
            {
                int skip = index;

                serializationTasks.Add(Task.Run(async () =>
                {
                    if (cancellationToken.IsCancellationRequested ||
                        CancellationTokenSource.Token.IsCancellationRequested) return;

                    ProtoGraphicCollection collection =
                        new(records.Skip(skip).Take(chunkSize).ToArray());
                    MemoryStream ms = new();
                    Serializer.Serialize(ms, collection);
                    ms.Seek(0, SeekOrigin.Begin);
                    using DotNetStreamReference streamRef = new(ms);
                    await JsModule!.InvokeVoidAsync("addGraphicsFromStream", 
                        CancellationTokenSource.Token, streamRef, View?.Id, Id);
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
        List<Graphic> removedGraphics = graphics.ToList();
        List<Guid> wrapperIds = removedGraphics.Select(g => g.Id).ToList();
        await JsModule!.InvokeVoidAsync("removeGraphics", wrapperIds);
        _graphics.ExceptWith(removedGraphics);
    }

    /// <summary>
    ///     Removes all graphics from the current layer
    /// </summary>
    public async Task Clear()
    {
        AllowRender = false;
        await JsModule!.InvokeVoidAsync("clearGraphics", View!.Id, Id);
        _graphics.Clear();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender && _graphicsToRender.Any())
        {
            AllowRender = false;
            await Add(_graphicsToRender);
            _graphicsToRender.Clear();
            AllowRender = true;
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                _graphicsToRender.Add(graphic);

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
                if (_graphics.Remove(graphic) && JsModule is not null)
                {
                    try
                    {
                        await JsModule.InvokeVoidAsync("removeGraphic", 
                            CancellationTokenSource.Token, graphic.Id);
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

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
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
    
    private HashSet<Graphic> _graphics = new();
    private HashSet<Graphic> _graphicsToRender = new();
}

internal class GraphicsToSerializationConverter : JsonConverter<IReadOnlyCollection<Graphic>>
{
    public override IReadOnlyCollection<Graphic>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
internal record ProtoGraphicCollection([property: ProtoMember(1)]GraphicSerializationRecord[] Graphics);