using dymaptic.GeoBlazor.Core.Model;


namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     Exception thrown when an application calls <see cref="OAuthAuthentication.Initialize()"/> without first setting an APP Id in the configuration.
/// </summary>
public class MissingAppIdException: Exception
{
    /// <inheritdoc />
    public MissingAppIdException() : 
        base("Missing ArcGIS App ID. Please add an App ID to your configuration in order to use OAuth.")
    {
    }
}