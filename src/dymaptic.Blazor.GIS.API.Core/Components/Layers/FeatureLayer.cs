using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Components.Popups;
using dymaptic.Blazor.GIS.API.Core.Components.Renderers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public class FeatureLayer : Layer, IEquatable<FeatureLayer>
{
    public override string LayerType => "feature";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; } = default!;

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? OutFields { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<Label> LabelingInfo { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    public bool Equals(FeatureLayer? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return ((Object)this).Equals(other) && (Url == other.Url) && (DefinitionExpression == other.DefinitionExpression) &&
            Equals(OutFields, other.OutFields) && Equals(PopupTemplate, other.PopupTemplate) &&
            LabelingInfo.Equals(other.LabelingInfo) && Equals(Renderer, other.Renderer);
    }

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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((FeatureLayer)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Url, DefinitionExpression, OutFields, PopupTemplate, LabelingInfo,
            Renderer);
    }

    public override async Task UpdateComponent()
    {
        if (!MapRendered || JsModule is null) return;

        await InvokeAsync(async () =>
        {
            // ReSharper disable once RedundantCast
            await JsModule!.InvokeVoidAsync("updateFeatureLayer", (object)this);
        });
    }

    public override async Task RemoveComponent()
    {
        if (!MapRendered || JsModule is null) return;

        await InvokeAsync(async () =>
        {
            // ReSharper disable once RedundantCast
            await JsModule!.InvokeVoidAsync("removeFeatureLayer", (object)this);
        });
    }
}