namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of the compass view model.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<CompassViewModelState>))]
public enum CompassViewModelState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Compass,
    Rotation,
    Disabled
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}