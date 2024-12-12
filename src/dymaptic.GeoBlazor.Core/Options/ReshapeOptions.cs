namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Changes the behavior for the reshape tool. Defines the operations for edge and/or the constraints for moving a shape and/or a vertex. Only supported in 3D.
/// </summary>
/// <param name="EdgeOperation">
///     Sets the reshape operation on the edge. This affects lines and polygons. Fully supported in 3D, partially in 2D.
///     Possible Values:"none"|"split"|"offset". Default Value: split.
/// </param>
/// <param name="ShapeOperation">
///     Sets the move constraints for the whole shape. Supported in 2D and 3D.
///     Possible Values:"none"|"move"|"move-xy". Default Value: move.
/// </param>
/// <param name="VertexOperation">
///     Sets the move constraints for the vertex. Only supported in 3D.
///     Possible Values:"move"|"move-xy". Default Value: move.
/// </param>
public record ReshapeOptions(string EdgeOperation, string ShapeOperation, string VertexOperation);