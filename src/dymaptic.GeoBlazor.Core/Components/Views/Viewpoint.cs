namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
/// Describes a point of view for a 2D or 3D view. In a 2D view, the viewpoint is determined using a center point and scale value.
/// In a 3D view, it is determined using a camera position.
/// The Viewpoint can be bookmarked for later use, or used for navigation purposes.
/// </summary>
public class Viewpoint : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Blazor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Viewpoint()
    {
    }
    
    /// <summary>
    ///     Constructor for C# use.
    /// </summary>
    /// <param name="targetGeometry">
    ///     The target geometry framed by the viewpoint.
    /// </param>
    /// <param name="scale">
    ///     The scale of the viewpoint.
    /// </param>
    /// <param name="rotation">
    ///     The rotation of due north in relation to the top of the view in degrees.
    /// </param>
    public Viewpoint(Geometry? targetGeometry = null, double? scale = null, double? rotation = null)
    {
#pragma warning disable BL0005
        TargetGeometry = targetGeometry;
        Scale = scale;
        Rotation = rotation;
#pragma warning restore BL0005
    }

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
            case Geometry:
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
