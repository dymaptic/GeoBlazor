namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshMaterialMetallicRoughness
{
   // Add custom code to this file to override generated code
   
   public override MeshComponentMaterialSerializationRecord ToProtobuf()
   {
       return new MeshComponentMaterialSerializationRecord(AlphaCutoff,
           AlphaMode?.ToString().ToKebabCase(),
           Color,
           ColorTexture?.ToProtobuf(),
           ColorTextureTransform?.ToProtobuf(),
           DoubleSided,
           NormalTexture?.ToProtobuf(),
           NormalTextureTransform?.ToProtobuf(),
           EmissiveColor,
           EmissiveTexture?.ToProtobuf(),
           EmissiveTextureTransform?.ToProtobuf(),
           Metallic,
           MetallicRoughnessTexture?.ToProtobuf(),
           OcclusionTexture?.ToProtobuf(),
           OcclusionTextureTransform?.ToProtobuf(),
           Roughness);
   }
}