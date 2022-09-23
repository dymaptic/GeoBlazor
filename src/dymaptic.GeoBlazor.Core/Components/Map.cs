using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components;

public class Map : MapComponent
{
    [Parameter]
    public string? ArcGISDefaultBasemap { get; set; }

    [Parameter]
    public string? Ground { get; set; }
    
    public Basemap? Basemap { get; set; }

    public HashSet<Layer> Layers { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Basemap basemap:
                if (!basemap.Equals(Basemap))
                {
                    Basemap = basemap;
                    await UpdateComponent();
                }

                break;
            case Layer layer:
                if (!Layers.Contains(layer))
                {
                    Type typeOfLayer = layer.GetType();
                    IEnumerable<Layer> allLayersOfType = Layers.Where(l => l.GetType() == typeOfLayer);
                    layer.LayerIndex = allLayersOfType.Count();
                    Layers.Add(layer);

                    if (MapRendered)
                    {
                        await layer.UpdateComponent();
                    }
                    else
                    {
                        await UpdateComponent();
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
            case Basemap _:
                Basemap = null;

                break;
            case Layer layer:
                Layers.Remove(layer);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Basemap?.ValidateRequiredChildren();

        foreach (Layer layer in Layers)
        {
            layer.ValidateRequiredChildren();
        }
    }

    public override async Task UpdateComponent()
    {
        await InvokeAsync(async () =>
        {
            StateHasChanged();
            await RenderView();
        });
    }
}