using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

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
                    Graphics.Add(graphic);

                    if (MapRendered)
                    {
                        graphic.Uid = await View!.AddGraphic(graphic, LayerIndex);
                        await graphic.UpdateComponent();
                    }
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    public override async Task RemoveComponent()
    {
        await InvokeAsync(async () =>
        {
            await JsModule!.InvokeVoidAsync("removeGraphicsLayer", View.Id);
        });
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Graphic graphic:
                if (Graphics.Contains(graphic))
                {
                    Graphics.Remove(graphic);
                    await View!.RemoveGraphic(graphic, LayerIndex);
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        await InvokeAsync(async () =>
        {
            if (MapRendered && Graphics.Any(g => g.Uid is null))
            {
                Graphic[] renderedGraphics = await View!.GetAllGraphics(LayerIndex);

                for (var i = 0; i < renderedGraphics.Length; i++)
                {
                    Graphic localGraphic = Graphics[i];
                    Graphic renderedGraphic = renderedGraphics[i];

                    if (localGraphic.Uid != renderedGraphic.Uid)
                    {
                        localGraphic.Uid = renderedGraphic.Uid;
                    }
                }
            }
        });
    }
}