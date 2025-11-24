namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for VertexSpace in a Mesh.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IMeshVertexSpace>))]
[ProtobufSerializable]
public interface IMeshVertexSpace: IProtobufSerializable<MeshVertexSpaceSerializationRecord>
{
}
