namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The position of the <see cref="Label"/>. Possible values are based on the feature type. This property requires a value.
/// </summary>
[JsonConverter(typeof(LabelPlacementStringConverter))]
public enum LabelPlacement
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    AboveCenter,
    AboveLeft,
    AboveRight,
    BelowCenter,
    BelowLeft,
    BelowRight,
    CenterCenter,
    CenterLeft,
    CenterRight,
    AboveAfter,
    AboveAlong,
    AboveBefore,
    AboveStart,
    AboveEnd,
    BelowAfter,
    BelowAlong,
    BelowBefore,
    BelowStart,
    BelowEnd,
    CenterAfter,
    CenterAlong,
    CenterBefore,
    CenterStart,
    CenterEnd,
    AlwaysHorizontal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}