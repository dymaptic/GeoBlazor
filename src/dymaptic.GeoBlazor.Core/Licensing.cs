using System.Reflection;


namespace dymaptic.GeoBlazor.Core;

internal static class Licensing
{
    public static LicenseType GetLicenseType()
    {
        try
        {
           _ = Assembly.Load("dymaptic.GeoBlazor.Pro");

            return LicenseType.Pro;
        }
        catch
        {
            return LicenseType.Core;
        }
    }
}

internal enum LicenseType
{
    Core = 0, // default, no license, free
    Pro = 100 // first paid license tier, leaving room for other future tiers on either side
}