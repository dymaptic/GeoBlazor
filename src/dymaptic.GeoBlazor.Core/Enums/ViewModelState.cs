namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of the view model.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ViewModelState>))]
public enum ViewModelState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Ready,
    Disabled,
    Loading,
    Error
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}