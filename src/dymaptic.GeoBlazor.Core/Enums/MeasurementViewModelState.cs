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