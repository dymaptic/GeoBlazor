namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupExpressionInfo : MapComponent, IProtobufSerializable<PopupExpressionInfoSerializationRecord>
{
    public PopupExpressionInfoSerializationRecord ToProtobuf()
    {
        return new PopupExpressionInfoSerializationRecord(Id.ToString(), Expression, Name, Title, ReturnType);
    }
}