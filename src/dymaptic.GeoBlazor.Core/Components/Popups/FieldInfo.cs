using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The FieldInfo class defines how a Field participates, or in some cases, does not participate, in a PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-FieldInfo.html">ArcGIS JS API</a>
/// </summary>
public class FieldInfo : MapComponent
{
    /// <summary>
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </summary>
    [Parameter]
    public string? FieldName { get; set; }
    
    /// <summary>
    ///     The field name as defined by the service or the name of an Arcade expression.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }
    
    /// <summary>
    ///     A Boolean determining whether users can edit this field.
    /// </summary>
    [Parameter]
    public bool IsEditable { get; set; }

    /// <summary>
    ///     A string providing an editing hint for editors of the field.
    /// </summary>
    [Parameter]
    public string Tooltip { get; set; } = string.Empty;

    /// <summary>
    ///     Indicates whether the field is visible in the popup window.
    /// </summary>
    [Parameter]
    public bool Visible { get; set; }
    
    /// <summary>
    ///     A string determining what type of input box editors see when editing the field.
    /// </summary>
    [Parameter]
    public string? StringFieldOption { get; set; }

    /// <summary>
    ///     Class which provides formatting options for numerical or date fields and how they should display within a popup.
    /// </summary>
    public FieldInfoFormat? Format { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfoFormat format:
                if (!((Object)format).Equals(Format))
                {
                    Format = format;
                    await UpdateComponent();
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