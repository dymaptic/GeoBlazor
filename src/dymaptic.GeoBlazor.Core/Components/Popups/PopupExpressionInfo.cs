namespace dymaptic.GeoBlazor.Core.Components.Popups;

[ProtobufSerializable]
public partial class PopupExpressionInfo : MapComponent, IProtobufSerializable<PopupExpressionInfoSerializationRecord>
{
    /// <inheritdoc />
    public PopupExpressionInfoSerializationRecord ToProtobuf()
    {
        return new PopupExpressionInfoSerializationRecord(Id.ToString(), Expression, Name, Title, ReturnType);
    }
}