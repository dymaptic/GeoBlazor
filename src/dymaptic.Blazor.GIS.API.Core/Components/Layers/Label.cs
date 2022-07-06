using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public class Label : LayerObject
{
    [Parameter]
    public string? LabelPlacement { get; set; }
    [Parameter]
    public string? LabelExpression { get; set; }

    public LabelExpressionInfo? LabelExpressionInfo { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LabelExpressionInfo labelExpressionInfo:
                if (!((Object)labelExpressionInfo).Equals(LabelExpressionInfo))
                {
                    LabelExpressionInfo = labelExpressionInfo;
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
            case LabelExpressionInfo _:
                LabelExpressionInfo = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}