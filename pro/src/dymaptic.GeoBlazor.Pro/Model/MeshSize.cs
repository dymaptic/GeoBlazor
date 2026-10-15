namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     A uniform size value or an object containing individual values width, height and depth.
/// </summary>
[JsonConverter(typeof(MeshSizeConverter))]
[CodeGenerationIgnore]
public record MeshSize
{
    /// <summary>
    ///     Creates a new instance of the <see cref="MeshSize" /> class from a single uniform `Value`.
    /// </summary>
    /// <param name="value">
    ///     The single-value uniform size of the mesh.
    /// </param>
    public MeshSize(double? value)
    {
        Value = value;
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="MeshSize" /> class from individual values `Width`, `Height` and `Depth`.
    /// </summary>
    /// <param name="width">
    ///     The width of the mesh.
    /// </param>
    /// <param name="height">
    ///     The height of the mesh.
    /// </param>
    /// <param name="depth">
    ///     The depth of the mesh.
    /// </param>
    public MeshSize(double? width, double? height, double? depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }
    
    /// <summary>
    ///     The single-value uniform size of the mesh.
    /// </summary>
    public double? Value { get; set; }
    
    /// <summary>
    ///     The width of the mesh.
    /// </summary>
    public double? Width { get; set; }
    
    /// <summary>
    ///     The height of the mesh.
    /// </summary>
    public double? Height { get; set; }
    
    /// <summary>
    ///     The depth of the mesh.
    /// </summary>
    public double? Depth { get; set; }
}