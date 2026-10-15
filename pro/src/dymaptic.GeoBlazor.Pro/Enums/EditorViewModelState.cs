namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Represents the state of the EditorViewModel.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<EditorViewModelState>))]
public enum EditorViewModelState
{ 
#pragma warning disable CS1591
    AddingAttachment,
    AwaitingFeatureCreationInfo,
    AwaitingFeatureToCreate,
    AwaitingFeatureToUpdate,
    AwaitingUpdateFeatureCandidate,
    CreatingFeatures,
    Disabled,
    EditingAttributes,
    EditingAttachment,
    EditingExistingFeature,
    EditingNewFeature,
    Ready
#pragma warning restore CS1591
}