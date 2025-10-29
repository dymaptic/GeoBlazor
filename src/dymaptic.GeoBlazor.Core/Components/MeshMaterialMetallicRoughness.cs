namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshMaterialMetallicRoughness
{
   // Add custom code to this file to override generated code
   
   public override MapComponentSerializationRecord ToProtobuf()
   {
       return ToSerializationRecord();
   }
    
   internal override MeshComponentMaterialSerializationRecord ToSerializationRecord()
   {
       return new MeshComponentMaterialSerializationRecord(AlphaCutoff,
           AlphaMode?.ToString().ToKebabCase(),
           Color,
           ColorTexture?.ToSerializationRecord(),
           ColorTextureTransform?.ToSerializationRecord(),
           DoubleSided,
           NormalTexture?.ToSerializationRecord(),
           NormalTextureTransform?.ToSerializationRecord(),
           EmissiveColor,
           EmissiveTexture?.ToSerializationRecord(),
           EmissiveTextureTransform?.ToSerializationRecord(),
           Metallic,
           MetallicRoughnessTexture?.ToSerializationRecord(),
           OcclusionTexture?.ToSerializationRecord(),
           OcclusionTextureTransform?.ToSerializationRecord(),
           Roughness);
   }
}