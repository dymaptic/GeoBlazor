namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class MeshTransform: IProtobufSerializable<MeshTransformSerializationRecord>
{
   // Add custom code to this file to override generated code
   /// <inheritdoc />
    public MeshTransformSerializationRecord ToProtobuf()
   {
       return new MeshTransformSerializationRecord(
           RotationAngle,
           RotationAxis?.ToArray(),
           Scale?.ToArray(),
           Translation?.ToArray());
   }
}