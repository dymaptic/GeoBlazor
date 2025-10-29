namespace dymaptic.GeoBlazor.Core.Components;

public partial class ElementExpressionInfo: IProtobufSerializable
{
   // Add custom code to this file to override generated code
   
      internal ElementExpressionInfoSerializationRecord ToSerializationRecord()
      {
         return new ElementExpressionInfoSerializationRecord(Expression, Title);
      }
      
      public MapComponentSerializationRecord ToProtobuf()
      {
          return ToSerializationRecord();
      }
}