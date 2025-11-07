namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A mesh vertex space indicating that mesh vertices are either absolute georeferenced map coordinates or relative offsets in map space to a fully georeferenced origin. The map space is identified by the spatial reference of the mesh.
///     The vertex space of a mesh allows users to specify how the coordinates of the mesh vertices are interpreted. Use the georeferenced vertex space if the coordinates are already in the spatial reference of the mesh. The coordinates can be relative to the origin or absolute coordinates if the origin is not defined.
/// </summary>
/// <param name="Origin">
///     Origin of the vertex space. This will be interpreted as coordinates in the SpatialReference of the Mesh using the vertex space. If this is null, the coordinates are expected to be absolute. If not, then the coordinates are expected to be deltas relative to the origin.
/// </param>
[CodeGenerationIgnore]
public record MeshGeoreferencedVertexSpace(double[]? Origin) : IMeshVertexSpace
{
    public string Type => "georeferenced";
    public MeshVertexSpaceSerializationRecord ToProtobuf()
    {
        return new MeshVertexSpaceSerializationRecord(Type, Origin);
    }
}