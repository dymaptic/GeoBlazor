namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshComponent: IProtobufSerializable<MeshComponentSerializationRecord>, IMeshComponent
{
   // Add custom code to this file to override generated code
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