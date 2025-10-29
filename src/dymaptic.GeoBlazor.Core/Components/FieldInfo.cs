using System.Runtime.Serialization.Formatters;


namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldInfo : MapComponent, IProtobufSerializable
{


    /// <summary>
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FieldName { get; set; }

    /// <summary>
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    ///     A Boolean determining whether users can edit this field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsEditable { get; set; }

    /// <summary>
    ///     A string providing an editing hint for editors of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Tooltip { get; set; } = string.Empty;

    /// <summary>
    ///     A string determining what type of input box editors see when editing the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StringFieldOption? StringFieldOption { get; set; }


    internal FieldInfoSerializationRecord ToSerializationRecord()
    {
        return new FieldInfoSerializationRecord(Id.ToString(), FieldName, Label, Tooltip, 
            StringFieldOption?.ToString().ToKebabCase(), Format?.ToSerializationRecord(), IsEditable, Visible);
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}