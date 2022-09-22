using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class GraphicsLayer : Layer
{
    public List<Graphic> Graphics { get; set; } = new();

    [JsonPropertyName("type")]
    public override string LayerType => "graphics";

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
}