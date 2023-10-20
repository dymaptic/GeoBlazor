using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The following properties define a goTo override function.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-widget.html#GoToOverride">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ViewId">
///     A reference Id to the MapView or SceneView where the navigation takes place.
/// </param>
/// <param name="Target">
///     The target location/viewpoint/extent to animate to.
/// </param>
/// <param name="Options">
///     Options defining the animation, duration, and easing of the navigation.
/// </param>
public record GoToOverrideParameters(Guid ViewId, GoToTarget Target, GoToOptions? Options);

/// <summary>
///     The target location/viewpoint to animate to in the goTo() method. A two or three-element array of numbers represents the [x,y,z] coordinates to center the view on. When using an object for the target, use the properties in this record.
/// </summary>
public record GoToTarget(object? Target, double[]? Center, double? Scale, double? Zoom, double? Heading, double? Tilt,
    Point? Position)
{
    /// <summary>
    ///     Constructor for when the target is a collection of coordinates.
    /// </summary>
    public GoToTarget(double[]? targetCoordinates, object? target, double[]? center, double? scale, double? zoom, 
        double? heading, double? tilt, Point? position) : this(target, center, scale, zoom, heading, tilt, position)
    {
        TargetCoordinates = targetCoordinates;
    }
    
    /// <summary>
    ///     Constructor for when the target is a collection of Geometries.
    /// </summary>
    public GoToTarget(Geometry[]? targetGeometries, object? target, double[]? center, double? scale, double? zoom, 
        double? heading, double? tilt, Point? position) : this(target, center, scale, zoom, heading, tilt, position)
    {
        TargetGeometries = targetGeometries;
    }
    
    /// <summary>
    ///     Constructor for when the target is a single Geometry.
    /// </summary>
    public GoToTarget(Geometry? targetGeometry, object? target, double[]? center, double? scale, double? zoom, 
        double? heading, double? tilt, Point? position) : this(target, center, scale, zoom, heading, tilt, position)
    {
        TargetGeometry = targetGeometry;
    }
    
    /// <summary>
    ///     Constructor for when the target is a collection of Graphics.
    /// </summary>
    public GoToTarget(Graphic[]? targetGraphics, object? target, double[]? center, double? scale, double? zoom, 
        double? heading, double? tilt, Point? position) : this(target, center, scale, zoom, heading, tilt, position)
    {
        TargetGraphics = targetGraphics;
    }
    
    /// <summary>
    ///     Constructor for when the target is a single Graphic.
    /// </summary>
    public GoToTarget(Graphic? targetGraphic, object? target, double[]? center, double? scale, double? zoom, 
        double? heading, double? tilt, Point? position) : this(target, center, scale, zoom, heading, tilt, position)
    {
        TargetGraphic = targetGraphic;
    }
    
    /// <summary>
    ///     The target of the animation as [x,y] or [x,y,z] coordinates.
    /// </summary>
    public double[]? TargetCoordinates { get; set; }

    /// <summary>
    ///     The target of the animation as a collection of geometries.
    /// </summary>
    public Geometry[]? TargetGeometries { get; set; }

    /// <summary>
    ///     The target of the animation as a single geometry.
    /// </summary>
    public Geometry? TargetGeometry { get; set; }

    /// <summary>
    ///     The target of the animation as a collection of graphics.
    /// </summary>
    public Graphic[]? TargetGraphics { get; set; }
    
    /// <summary>
    ///     The target of the animation as a single graphic.
    /// </summary>
    public Graphic? TargetGraphic { get; set; }
    
    /// <summary>
    ///     The target of the animation.
    /// </summary>
    public object? Target { get; set; } = Target;

    /// <summary>
    ///     The View.Center to go to.
    /// </summary>
    public double[]? Center { get; private set; } = Center;

    /// <summary>
    ///     The View.Scale to go to.
    /// </summary>
    public double? Scale { get; private set; } = Scale;

    /// <summary>
    ///     The View.Zoom to go to.
    /// </summary>
    public double? Zoom { get; private set; } = Zoom;

    /// <summary>
    ///     The View.Heading to go to.
    /// </summary>
    public double? Heading { get; private set; } = Heading;

    /// <summary>
    ///     The View.Tilt to go to. 
    /// </summary>
    public double? Tilt { get; private set; } = Tilt;

    /// <summary>
    ///    The View.Position to go to. 
    /// </summary>
    public Point? Position { get; private set; } = Position;
}

/// <summary>
///     Animation options for the goTo() method. See properties below for parameter specifications.
/// </summary>
/// <param name="Animate">
///     Indicates if the transition to the new view should be animated. If set to false, speedFactor, duration, maxDuration, and easing properties are ignored.
///     Default Value is True.
/// </param>
/// <param name="Duration">
///     Set the exact duration (in milliseconds) of the animation. Note that by default, animation duration is calculated based on the time required to reach the target at a constant speed. Setting duration overrides the speedFactor option. Note that the resulting duration is still limited to the maxDuration.
/// </param>
/// <param name="Easing">
///     The easing function to use for the animation. This may either be a preset (named) function, or a user specified function. Supported named presets are: linear, in-cubic, out-cubic, in-out-cubic, in-expo, out-expo, in-out-expo, in-out-coast-quadratic.
/// </param>
/// <param name="SpeedFactor">
///     Increases or decreases the animation speed by the specified factor. A speedFactor of 2 will make the animation twice as fast, while a speedFactor of 0.5 will make the animation half as fast. Setting the speed factor will automatically adapt the default maxDuration accordingly.
///     Default Value is 1.
/// </param>
/// <param name="MaxDuration">
///     The maximum allowed duration (in milliseconds) of the animation. The default maxDuration value takes the specified speedFactor into account.
///     Default Value is 8000.
/// </param>
public record GoToOptions(bool? Animate, double? Duration, string? Easing, double? SpeedFactor, double? MaxDuration);