namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IFeatureLayerBase>))]
public partial interface IFeatureLayerBase
{
    /// <summary>
    /// Returns the Field instance for a field name (case-insensitive).
    /// </summary>
    /// <param name="fieldName">the field name (case-insensitive).</param>
    [ArcGISMethod]
    Task<Field?> GetField(string fieldName);
}