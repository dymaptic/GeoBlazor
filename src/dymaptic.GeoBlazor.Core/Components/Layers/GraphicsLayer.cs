using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a
///     LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent
///     real-world phenomena.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS JS API</a>
/// </summary>
public class GraphicsLayer : Layer
{
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
        foreach (Graphic graphic in graphics)
        {
            await RegisterChildComponent(graphic);
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
        foreach (Graphic graphic in graphics)
        {
            await UnregisterChildComponent(graphic);
        }
    }
    
    public async Task Update(Graphic graphic)
    {
        await View!.UpdateGraphic(graphic, LayerIndex);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                if (MapRendered)
                {
                    await View!.AddGraphic(graphic, LayerIndex);
                }
                else if (!Graphics.Contains(graphic))
                {
                    graphic.GraphicIndex = Graphics.Count;
                    graphic.View ??= View;
                    graphic.JsModule ??= JsModule;
                    graphic.LayerId ??= Id;
                    graphic.Parent ??= this;
                    _graphics.Add(graphic);
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
                if (MapRendered)
                {
                    await View!.RemoveGraphicAtIndex(graphic.GraphicIndex!.Value, LayerIndex);
                }
                else if (Graphics.Contains(graphic))
                {
                    _graphics.Remove(graphic);
                    ResetGraphicIndexes();
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
    
    internal void AddGraphicToCollection(Graphic graphic)
    {
        _graphics.Add(graphic);
    }
    
    internal void RemoveGraphicFromCollection(Graphic graphic)
    {
        _graphics.Remove(graphic);
    }
    
    private void ResetGraphicIndexes()
    {
        int i = 0;
        foreach (Graphic graphic in Graphics.OrderBy(g => g.GraphicIndex))
        {
            graphic.GraphicIndex = i;
            i++;
        }
    }

    private HashSet<Graphic> _graphics = new();
}