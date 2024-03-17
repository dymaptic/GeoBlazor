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
/// <param name="Target">
///     The target of the animation.
/// </param>
/// <param name="Center">
///     The MapView.Center to go to.
/// </param>
/// <param name="Scale">
///     The MapView.Scale to go to.
/// </param>
/// <param name="Zoom">
///     The MapView.Zoom to go to.
/// </param>
/// <param name="Heading">
///     The Camera.Heading to go to.
/// </param>
/// <param name="Tilt">
///     The Camera.Tilt to go to.
/// </param>
/// <param name="Position">
///     The Camera.Position to go to.
/// </param>
/// <param name="TargetGeometries">
///     The target as an array of Geometries.
/// </param>
/// <param name="TargetGraphics">
///     The target as an array of Graphics.
/// </param>
/// <param name="TargetGeometry">
///     The target as a single Geometry.
/// </param>
/// <param name="TargetGraphic">
///     The target as a single Graphic.
/// </param>
public record GoToTarget(
    object? Target,
    double[]? Center,
    double? Scale,
    double? Zoom,
    double? Heading,
    double? Tilt,
    Point? Position,
    Geometry[]? TargetGeometries,
    Graphic[]? TargetGraphics,
    Geometry? TargetGeometry,
    Graphic? TargetGraphic);

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