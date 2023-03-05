using Microsoft.JSInterop;
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
    public async Task Add(IEnumerable<Graphic> graphics)
    {
        List<Graphic> newGraphics = graphics.ToList();
        _graphics.UnionWith(newGraphics);
        foreach (Graphic graphic in newGraphics)
        {
            graphic.View ??= View;
            graphic.JsModule ??= JsModule;
            graphic.LayerId ??= Id;
            graphic.Parent ??= this;
        }

        if (JsLayerReference is null)
        {
            LayerChanged = true;

            return;
        }

        IEnumerable<GraphicSerializationRecord> records = newGraphics.Select(g => g.ToSerializationRecord());
        await JsLayerReference!.InvokeVoidAsync("addMany", 
            CancellationTokenSource.Token, records, View?.Id);
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
        foreach (Graphic graphic in graphics)
        {
            await UnregisterChildComponent(graphic);
        }
    }

    /// <summary>
    ///     Removes all graphics from the current layer
    /// </summary>
    public async Task Clear()
    {
        foreach (Graphic graphic in _graphics)
        {
            await UnregisterChildComponent(graphic);
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                graphic.View ??= View;
                graphic.JsModule ??= JsModule;
                graphic.LayerId ??= Id;
                graphic.Parent ??= this;
                if (_graphics.Add(graphic))
                {
                    if (JsLayerReference is not null)
                    {
                        GraphicSerializationRecord record = graphic.ToSerializationRecord();
                        await JsLayerReference.InvokeVoidAsync("add", 
                            CancellationTokenSource.Token, record, View?.Id);
                    }
                    else
                    {
                        LayerChanged = true;
                    }
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
            case Graphic graphic:
                if (_graphics.Remove(graphic) && JsLayerReference is not null)
                {
                    try
                    {
                        await JsLayerReference.InvokeVoidAsync("remove", 
                            CancellationTokenSource.Token, graphic);
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

    /// <summary>
    ///     Register a graphic that was created in JavaScript
    /// </summary>
    public void RegisterExistingGraphicFromJavaScript(Graphic graphic)
    {
        if (!_graphics.Any(g => g.Equals(graphic)))
        {
            graphic.View ??= View;
            graphic.JsModule ??= JsModule;
            graphic.LayerId ??= Id;
            graphic.Parent ??= this;
            _graphics.Add(graphic);
        }
    }

    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);

        foreach (Graphic graphic in _graphics)
        {
            if (!graphic.IsRendered)
            {
                await JsLayerReference!.InvokeVoidAsync("add", 
                    CancellationTokenSource.Token, graphic);
            }
        }
    }

    private HashSet<Graphic> _graphics = new();
}