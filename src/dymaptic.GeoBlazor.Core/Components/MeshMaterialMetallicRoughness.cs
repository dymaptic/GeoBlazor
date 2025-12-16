namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class MeshMaterialMetallicRoughness
{
   // Add custom code to this file to override generated code
   
   /// <inheritdoc />
    public override MeshComponentMaterialSerializationRecord ToProtobuf()
   {
       return new MeshComponentMaterialSerializationRecord(AlphaCutoff,
           AlphaMode?.ToString().ToKebabCase(),
           Color?.ToProtobuf(),
           ColorTexture?.ToProtobuf(),
           ColorTextureTransform?.ToProtobuf(),
           DoubleSided,
           NormalTexture?.ToProtobuf(),
           NormalTextureTransform?.ToProtobuf(),
           EmissiveColor?.ToProtobuf(),
           EmissiveTexture?.ToProtobuf(),
           EmissiveTextureTransform?.ToProtobuf(),
           Metallic,
           MetallicRoughnessTexture?.ToProtobuf(),
           OcclusionTexture?.ToProtobuf(),
           OcclusionTextureTransform?.ToProtobuf(),
           Roughness);
   }
}