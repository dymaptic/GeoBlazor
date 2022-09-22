using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public class Extent : Geometry
{
    [Parameter]
    public double Xmax { get; set; }

    [Parameter]
    public double Xmin { get; set; }

    [Parameter]
    public double Ymax { get; set; }

    [Parameter]
    public double Ymin { get; set; }

    [Parameter]
    public double Zmax { get; set; }

    [Parameter]
    public double Zmin { get; set; }

    [Parameter]
    public double? Mmax { get; set; }

    [Parameter]
    public double? Mmin { get; set; }

    public override string Type => "extent";
}