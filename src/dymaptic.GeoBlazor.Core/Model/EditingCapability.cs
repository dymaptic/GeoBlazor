namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes editing capabilities that can be performed on the features in the layer via ApplyEdits().
/// </summary>
/// <param name="SupportsDeleteByAnonymous">
///     Indicates if anonymous users can delete features created by others.
/// </param>
/// <param name="SupportsDeleteByOthers">
///     Indicates if logged in users can delete features created by others.
/// </param>
/// <param name="SupportsGeometryUpdate">
///     Indicates if the geometry of the features in the layer can be edited.
/// </param>
/// <param name="SupportsGlobalId">
///     Indicates if the globalId values provided by the client are used in applyEdits.
/// </param>
/// <param name="SupportsRollbackOnFailure">
///     Indicates if the globalId values provided by the client are used in applyEdits.
/// </param>
/// <param name="SupportsUpdateByAnonymous">
///     Indicates if anonymous users can update features created by others.
/// </param>
/// <param name="SupportsUpdateByOthers">
///     Indicates if logged in users can update features created by others.
/// </param>
/// <param name="SupportsUploadWithItemId">
///     Indicates if the layer supports uploading attachments by UploadId.
/// </param>
/// <param name="SupportsUpdateWithoutM">
///     Indicates if m-values must be provided when updating features.
/// </param>
public record EditingCapability(bool SupportsDeleteByAnonymous, bool SupportsDeleteByOthers, bool SupportsGeometryUpdate,
    bool SupportsGlobalId, bool SupportsRollbackOnFailure, bool SupportsUpdateByAnonymous, bool SupportsUpdateByOthers,
    bool SupportsUploadWithItemId, bool SupportsUpdateWithoutM);