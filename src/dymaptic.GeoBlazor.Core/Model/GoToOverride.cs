namespace dymaptic.GeoBlazor.Core.Model;

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