namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Configuration Settings Object, can be populated from JSON (e.g., appsettings.json) or environment variables.
/// </summary>
public class GeoBlazorSettings
{
    /// <summary>
    ///     The GeoBlazor Core Registration Key, generated on the licensing server.
    /// </summary>
    public string? RegistrationKey { get; set; }
    
    /// <summary>
    ///     The GeoBlazor Pro License Key, generated on the licensing server.
    /// </summary>
    public string? LicenseKey { get; set; }
}