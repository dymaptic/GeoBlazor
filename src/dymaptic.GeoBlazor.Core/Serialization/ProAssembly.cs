namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Holds reflection references to the GeoBlazor Pro assembly if available
/// </summary>
public static class ProAssembly
{
    static ProAssembly()
    {
        try
        {
            _proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
            Types = _proAssembly.GetTypes();
            Available = true;
        }
        catch
        {
            // pro not available
        }
    }

    /// <summary>
    ///    Whether the Pro assembly is available for use
    /// </summary>
    public static bool Available { get; set; }
 
    /// <summary>
    ///    The types contained in the Pro assembly if available
    /// </summary>
    public static Type[] Types { get; set; } = [];

    /// <summary>
    ///    Gets a type from the Pro assembly by name if available
    /// </summary>
    /// <param name="name">The name of the type to retrieve.</param>
    /// <returns>The type if found; otherwise, null.</returns>
    public static Type? GetType(string name) => Types.FirstOrDefault(t => 
        t.FullName!.Equals(name, StringComparison.OrdinalIgnoreCase)
        || t.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));

    private static readonly Assembly? _proAssembly;
}