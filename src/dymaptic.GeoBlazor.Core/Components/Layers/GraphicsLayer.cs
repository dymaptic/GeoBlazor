using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent real-world phenomena.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS JS API</a>
/// </summary>
public class GraphicsLayer : Layer
{
    /// <summary>
    ///     A collection of <see cref="Graphic"/>s in the layer.
    /// </summary>
    public List<Graphic> Graphics { get; set; } = new();

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "graphics";

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                if (!Graphics.Contains(graphic))
                {
                    graphic.GraphicIndex = Graphics.Count;
                    graphic.View ??= View;
                    graphic.JsModule ??= JsModule;
                    graphic.Parent ??= this;
                    Graphics.Add(graphic);

                    if (MapRendered)
                    {
                        await View!.UpdateGraphic(graphic, LayerIndex);
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
                if (Graphics.Contains(graphic))
                {
                    Graphics.Remove(graphic);
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
}