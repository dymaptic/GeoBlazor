using dymaptic.GeoBlazor.Core.Objects;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     A convenience sub-class of <see cref="SimpleLineSymbol"/> for defining outlines of other symbols.
/// </summary>
public class Outline : SimpleLineSymbol
{
    public Outline()
    {
    }
    
    public Outline(MapColor? color = null, double? width =null, LineStyle? lineStyle = null) 
        : base(color, width, lineStyle)
    {
    }
}