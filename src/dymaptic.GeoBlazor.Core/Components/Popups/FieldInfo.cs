using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The FieldInfo class defines how a Field participates, or in some cases, does not participate, in a PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-FieldInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FieldInfo : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public FieldInfo()
    {
    }

    /// <summary>
    ///     Constructor for creating a new FieldInfo in code with parameters
    /// </summary>
    /// <param name="fieldName">
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </param>
    /// <param name="label">
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </param>
    /// <param name="tooltip">
    ///     A string providing an editing hint for editors of the field.
    /// </param>
    /// <param name="stringFieldOption">
    ///     A string determining what type of input box editors see when editing the field.
    /// </param>
    /// <param name="format">
    ///     Class which provides formatting options for numerical or date fields and how they should display within a popup.
    /// </param>
    /// <param name="isEditable">
    ///     A Boolean determining whether users can edit this field.
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the field is visible in the popup window.
    /// </param>
    public FieldInfo(string? fieldName = null, string? label = null, string? tooltip = null,
        StringFieldOption? stringFieldOption = null, FieldInfoFormat? format = null,
        bool? isEditable = null, bool? visible = null)
    {
#pragma warning disable BL0005
        FieldName = fieldName;
        Label = label;
        Tooltip = tooltip;
        StringFieldOption = stringFieldOption;
        Format = format;
        IsEditable = isEditable;
        Visible = visible;
#pragma warning restore BL0005
    }
    
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

    /// <summary>
    ///     Class which provides formatting options for numerical or date fields and how they should display within a popup.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FieldInfoFormat? Format { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfoFormat format:
                // ReSharper disable once RedundantCast
                if (!((object)format).Equals(Format))
                {
                    Format = format;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfoFormat:
                Format = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Format?.ValidateRequiredChildren();
    }

    internal FieldInfoSerializationRecord ToSerializationRecord()
    {
        return new FieldInfoSerializationRecord(FieldName, Label, Tooltip, StringFieldOption?.ToString().ToKebabCase(),
            Format?.ToSerializationRecord(), IsEditable, Visible);
    }
}

[ProtoContract(Name = "FieldInfo")]
internal record FieldInfoSerializationRecord : MapComponentSerializationRecord
{
    public FieldInfoSerializationRecord()
    {
    }
    
    public FieldInfoSerializationRecord(string? FieldName = null,
        string? Label = null,
        string? Tooltip = null,
        string? StringFieldOption = null,
        FieldInfoFormatSerializationRecord? Format = null,
        bool? IsEditable = null,
        bool? Visible = null)
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
            "rich-text" => Components.StringFieldOption.RichText,
            "text-area" => Components.StringFieldOption.TextArea,
            "text-box" => Components.StringFieldOption.TextBox,
            _ => null
        };
        return new FieldInfo(FieldName, Label, Tooltip, sfo,
            Format?.FromSerializationRecord(), IsEditable, Visible);
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