namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Provides metadata about GeoBlazor types for serialization and reflection purposes.
/// </summary>
public static class GeoBlazorMetaData
{
    static GeoBlazorMetaData()
    {
        GeoblazorTypes = typeof(GeoBlazorMetaData).Assembly.GetTypes();

        try
        {
            // Attempt to load GeoBlazor.Pro types if the assembly is available.
            // This enables protobuf serialization to work with both Core and Pro types.
            Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
            Type[] proTypes = proAssembly.GetTypes();
            GeoblazorTypes = GeoblazorTypes.Concat(proTypes).ToArray();
        }
        catch (FileNotFoundException)
        {
            // GeoBlazor.Pro assembly not available - this is expected for Core-only installations
        }
    }

    /// <summary>
    ///     All types from GeoBlazor.Core and GeoBlazor.Pro (if available) assemblies.
    /// </summary>
    public static Type[] GeoblazorTypes { get; }
}