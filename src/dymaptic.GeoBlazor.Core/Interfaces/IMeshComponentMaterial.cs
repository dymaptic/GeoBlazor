namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IMeshComponentMaterial>))]
[ProtobufSerializable]
public partial interface IMeshComponentMaterial: IProtobufSerializable<MeshComponentMaterialSerializationRecord>
{
   // Add custom code to this file to override generated code
}
