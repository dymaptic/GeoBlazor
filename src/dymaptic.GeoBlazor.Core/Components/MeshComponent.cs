namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class MeshComponent: IProtobufSerializable<MeshComponentSerializationRecord>
{
   // Add custom code to this file to override generated code
   /// <inheritdoc />
    public MeshComponentSerializationRecord ToProtobuf()
   {
       MeshComponentMaterialSerializationRecord? materialRecord = Material switch
       {
           MeshMaterialMetallicRoughness metallicRoughness => metallicRoughness.ToProtobuf(),
           MeshMaterial material => material.ToProtobuf(),
           _ => null
       };
       return new MeshComponentSerializationRecord(Faces,
           materialRecord, Name, Shading?.ToString().ToKebabCase());
   }
}