using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Describes a layer's relationship with another layer or table. These relationships are listed in the ArcGIS Services
///     directory as described in the REST API documentation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Relationship
{
    /// <summary>
    ///     The cardinality which specifies the number of objects in the origin FeatureLayer related to the number of objects
    ///     in the destination FeatureLayer. Please see the Desktop help for additional information on cardinality.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Cardinality? Cardinality { get; set; }

    /// <summary>
    ///     Indicates whether the relationship is composite. In a composite relationship, a destination object cannot exist
    ///     independently of its origin object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Composite { get; set; }

    /// <summary>
    ///     The unique ID for the relationship. These ids for the relationships the FeatureLayer participates in are listed in
    ///     the ArcGIS Services directory.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Id { get; set; }

    /// <summary>
    ///     The field used to establish the relate within the FeatureLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? KeyField { get; set; }

    /// <summary>
    ///     The key field in an attributed relationship class table that matches the keyField. This is returned only for
    ///     attributed relationships.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? KeyFieldInRelationshipTable { get; set; }

    /// <summary>
    ///     The name of the relationship.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    ///     The unique ID of the related FeatureLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RelatedTableId { get; set; }

    /// <summary>
    ///     The relationship table id.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RelationshipTableId { get; set; }

    /// <summary>
    ///     Indicates whether the table participating in the relationship is the origin or destination table.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Role? Role { get; set; }
}

/// <summary>
///     The cardinality which specifies the number of objects in the origin FeatureLayer related to the number of objects
///     in the destination FeatureLayer. Please see the Desktop help for additional information on cardinality.
/// </summary>
[JsonConverter(typeof(EnumRelConverter<Cardinality>))]
public enum Cardinality
{
    /// <summary>
    ///     One-to-one
    /// </summary>
    OneToOne,
    /// <summary>
    ///     One-to-many
    /// </summary>
    OneToMany,
    /// <summary>
    ///     Many-to-one
    /// </summary>
    ManyToMany
}

/// <summary>
///     Indicates whether the table participating in the relationship is the origin or destination table.
/// </summary>
[JsonConverter(typeof(EnumRelConverter<Role>))]
public enum Role
{
    /// <summary>
    ///     Origin
    /// </summary>
    Origin,
    /// <summary>
    ///     Destination
    /// </summary>
    Destination
}

internal class EnumRelConverter<T> : EnumToKebabCaseStringConverter<T> where T : notnull
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty)
            .Replace("Rel", string.Empty)
            .Replace("Role", string.Empty)
            .Replace("esri", string.Empty)
            .Replace(nameof(Cardinality), string.Empty);

        return value is not null ? (T)Enum.Parse(typeof(T), value, true) : default(T)!;
    }
}