namespace dymaptic.GeoBlazor.Core.Components.Popups;

[ProtobufSerializable]
public partial class TextPopupContent : PopupContent
{
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Text;

    /// <summary>
    ///     The formatted string content to display. This may contain a field name enclosed in {} (e.g. {FIELDNAME}), or an Arcade expression name (e.g. {expression/EXPRESSIONNAME}). Text content may also leverage HTML tags such as <b></b> , <p></p>, and <table></table> for formatting the look and feel of the content.
    /// </summary>
    /// <remarks>
    ///     Set the popupTemplate.fieldInfos property for any fields that need to have number formatting within the text.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <inheritdoc />
    public override PopupContentSerializationRecord ToProtobuf()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            Text = Text
        };
    }
}