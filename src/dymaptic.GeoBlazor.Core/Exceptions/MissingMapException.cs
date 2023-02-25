using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Views;


namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     Exception when a <see cref="MapView" /> is created with no <see cref="Map" /> or <see cref="WebMap" />
/// </summary>
public class MissingMapException : Exception
{
    /// <summary>
    ///     Creates a new MissingMapException
    /// </summary>
    public MissingMapException() :
        base("No map or web map was provided")
    {
    }
}