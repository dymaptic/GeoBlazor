using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Represents the native DOM pointer event that the ArcGIS event is built on top of.
/// </summary>
/// <param name="PointerId">
///     A unique identifier for the pointer causing the event.
/// </param>
/// <param name="Width">
///     The width (magnitude on the X axis), in CSS pixels, of the contact geometry of the pointer.
/// </param>
/// <param name="Height">
///     The height (magnitude on the Y axis), in CSS pixels, of the contact geometry of the pointer.
/// </param>
/// <param name="Pressure">
///     The normalized pressure of the pointer input in the range 0 to 1, where 0 and 1 represent the minimum and maximum
///     pressure the hardware is capable of detecting, respectively.
/// </param>
/// <param name="TangentialPressure">
///     The normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress) in the
///     range -1 to 1, where 0 is the neutral position of the control.
/// </param>
/// <param name="TiltX">
///     The plane angle (in degrees, in the range of -90 to 90) between the Y–Z plane and the plane containing both the
///     pointer (e.g. pen stylus) axis and the Y axis.
/// </param>
/// <param name="TiltY">
///     The plane angle (in degrees, in the range of -90 to 90) between the X–Z plane and the plane containing both the
///     pointer (e.g. pen stylus) axis and the X axis.
/// </param>
/// <param name="Twist">
///     The clockwise rotation of the pointer (e.g. pen stylus) around its major axis in degrees, with a value in the range
///     0 to 359.
/// </param>
/// <param name="PointerType">
///     Indicates the device type that caused the event (mouse, pen, touch, etc.).
/// </param>
/// <param name="IsPrimary">
///     Indicates if the pointer represents the primary pointer of this pointer type.
/// </param>
/// <param name="IsTrusted">
///     Indicates if the event is trusted.
/// </param>
public record DomPointerEvent(long? PointerId, double? Width, double? Height, double? Pressure,
    double? TangentialPressure, double? TiltX, double? TiltY, double? Twist, PointerType? PointerType, bool? IsPrimary,
    bool? IsTrusted);