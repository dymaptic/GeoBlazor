using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Layers;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public class SimpleRenderer : Renderer
{
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.Simple;

    public HashSet<VisualVariable> VisualVariables { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case VisualVariable visualVariable:
                if (!VisualVariables.Contains(visualVariable))
                {
                    VisualVariables.Add(visualVariable);
                    await UpdateComponent();
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
            case VisualVariable visualVariable:
                VisualVariables.Remove(visualVariable);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}