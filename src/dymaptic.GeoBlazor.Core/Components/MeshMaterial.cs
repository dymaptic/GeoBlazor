namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshMaterial: MapComponent, IProtobufSerializable
{
   // Add custom code to this file to override generated code
   
   public virtual MapComponentSerializationRecord ToProtobuf()
   {
       return ToSerializationRecord();
   }
    
   internal virtual MeshComponentMaterialSerializationRecord ToSerializationRecord()
   {
       return new MeshComponentMaterialSerializationRecord(AlphaCutoff,
           AlphaMode?.ToString().ToKebabCase(),
           Color,
           ColorTexture?.ToSerializationRecord(),
           ColorTextureTransform?.ToSerializationRecord(),
           DoubleSided,
           NormalTexture?.ToSerializationRecord(),
           NormalTextureTransform?.ToSerializationRecord(),
           null, null, null, 
           null, null, null, 
           null, null);
   }
}