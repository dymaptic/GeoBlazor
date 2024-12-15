namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Describes operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be queried.
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports REST API queryAttachments operation. If false, queryAttachments() method can only return attachments for one feature at a time. If true, queryAttachments() can return attachments for array of objectIds.
/// </param>
public record SublayerOperations(bool SupportsQuery, bool SupportsQueryAttachments);