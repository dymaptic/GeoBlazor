namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of the home view model.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<HomeViewModelState>))]
public enum HomeViewModelState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Disabled,
    Ready,
    GoingHome
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}