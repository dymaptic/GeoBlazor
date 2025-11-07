namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshMaterial: MapComponent
{
   // Add custom code to this file to override generated code
   
   public virtual MeshComponentMaterialSerializationRecord ToProtobuf()
   {
       return new MeshComponentMaterialSerializationRecord(AlphaCutoff,
           AlphaMode?.ToString().ToKebabCase(),
           Color,
           ColorTexture?.ToProtobuf(),
           ColorTextureTransform?.ToProtobuf(),
           DoubleSided,
           NormalTexture?.ToProtobuf(),
           NormalTextureTransform?.ToProtobuf(),
           null, null, null, 
           null, null, null, 
           null, null);
   }
}