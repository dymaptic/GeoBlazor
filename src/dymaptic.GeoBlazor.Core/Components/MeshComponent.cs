namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshComponent: IProtobufSerializable, IMeshComponent
{
   // Add custom code to this file to override generated code
   public MapComponentSerializationRecord ToProtobuf()
   {
       return ToSerializationRecord();
   }

   internal MeshComponentSerializationRecord ToSerializationRecord()
   {
       MeshComponentMaterialSerializationRecord? materialRecord = Material switch
       {
           MeshMaterialMetallicRoughness metallicRoughness => metallicRoughness.ToSerializationRecord(),
           MeshMaterial material => material.ToSerializationRecord(),
           _ => null
       };
       return new MeshComponentSerializationRecord(Faces,
           materialRecord, Name, Shading?.ToString().ToKebabCase());
   }
}