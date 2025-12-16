namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ElementExpressionInfo: IProtobufSerializable<ElementExpressionInfoSerializationRecord>
{
   // Add custom code to this file to override generated code
   
      /// <inheritdoc />
    public ElementExpressionInfoSerializationRecord ToProtobuf()
      {
          return new ElementExpressionInfoSerializationRecord(Expression, Title);
      }
}