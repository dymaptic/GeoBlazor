namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     Information about each field in a layer. Field objects must be constructed when creating a FeatureLayer from
///     client-side graphics. This class allows you to define the schema of each field in the FeatureLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Field : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Field()
    {
    }

    /// <summary>
    ///     Creates a new Field in code with parameters
    /// </summary>
    /// <param name = "type">
    ///     The data type of the field.
    /// </param>
    /// <param name = "name">
    ///     The name of the field.
    /// </param>
    /// <param name = "alias">
    ///     The display name for the field.
    /// </param>
    /// <param name = "description">
    ///     Contains information describing the purpose of each field.
    /// </param>
    /// <param name = "length">
    ///     The field length.
    /// </param>
    /// <param name = "editable">
    ///     Indicates whether the field is editable.
    /// </param>
    /// <param name = "nullable">
    ///     Indicates if the field can accept null values.
    /// </param>
    /// <param name = "defaultValue">
    ///     The default value set for the field.
    /// </param>
    /// <param name = "valueType">
    ///     The types of values that can be assigned to a field.
    /// </param>
    public Field(FieldType type, string? name = null, string? alias = null, string? description = null, int? length = null, bool? editable = null, bool? nullable = null, object? defaultValue = null, FieldValueType? valueType = null)
    {
#pragma warning disable BL0005
        Type = type;
        Name = name;
        Alias = alias;
        Description = description;
        Length = length;
        Editable = editable;
        Nullable = nullable;
        DefaultValue = defaultValue;
        ValueType = valueType;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The name of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    ///     The display name for the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Alias { get; set; }

    /// <summary>
    ///     The data type of the field.
    /// </summary>
    [Parameter]
    [RequiredProperty]
    public FieldType Type { get; set; }

    /// <summary>
    ///     The default value set for the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DefaultValue { get; set; }

    /// <summary>
    ///     Contains information describing the purpose of each field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     Indicates whether the field is editable.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Editable { get; set; }

    /// <summary>
    ///     Indicates if the field can accept null values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Nullable { get; set; }

    /// <summary>
    ///     The field length.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Length { get; set; }

    /// <summary>
    ///     The types of values that can be assigned to a field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FieldValueType? ValueType { get; set; }
    /// <summary>
    ///     The domain associated with the field. Domains are used to constrain the values allowed in a field. There are two types of domains: RangeDomain and CodedValueDomain.
    /// </summary>
    public Domain? Domain { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Domain domain:
                if (!domain.Equals(Domain))
                {
                    Domain = domain;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Domain domain:
                if (domain.Equals(Domain))
                {
                    Domain = null;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}