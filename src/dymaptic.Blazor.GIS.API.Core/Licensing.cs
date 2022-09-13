using System.Reflection;


namespace dymaptic.Blazor.GIS.API.Core;

public static class Licensing
{
    public static LicenseType GetLicenseType()
    {
        try
        {
            Assembly interactiveAssembly = Assembly.Load("dymaptic.Blazor.GIS.API.Interactive");
            return LicenseType.Interactive;
        }
        catch
        {
            return LicenseType.Core;
        }
    }
}


public enum LicenseType
{
    Core = 0, // default, no license, free
    Interactive = 100 // first paid license tier, leaving room for other future tiers on either side
}
