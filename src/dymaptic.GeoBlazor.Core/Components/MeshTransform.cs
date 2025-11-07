namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshTransform: IProtobufSerializable<MeshTransformSerializationRecord>
{
   // Add custom code to this file to override generated code
   public MeshTransformSerializationRecord ToProtobuf()
   {
       return new MeshTransformSerializationRecord(
           RotationAngle,
           RotationAxis?.ToArray(),
           Scale?.ToArray(),
           Translation?.ToArray());
   }
}