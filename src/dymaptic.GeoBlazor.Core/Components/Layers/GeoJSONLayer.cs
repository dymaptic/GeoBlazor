using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class GeoJSONLayer : Layer
{
    [JsonPropertyName("type")]
    public override string LayerType => "geo-json";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    await UpdateComponent();
                }

                break;
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
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
            case Renderer _:
                Renderer = null;

                break;
            case SpatialReference _:
                SpatialReference = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}