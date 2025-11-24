namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A mesh vertex space that indicates mesh vertices to be in a plain cartesian space as often encountered in 3D modeling and CAD applications. Georeferencing is done by using the coordinates in the local tangent plane reference frame at the fully georeferenced origin of the vertex space.
/// </summary>
/// <param name="Origin">
///     Origin of the vertex space. This will be interpreted as coordinates in the SpatialReference of the Mesh using the vertex space.
/// </param>
[CodeGenerationIgnore]
[ProtobufSerializable]
public record MeshLocalVertexSpace(double[]? Origin) : IMeshVertexSpace
{
    public string Type => "local";
    
    /// <inheritdoc />
    public MeshVertexSpaceSerializationRecord ToProtobuf()
    {
        return new MeshVertexSpaceSerializationRecord(Type, Origin);
    }
}