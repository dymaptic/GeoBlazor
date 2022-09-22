using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class FeatureLayer : Layer
{
    private string? _definitionExpression;
    public override string LayerType => "feature";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; } = default!;

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression
    {
        get => _definitionExpression;
        set
        {
            _definitionExpression = value;

            if (MapRendered)
            {
                Task.Run(UpdateComponent);
            }
        }
    }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? OutFields { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<Label> LabelingInfo { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                    await UpdateComponent();
                }

                break;
            case Label label:
                if (!LabelingInfo.Contains(label))
                {
                    LabelingInfo.Add(label);
                    await UpdateComponent();
                }

                break;
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
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
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case Label label:
                LabelingInfo.Remove(label);

                break;
            case Renderer _:
                Renderer = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    public override async Task UpdateComponent()
    {
        if (!MapRendered || JsModule is null) return;

        await InvokeAsync(async () =>
        {
            // ReSharper disable once RedundantCast
            await JsModule!.InvokeVoidAsync("updateFeatureLayer", (object)this, View!.Id);
        });
    }
}