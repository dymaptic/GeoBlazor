using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Layers;

public class LabelExpressionInfo : MapComponent
{
    [Parameter]
    public string Expression { get; set; } = default!;
}