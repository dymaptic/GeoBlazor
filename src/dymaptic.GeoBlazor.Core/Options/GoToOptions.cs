namespace dymaptic.GeoBlazor.Core.Options;

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