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
                field = typeof(GeoBlazorMetaData).Assembly.GetTypes().Concat(ProAssembly.Types).ToArray();
            }

            return field;
        }
    }
}