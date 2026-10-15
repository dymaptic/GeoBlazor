namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The state of the FeatureFormViewModel.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FeatureFormViewModelState>))]
public enum FeatureFormViewModelState
{
#pragma warning disable CS1591
    Ready,
    Disabled
#pragma warning restore CS1591
}