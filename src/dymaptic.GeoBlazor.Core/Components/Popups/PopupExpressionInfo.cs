namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupExpressionInfo : MapComponent, IProtobufSerializable
{
    internal PopupExpressionInfoSerializationRecord ToSerializationRecord()
    {
        return new PopupExpressionInfoSerializationRecord(Id.ToString(), Expression, Name, Title, ReturnType);
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}