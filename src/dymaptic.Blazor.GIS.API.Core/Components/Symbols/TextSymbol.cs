using dymaptic.Blazor.GIS.API.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public class TextSymbol : Symbol
{
    public override string Type => "text";

    [Parameter]
    public MapColor? HaloColor { get; set; }

    [Parameter]
    public string? HaloSize { get; set; }

    public MapFont? Font { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MapFont mapFont:
                if (!((Object)mapFont).Equals(Font))
                {
                    Font = mapFont;
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
            case MapFont _:
                Font = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}