namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshTextureTransform: IProtobufSerializable
{
   // Add custom code to this file to override generated code
   
   public MapComponentSerializationRecord ToProtobuf()
   {
       return ToSerializationRecord();
   }
    
   internal MeshTextureTransformSerializationRecord ToSerializationRecord()
   {
       return new MeshTextureTransformSerializationRecord(Offset?.ToArray(), Rotation, 
           Scale?.ToArray());
   }
}