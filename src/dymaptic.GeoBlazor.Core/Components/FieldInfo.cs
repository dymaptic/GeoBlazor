namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldInfo : MapComponent
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
        return new FieldInfoSerializationRecord(FieldName, Label, Tooltip, StringFieldOption?.ToString().ToKebabCase(), Format?.ToSerializationRecord(), IsEditable, Visible);
    }
}

[ProtoContract(Name = "FieldInfo")]
internal record FieldInfoSerializationRecord : MapComponentSerializationRecord
{
    public FieldInfoSerializationRecord()
    {
    }

    public FieldInfoSerializationRecord(string? FieldName = null, string? Label = null, string? Tooltip = null, string? StringFieldOption = null, FieldInfoFormatSerializationRecord? Format = null, bool? IsEditable = null, bool? Visible = null)
    {
        this.FieldName = FieldName;
        this.Label = Label;
        this.Tooltip = Tooltip;
        this.StringFieldOption = StringFieldOption;
        this.Format = Format;
        this.IsEditable = IsEditable;
        this.Visible = Visible;
    }

    public FieldInfo FromSerializationRecord()
    {
        StringFieldOption? sfo = StringFieldOption switch
        {
            "rich-text" => Enums.StringFieldOption.RichText,
            "text-area" => Enums.StringFieldOption.TextArea,
            "text-box" => Enums.StringFieldOption.TextBox,
            _ => null
        };
        return new FieldInfo(FieldName, Label, Tooltip, sfo, Format?.FromSerializationRecord(), IsEditable, Visible);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Label { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Tooltip { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? StringFieldOption { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public FieldInfoFormatSerializationRecord? Format { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? IsEditable { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? Visible { get; init; }
}