using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class LabelExpressionInfo : MapComponent
{
    [Parameter]
    public string Expression { get; set; } = default!;
}