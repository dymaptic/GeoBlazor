using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public class GraphicsLayer : Layer, IEquatable<GraphicsLayer>
{
    public List<Graphic> Graphics { get; set; } = new();

    [JsonPropertyName("type")]
    public override string LayerType => "graphics";

    public bool Equals(GraphicsLayer? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Graphics.Equals(other.Graphics);
    }

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
            await JsModule!.InvokeVoidAsync("removeGraphicsLayer");
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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((GraphicsLayer)obj);
    }

    public override int GetHashCode()
    {
        return Graphics.GetHashCode();
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