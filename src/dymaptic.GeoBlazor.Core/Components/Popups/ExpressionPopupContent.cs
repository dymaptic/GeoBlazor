namespace dymaptic.GeoBlazor.Core.Components.Popups;

[ProtobufSerializable]
public partial class ExpressionPopupContent : PopupContent
{
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Expression;

    /// <summary>
    ///     Contains the Arcade expression used to create a popup content element. See the ElementExpressionInfo documentation for details and examples for how to create these expressions.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementExpressionInfo? ExpressionInfo { get; set; }

    /// <inheritdoc />
    public override PopupContentSerializationRecord ToProtobuf()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            ExpressionInfo = ExpressionInfo?.ToProtobuf()
        };
    }
}