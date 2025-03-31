namespace dymaptic.GeoBlazor.Core.Components;

public partial class Field : MapComponent
{


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
    public FieldType? Type { get; set; }

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

}