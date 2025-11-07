namespace dymaptic.GeoBlazor.Core.Components;

public partial class ElementExpressionInfo: IProtobufSerializable<ElementExpressionInfoSerializationRecord>
{
   // Add custom code to this file to override generated code
   
      public ElementExpressionInfoSerializationRecord ToProtobuf()
      {
          return new ElementExpressionInfoSerializationRecord(Expression, Title);
      }
}