namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of the measurement view models.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<MeasurementViewModelState>))]
public enum MeasurementViewModelState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Disabled,
    Ready,
    Measuring,
    Measured
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

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

/// <summary>
///     Enumeration for the state of a slider drag event.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderDragEventState>))]
public enum SliderDragEventState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Start,
    Drag
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}