using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Views;

public class Viewpoint : MapComponent
{
    ///public Camera Camera { get; set; }

    /// <summary>
    /// The rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    public double? Rotation { get; set; } = 0;

    /// <summary>
    ///  The scale of the viewpoint.
    /// </summary>
    [Parameter]
    public double? Scale { get; set; } = 0;

    /// <summary>
    /// The target geometry framed by the viewpoint.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? TargetGeometry { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Geometry geometry:
                TargetGeometry = geometry;
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
            case Geometry geometry:
                TargetGeometry = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }

    }

}
