namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshTextureTransform: IProtobufSerializable<MeshTextureTransformSerializationRecord>
{
   // Add custom code to this file to override generated code
   
   /// <inheritdoc />
    public MeshTextureTransformSerializationRecord ToProtobuf()
   {
       return new MeshTextureTransformSerializationRecord(Offset?.ToArray(), Rotation, 
           Scale?.ToArray());
   }
}