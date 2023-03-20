using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A TextContent popup element is used to define descriptive text as an element within a PopupTemplate's content. The
///     text may reference values returned from a field attribute or an Arcade expression defined in a PopupTemplate's
///     expressionInfos property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-TextContent.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class TextPopupContent : PopupContent
{
    /// <inheritdoc />
    public override string Type => "text";
    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type)
        {
            Text = Text
        };
    }

    /// <summary>
    ///     The formatted string content to display. This may contain a field name enclosed in {} (e.g. {FIELDNAME}), or an
    ///     Arcade expression name (e.g. {expression/EXPRESSIONNAME}). Text content may also leverage HTML tags such as <b></b>
    ///     , <p></p>, and <table></table> for formatting the look and feel of the content.
    /// </summary>
    /// <remarks>
    ///     Set the popupTemplate.fieldInfos property for any fields that need to have number formatting within the text.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
}