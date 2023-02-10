using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The FieldInfo class defines how a Field participates, or in some cases, does not participate, in a PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-FieldInfo.html">ArcGIS JS API</a>
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
        string? stringFieldOption = null, FieldInfoFormat? format = null, 
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
    ///     Indicates whether the field is visible in the popup window.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Visible { get; set; }
    
    /// <summary>
    ///     A string determining what type of input box editors see when editing the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StringFieldOption { get; set; }

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
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Format?.ValidateRequiredChildren();
    }
}