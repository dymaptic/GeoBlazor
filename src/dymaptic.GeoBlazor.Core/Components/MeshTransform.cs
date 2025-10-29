namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshTransform: IProtobufSerializable
{
   // Add custom code to this file to override generated code
   public MapComponentSerializationRecord ToProtobuf()
   {
       return ToSerializationRecord();
   }
   
   internal MeshTransformSerializationRecord ToSerializationRecord()
   {
       return new MeshTransformSerializationRecord(
           RotationAngle,
           RotationAxis?.ToArray(),
           Scale?.ToArray(),
           Translation?.ToArray());
   }
}