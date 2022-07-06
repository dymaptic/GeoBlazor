using dymaptic.Blazor.GIS.API.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Symbols;

public class TextSymbol : Symbol, IEquatable<TextSymbol>
{
    public override string Type => "text";

    [Parameter]
    public MapColor? HaloColor { get; set; }

    [Parameter]
    public string? HaloSize { get; set; }

    public MapFont? Font { get; set; }

    public bool Equals(TextSymbol? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Equals(HaloColor, other.HaloColor) && (HaloSize == other.HaloSize) &&
            Equals(Font, other.Font);
    }

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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((TextSymbol)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), HaloColor, HaloSize, Font);
    }
}