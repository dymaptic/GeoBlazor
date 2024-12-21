namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     The result of <see cref="FeatureLayer.ApplyEdits"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditsResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AddFeatureResults">
///     Result of adding features.     
/// </param>
/// <param name="UpdateFeatureResults">
///     Result of updating features.
/// </param>
/// <param name="DeleteFeatureResults">
///     Result of deleting features.
/// </param>
/// <param name="AddAttachmentResults">
///     Result of adding attachments.
/// </param>
/// <param name="UpdateAttachmentResults">
///     Result of updating attachments.
/// </param>
/// <param name="DeleteAttachmentResults">
///     Result of deleting attachments.
/// </param>
/// <param name="EditedFeatureResults">
///     Edited features as result of editing a feature that participates in composite relationships in a database. This parameter is returned only when the returnServiceEditsOption parameter of the applyEdits() method is set to original-and-current-features.
/// </param>
/// <param name="EditMoment">
///     The time edits were applied to the feature service. This parameter is returned only when the returnEditMoment parameter of the applyEdits() method is set to true.
/// </param>
public record FeatureEditsResult(
    FeatureEditResult[] AddFeatureResults,
    FeatureEditResult[] UpdateFeatureResults,
    FeatureEditResult[] DeleteFeatureResults,
    FeatureEditResult[] AddAttachmentResults,
    FeatureEditResult[] UpdateAttachmentResults,
    FeatureEditResult[] DeleteAttachmentResults,
    EditedFeatureResult[]? EditedFeatureResults,
    long? EditMoment)
{
    /// <summary>
    ///     Concatenates two <see cref="FeatureEditsResult"/>s.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public FeatureEditsResult Concat(FeatureEditsResult? other)
    {
        if (other is null) return this;
        return this with
        {
            AddFeatureResults = AddFeatureResults.Concat(other.AddFeatureResults).ToArray(),
            UpdateFeatureResults = UpdateFeatureResults.Concat(other.UpdateFeatureResults).ToArray(),
            DeleteFeatureResults = DeleteFeatureResults.Concat(other.DeleteFeatureResults).ToArray(),
            AddAttachmentResults = AddAttachmentResults.Concat(other.AddAttachmentResults).ToArray(),
            UpdateAttachmentResults = UpdateAttachmentResults.Concat(other.UpdateAttachmentResults).ToArray(),
            DeleteAttachmentResults = DeleteAttachmentResults.Concat(other.DeleteAttachmentResults).ToArray(),
            EditedFeatureResults = (EditedFeatureResults ?? Array.Empty<EditedFeatureResult>())
            .Concat(other.EditedFeatureResults ?? Array.Empty<EditedFeatureResult>()).ToArray()
        };
    }
}