namespace dymaptic.GeoBlazor.Core.Results;

public partial record FeatureEditsResult
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