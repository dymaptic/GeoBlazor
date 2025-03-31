namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsAdd">
///     Indicates if new features can be added to the layer.
/// </param>
/// <param name="SupportsCalculate">
///     Indicates if values of one or more field values in the layer can be updated. See the Calculate REST operation document for more information.
/// </param>
/// <param name="SupportsDelete">
///     Indicates if features can be deleted from the layer.
/// </param>
/// <param name="SupportsEditing">
///     Indicates if features in the layer can be edited. Use supportsAdd, supportsUpdate and supportsDelete to determine which editing operations are supported.
/// </param>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be queried.
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports REST API queryAttachments operation. If false, queryAttachments() method can only return attachments for one feature at a time. If true, queryAttachments() can return attachments for array of objectIds.
/// </param>
/// <param name="SupportsQueryTopFeatures">
///     Indicates if the layer supports REST API queryTopFeatures operation.
/// </param>
/// <param name="SupportsUpdate">
///     Indicates if features in the layer can be updated.
/// </param>
/// <param name="SupportsValidateSql">
///     Indicates if the layer supports a SQL-92 expression or where clause.
/// </param>
public record OperationsCapability(bool SupportsAdd, bool SupportsCalculate, bool SupportsDelete, bool SupportsEditing,
    bool SupportsQuery, bool SupportsQueryAttachments, bool SupportsQueryTopFeatures, bool SupportsUpdate, 
    bool SupportsValidateSql);