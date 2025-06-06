// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.SubtypeSublayerEdits.html">GeoBlazor Docs</a>
///     
/// </summary>
/// <param name="AddAttachments">
/// </param>
/// <param name="AddFeatures">
/// </param>
/// <param name="DeleteAttachments">
/// </param>
/// <param name="GraphicCollectionDeleteFeatures">
/// </param>
/// <param name="StringCollectionDeleteFeatures">
/// </param>
/// <param name="UpdateAttachments">
/// </param>
/// <param name="UpdateFeatures">
/// </param>
public partial record SubtypeSublayerEdits(
    IReadOnlyCollection<AttachmentEdit>? AddAttachments = null,
    IReadOnlyCollection<Graphic>? AddFeatures = null,
    IReadOnlyCollection<string>? DeleteAttachments = null,
    IReadOnlyCollection<Graphic>? GraphicCollectionDeleteFeatures = null,
    IReadOnlyCollection<string>? StringCollectionDeleteFeatures = null,
    IReadOnlyCollection<AttachmentEdit>? UpdateAttachments = null,
    IReadOnlyCollection<Graphic>? UpdateFeatures = null)
{
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<AttachmentEdit>? AddAttachments { get; set; } = AddAttachments;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<Graphic>? AddFeatures { get; set; } = AddFeatures;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<string>? DeleteAttachments { get; set; } = DeleteAttachments;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<Graphic>? GraphicCollectionDeleteFeatures { get; set; } = GraphicCollectionDeleteFeatures;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<string>? StringCollectionDeleteFeatures { get; set; } = StringCollectionDeleteFeatures;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<AttachmentEdit>? UpdateAttachments { get; set; } = UpdateAttachments;
    
    /// <summary>
    ///     
    /// </summary>
    public IReadOnlyCollection<Graphic>? UpdateFeatures { get; set; } = UpdateFeatures;
    
}
