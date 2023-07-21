using dymaptic.GeoBlazor.Core.Components.Geometries;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
/// Describes a point of view for a 2D or 3D view. In a 2D view, the viewpoint is determined using a center point and scale value.
/// In a 3D view, it is determined using a camera position.
/// The Viewpoint can be bookmarked for later use, or used for navigation purposes.
/// </summary>
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    internal override void ValidateRequiredChildren()
    {
        TargetGeometry?.ValidateRequiredChildren();
    }

}
