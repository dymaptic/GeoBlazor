namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Provides metadata about GeoBlazor types for serialization and reflection purposes.
/// </summary>
public static class GeoBlazorMetaData
{
    /// <summary>
    ///     All types from GeoBlazor.Core and GeoBlazor.Pro (if available) assemblies.
    /// </summary>
    public static Type[] GeoblazorTypes
    {
        get
        {
            if (field == null)
            {
                field = typeof(GeoBlazorMetaData).Assembly.GetTypes();

                try
                {
                    // Attempt to load GeoBlazor.Pro types if the assembly is available.
                    // This enables protobuf serialization to work with both Core and Pro types.
                    var proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
                    var proTypes = proAssembly.GetTypes();
                    field = field.Concat(proTypes).ToArray();
                }
                catch (FileNotFoundException)
                {
                    // GeoBlazor.Pro assembly not available - this is expected for Core-only installations
                }
            }

            return field;
        }
    }
}