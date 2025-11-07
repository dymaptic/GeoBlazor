namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for VertexSpace in a Mesh.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IMeshVertexSpace>))]
public interface IMeshVertexSpace: IProtobufSerializable<MeshVertexSpaceSerializationRecord>
{
}
