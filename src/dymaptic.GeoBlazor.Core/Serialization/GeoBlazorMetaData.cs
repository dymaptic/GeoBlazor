namespace dymaptic.GeoBlazor.Core.Serialization;

public static class GeoBlazorMetaData
{
    static GeoBlazorMetaData()
    {
        GeoblazorTypes = typeof(GeoBlazorMetaData).Assembly.GetTypes();

        try
        {
            Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
            Type[] proTypes = proAssembly.GetTypes();
            GeoblazorTypes = GeoblazorTypes.Concat(proTypes).ToArray();
        }
        catch
        {
            // GeoBlazor.Pro not available
        }
    }
    
    public static Type[] GeoblazorTypes { get; }
}