using dymaptic.GeoBlazor.Core.Components.Geometries;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Views;

public class ViewPoint : MapComponent
{
    ///public Camera Camera { get; set; }

    /// <summary>
    /// The rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Rotation { get; set; }

    /// <summary>
    ///  The scale of the viewpoint.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Scale { get; set; }

    /// <summary>
    /// The target geometry framed by the viewpoint.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? TargetGeometry { get; set; }

    //public ViewPoint(int? scale, int? rotation, Geometry? targetGeometry)
    //{
    //    Scale = scale;
    //    Rotation = rotation;
    //    TargetGeometry = targetGeometry;
    //}

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
