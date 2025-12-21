namespace dymaptic.GeoBlazor.Core;

internal static class Licensing
{
    public static LicenseType GetLicenseType()
    {
        if (!_isPro.HasValue)
        {
            try
            {
                _ = Assembly.Load("dymaptic.GeoBlazor.Pro");

                _isPro = true;
            }
            catch(FileNotFoundException)
            {
                _isPro = false;
            }    
        }
        
        return _isPro.Value ? LicenseType.Pro : LicenseType.Core;
    }

    private static bool? _isPro;
}

internal enum LicenseType
{
    Core = 0, // default, no license, free
    Pro = 100 // first paid license tier, leaving room for other future tiers on either side
}