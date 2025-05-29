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

    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    [CodeGenerationIgnore]
    Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null);
}