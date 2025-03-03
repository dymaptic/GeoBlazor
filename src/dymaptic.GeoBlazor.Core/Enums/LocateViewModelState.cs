namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of the locate view model.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LocateViewModelState>))]
public enum LocateViewModelState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Disabled,
    Ready,
    Locating,
    Error
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}